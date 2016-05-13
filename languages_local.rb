require "json"

class LocalIndex
  FILE_NAME = "#{ENV['HOME']}/installed-languages.json"
  INITIAL_PORT = 3000
  DEFAULT_INDEX = { "languages" => [] }
  attr_reader :info

  def initialize
    @info =
      begin
        JSON.parse File.read(FILE_NAME)
      rescue
        DEFAULT_INDEX
      end
  end

  # Returns if a language is installed or not
  def is_installed?(language_name)
    @info["languages"].any? { |it| it["name"] == language_name }
  end

  # Adds a language to the index
  # Returns the assigned port
  def add_language!(language_name)
    port = (@info["languages"].map { |it| it["port"] }.max || INITIAL_PORT) + 1
    new_entry = { "name" => language_name, "port" => port }

    @info["languages"].push new_entry
    save!
    port
  end

  # Removes a language from the index
  def remove_language!(language_name)
    entry = @info["languages"].find { |it| it["name"] == language_name }
    @info["languages"].delete entry
    save!
  end

  # Save the changes in the file
  def save!
    File.write FILE_NAME, JSON.generate(@info)
  end
end
