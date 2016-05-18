# // TODO: This should be in Thesaurus
#    and the `languages` table after
#    running the `rake db:seed` command.
#    https://github.com/mumuki/mumukit/issues/33

def repos
  {
    "haskell" => "https://github.com/mumuki/mumuki-hspec-server2",
    "gobstones" => "https://github.com/mumuki/mumuki-gobstones-server",
    "javascript" => "https://github.com/mumuki/mumuki-mocha-server",
    "c" => "https://github.com/mumuki/mumuki-cspec-server",
    "c++" => "https://github.com/mumuki/mumuki-cppunit-server",
    "prolog" => "https://github.com/mumuki/mumuki-plunit-server",
    "ruby" => "https://github.com/mumuki/mumuki-rspec-server",
    "java" => "https://github.com/mumuki/mumuki-junit-server",
    "wolloc" => "https://github.com/mumuki/mumuki-wollok-server",
    "text" => "https://github.com/mumuki/mumuki-text-server"
  }
end
