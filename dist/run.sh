#!/bin/bash

vagrant up
vagrant ssh -c "cd && exec ./run.rb"
