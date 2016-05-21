#!/bin/bash

. try.sh

function installIfNeeded {
  name = $1
  install = $2

  if ! [ $(where "$name") ]; then
    echo "Install $name: INSTALLING"
    "$@"
  else
    echo "Install $name: NOTNEEDED"
  fi
}

function installVirtualBox {
  try sudo dpkg -i install-virtualbox.deb
  try sudo /etc/init.d/vboxdrv setup
}

function installVagrant {
  try sudo dpkg -i install-vagrant.deb
}

function installChrome {
  try sudo dpkg -i install-chrome.deb
}

# Install software
installIfNeeded "virtualbox", installVirtualBox
installIfNeeded "vagrant", installVagrant
installIfNeeded "google-chrome", installChrome

# Install the box
boxes=`vagrant box list`
if [[ $boxes =~ "mumuki" ]]; then
  echo "The mumuki box is installed!"
else
  echo "Installing mumuki.box..."
  ./mumuki-box-install.sh
fi

try vagrant up
try google-chrome --app="http://localhost:3000"
