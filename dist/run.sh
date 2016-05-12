#!/bin/bash

vagrant up
vagrant ssh -c "cd ; ./run.rb"
# //TODO: Read from ~/installed-languages.rb and launch runners!
