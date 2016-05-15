require "minitest/autorun"
require "tempfile"
load "languages_local.rb"

describe LocalIndex do
  extend Minitest::Spec::DSL

  let(:file) { Tempfile.new "test.json" }
  let(:index) { LocalIndex.new file.path }
  after do file.close ; file.unlink end

  def save_and_check(json)
    index.save!
    file.read.must_equal json
  end

  describe "when the file doesn't exist" do
    it "creates one with default values" do
      save_and_check '{"languages":[]}'
    end

    it "can adds languages and return the port" do
      cobol_port = index.add_language! "cobol"
      cobol_port.must_equal 3001
      save_and_check '{"languages":[{"name":"cobol","port":3001}]}'
    end
  end

  describe "when the file exists" do
    before do
      index.add_language! "cobol"
      index.save!
      index.load!
    end

    it "can respond if a language is installed" do
      index.is_installed?("cobol").must_equal true
      index.is_installed?("gobstones").must_equal false
    end

    it "adds the new languages with a consecutive port" do
      gobstones_port = index.add_language! "gobstones"
      gobstones_port.must_equal 3002
      save_and_check '{"languages":[{"name":"cobol","port":3001},{"name":"gobstones","port":3002}]}'
    end

    it "can remove languages" do
      index.remove_language! "cobol"
      save_and_check '{"languages":[]}'
    end
  end

end
