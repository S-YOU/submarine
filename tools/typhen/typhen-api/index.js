'use strict';

var path = require('path');
var assert = require('assert');
var _ = require('lodash');

var HttpMethods = ['post', 'get', 'delete', 'put'];
var InflectionOptions = ['underscore', 'upperCamelCase', 'lowerCamelCase'];

module.exports = function(typhen, options) {
  assert(options, 'options is empty');
  assert(typeof options.templateName === 'string', 'options.templateName is required');

  var template;

  var helpers = {
    isWebApiModule: function(module) {
      assert(module.isModule, 'should be a module');
      if (module.functions.length > 0) {
        return true;
      } else if (module.modules.length > 0) {
        return _.any(module.modules, function(m) { return helpers.isWebApiModule(m); });
      } else {
        return false;
      }
    },

    isWebSocketApiModule: function(module) {
      assert(module.isModule, 'should be a module');
      if (module.variables.length > 0) {
        return true;
      } else if (module.modules.length > 0) {
        return _.any(module.modules, function(m) { return helpers.isWebSocketApiModule(m); });
      } else {
        return false;
      }
    },

    method: function(func) {
      assert(func.isFunction, 'should be a function');
      var method = func.tagTable.method ? func.tagTable.method.value : 'post';
      assert(_.includes(HttpMethods, method), 'unsupported HTTP method: ' + method);
      return method;
    },

    uriPath: function(func) {
      assert(func.isFunction, 'should be a function');
      var inflection = func.ancestorModules[0].tagTable.uriInflection;
      var helperName = inflection ? inflection.value : 'underscore';
      assert(_.includes(InflectionOptions, helperName), 'unsupported inflection type: ' + helperName);
      return typhen.helpers[helperName](func.fullName).split(template.namespaceSeparator).slice(1).join('/');
    },

    uriSuffix: function(func) {
      assert(func.isFunction, 'should be a function');
      return func.ancestorModules[0].tagTable.uriSuffix;
    },

    serializablePropertyName: function(symbol) {
      assert(symbol.isProperty || symbol.isParameter, 'should be a property or function parameter');
      var inflection = symbol.ancestorModules[0].tagTable.serializablePropertyInflection;
      var helperName = inflection ? inflection.value : 'underscore';
      assert(_.includes(InflectionOptions, helperName), 'unsupported inflection type: ' + helperName);
      return typhen.helpers[helperName](symbol.name);
    },

    webSocketMessageType: function(variable) {
      assert(variable.isVariable, 'should be a variable');
      var name = typhen.helpers.upperCamelCase(variable.fullName).replace(template.namespaceSeparator, '.');
      var hash = 0;
      for (var i = 0; i < name.length; i++) {
        hash = (((hash << 5) - hash) + name.charCodeAt(i)) & 0xFFFFFFFE;
      }
      return hash;
    },

    errorType: function(module) {
      assert(module.isModule, 'should be a module');
      var rootModule = module.parentModule === null ? module : module.ancestorModules[0];
      return rootModule.types.find(function(t) { return t.name === 'Error'; });
    }
  };

  template = require(path.join(__dirname, 'lib', options.templateName, 'index.js'))(typhen, options, helpers);

  if (template.requiredTargetModule) {
    assert(typeof options.targetModule === 'string', 'options.targetModule is required');
  }

  return typhen.createPlugin({
    pluginDirectory: __dirname,
    customPrimitiveTypes: ['integer'],
    namespaceSeparator: template.namespaceSeparator,

    disallow: {
      any: true,
      overload: true,
      unionType: true,
      tuple: true,
      anonymousFunction: true
    },

    handlebarsOptions: {
      data: options,
      helpers: template.helpers
    },

    rename: template.rename,

    generate: function(generator, types, modules) {
      var targetModule = null;

      if (template.requiredTargetModule) {
        targetModule = modules.find(function(m) { return m.fullName === options.targetModule; });
        assert(targetModule, options.targetModule + ' module is not found');
      }

      var filteredTypes = types.filter(function(t) { return !t.tagTable.internal; });
      var filteredModules = modules.filter(function(m) { return !m.isGlobalModule; });

      filteredTypes.forEach(function(type) {
        if (type.isFunction) {
          assert(
            type.callSignatures.every(function(s) { return s.typeParameters.length === 0}),
            type.fullName + ' can\'t have type parameters at ' + type.declarationInfos
          );
        }
      });

      filteredModules.forEach(function(module) {
        if (module.parentModule === null && (helpers.isWebApiModule(module) || helpers.isWebSocketApiModule(module))) {
          assert(
            helpers.errorType(module),
            'Undefined the Error type in ' + module.name + ' module'
          );
        }

        module.variables.forEach(function(variable) {
          assert(
            variable.type.isObjectType || variable.type.isInterface || variable.type.isClass,
            'Disallow to use ' + variable.type.name + ' as realtime message at ' + variable.declarationInfos
          );
        });
      });

      return template.generate(generator, filteredTypes, filteredModules, targetModule);
    }
  });
};
