#!/bin/bash

REPO="https://github.com/rodri042/mumuki-atheneum"
cd

function try {
  "$@"
  local status=$?
  if [ $status -ne 0 ]; then
      echo "!!!Error!!! with $1" >&2
      exit $?
  fi
  return $status
}

# ----------
# Essentials
# ----------

# Install rvm
try curl -#LO https://rvm.io/mpapis.asc
try gpg --import mpapis.asc
try curl -sSL https://get.rvm.io | bash -s stable
try . /home/vagrant/.rvm/scripts/rvm

# Install ruby 2.0.0
try rvm install ruby-2.0.0-p481

# Install bundler
try gem install bundler

# Install postgresql
try sudo apt-get install -y postgresql libpq-dev

# Replace dash with bash ¬.¬
sudo ln -s -f /bin/bash /bin/sh

# --------------
# Extra software
# --------------

# Install docker
try sudo apt-get install docker.io
sudo groupadd docker
try sudo gpasswd -a ${USER} docker
sudo service docker restart

# ------------
# Mumuki stuff
# ------------

# Create 'mumuki' user
try echo "create role mumuki with createdb login password 'mumuki';" > /tmp/create_role.sql
try sudo -u postgres psql -a -f /tmp/create_role.sql

# Copy the run.rb script that loads everything
cp /vagrant/{languages_local.rb,run.rb,stop.rb} ~

# Install git and clone the repo
try sudo apt-get install -y git
try git clone "$REPO"

cd mumuki-atheneum
#  ^^^^^^^^^^^^^^^

# Install atheneum dependencies
try bundle install

# Monkey-patch the bootswatch's flatly theme to work offline
(cd /vagrant/bootswatch-flatly-offline-fix && exec ./fix.sh)
try

# Create and seed the db
try rake db:create
try rake db:migrate
try rake db:seed
