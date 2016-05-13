#!/bin/bash

vagrant up
vagrant ssh -c "cd && exec ./run.rb"
# sudo dpkg -i vagrant-1.8.deb virtualbox-5.deb
# sudo /etc/init.d/vboxdrv setup
