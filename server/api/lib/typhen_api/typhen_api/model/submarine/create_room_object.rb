# This file was generated by typhen-api

module TyphenApi::Model::Submarine
  class CreateRoomObject
    include Virtus.model(:strict => true)

    attribute :room, TyphenApi::Model::Submarine::Room, :required => true
  end
end