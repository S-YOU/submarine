# == Schema Information
#
# Table name: users
#
#  id               :integer          not null, primary key
#  name             :string(255)      not null
#  crypted_password :string(255)
#  salt             :string(255)
#  created_at       :datetime
#  updated_at       :datetime
#
# Indexes
#
#  index_users_on_name  (name) UNIQUE
#

class User < ActiveRecord::Base
  authenticates_with_sorcery!

  validates :password, length: { minimum: 6 }

  validates :name, presence: true
  validates :name, uniqueness: true
  validates :name, length: { minimum: 3 }

  def to_api_type
    TyphenApi::Model::Submarine::User.new(id: id, name: name)
  end
end
