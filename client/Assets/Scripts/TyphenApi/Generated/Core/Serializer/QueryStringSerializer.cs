﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TyphenApi
{
    public class QueryStringSerializer : ISerializer
    {
        public byte[] Serialize(object obj)
        {
            var objType = obj.GetType();
            var texts = new List<string>();

            foreach (var property in objType.GetProperties())
            {
                var attributes = property.GetCustomAttributes(typeof(SerializablePropertyAttribute), true);

                foreach (var attribute in attributes)
                {
                    var metaInfo = (SerializablePropertyAttribute)attribute;
                    var value = property.GetValue(obj, null);

                    if (metaInfo.IsOptional && value == null)
                    {
                        continue;
                    }

                    var valueType = property.PropertyType;

                    if (value == null && IsNullableType(valueType))
                    {
                        var message = string.Format("{0}.{1} is not allowed to be null.", objType.FullName, property.Name);
                        throw new NoNullAllowedException(message);
                    }
                    else if (IsSerializableValue(value, valueType))
                    {
                        var fixedValue = valueType.IsEnum ? (int)value : value;
                        var keyValueText = string.Format("{0}={1}",
                            Uri.EscapeDataString(metaInfo.PropertyName),
                            Uri.EscapeDataString(fixedValue.ToString())
                        );
                        texts.Add(keyValueText);
                    }
                    else
                    {
                        var message = string.Format("Failed to serialize {0} ({1}) to {2}.{3}", value, valueType, objType.FullName, property.Name);
                        throw new SerializeFailedError(message);
                    }
                }
            }

            return texts.Count > 0 ?
                Encoding.ASCII.GetBytes("?" + string.Join("&", texts.ToArray())) :
                Encoding.ASCII.GetBytes(string.Empty);
        }

        public T Deserialize<T>(byte[] bytes) where T : new()
        {
            throw new NotImplementedException();
        }

        bool IsNullableType(System.Type type)
        {
            return type.IsClass || Nullable.GetUnderlyingType(type) != null;
        }

        bool IsSerializableValue(object value, System.Type valueType)
        {
            return valueType.IsPrimitive || valueType.IsEnum || value is string;
        }
    }
}
