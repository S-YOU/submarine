# This file was generated by typhen-api

module TyphenApi::Model::Submarine
  class SignUpObject
    include Virtus.model(:strict => true)

    attribute :user, TyphenApi::Model::Submarine::User, :required => true
  end
end
