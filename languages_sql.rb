require "pg"
load "languages_sql_repos.rb"

# Connects to the db
def connect
  PG.connect(
    host: "localhost",
    dbname: "mumuki_development",
    user: "mumuki",
    password: "mumuki"
  )
end

# Retrieves a language from the database
def get_language(language_name)
  connect
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

# Updates the url of a runner with the port.
def add_language_to_database(id, port)
  connect.exec "update languages set test_runner_url='http://localhost:#{port}' where id = #{id}"
end
