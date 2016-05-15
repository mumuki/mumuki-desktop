#!/bin/bash

. try.sh

try sudo dpkg -i vagrant-1.8.deb virtualbox-5.deb
try sudo /etc/init.d/vboxdrv setup

./mumuki-box-install.sh
./run.sh
