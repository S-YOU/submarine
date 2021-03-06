# This file was generated by typhen-api

module TyphenApi::Model::Submarine::Battle
  class ActorType < Virtus::Attribute
    Submarine = 0
    Torpedo = 1
    Decoy = 2
    Lookout = 3

    def self.name_table
      @@name_table ||= {
        0 => 'Submarine',
        1 => 'Torpedo',
        2 => 'Decoy',
        3 => 'Lookout'
      }
    end

    def coerce(value)
      case value
      when Integer
        unless self.class.name_table.has_key?(value)
          raise Virtus::CoercionError.new("#{value} as #{self.class}", self)
        end
        value
      when String
        begin
          self.class.const_get(value.classify, false)
        rescue NameError => e
          raise Virtus::CoercionError.new("#{value} as #{self.class}", self)
        end
      else
        raise Virtus::CoercionError.new("#{value.class.name} as #{self.class}", self)
      end
    end
  end
end
