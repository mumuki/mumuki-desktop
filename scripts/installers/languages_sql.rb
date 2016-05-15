require "pg"
load "languages_sql_repos.rb"

class SqlIndex
  def initialize
    @connection = PG.connect(
      host: "localhost",
      dbname: "mumuki",
      user: "mumuki",
      password: "mumuki"
    )
  end

  # Retrieves a language from the database
  def get_language(language_name)
    @connection
      .exec("select * from languages;") { |languages|
        language = languages.find { |it| it["name"] == language_name }
        repo_url = repos[language_name]

        if language.nil?
          abort "The language '#{language_name}' wasn't found. Did you run `rake db:seed`?"
        end

        if repo_url.nil?
          abort "Missing repository url for '#{language_name}'."
        end

        yield language, repo_url
      }
  end

  # Updates the url of the runners with its assigned ports
  def update_languages_table(info)
    info["languages"].each do |language|
      @connection.exec "update languages set test_runner_url='http://localhost:#{language['port']}' where name = '#{language['name']}'"
    end
  end
end
