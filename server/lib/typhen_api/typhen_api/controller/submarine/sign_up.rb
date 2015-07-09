# This file was generated by typhen-api

module TyphenApi::Controller::Submarine
  module SignUp
    extend ActiveSupport::Concern

    class RequestType
      include Virtus.model(:strict => true)

      attribute :name, String, :required => true
      attribute :password, String, :required => true
    end

    ResponseType = TyphenApi::Model::Submarine::SignUpObject
    ErrorType = TyphenApi::Model::Submarine::Error

    def no_authentication_required?
      true
    end
  end
end