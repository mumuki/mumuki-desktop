require "pg"

# Connects to the db
def connect
  PG.connect(
    host: "localhost",
    dbname: "mumuki_development",
    user: "mumuki",
    password: "mumuki"
  )
end

# Retrieves a list of languages
def get_languages
  connect
    .exec("select * from languages;") { |r| yield r }
end

# Updates the url of a runner with the port.
def add_language_to_database(id, port)
  connect.exec "update languages set test_runner_url='http://localhost:#{port}' where id = #{id}"
end
