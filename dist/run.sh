#!/bin/bash

. try.sh

try vagrant up
try vagrant ssh -c "cd ~ && exec ./run.rb"
