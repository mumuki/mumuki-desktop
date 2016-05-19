#!/bin/bash

. try.sh

try sudo dpkg -i install-vagrant.deb install-virtualbox.deb
try sudo /etc/init.d/vboxdrv setup

./mumuki-box-install.sh
vagrant up
