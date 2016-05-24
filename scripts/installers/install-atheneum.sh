#!/bin/bash

REPO="https://github.com/mumuki/mumuki-atheneum"

cd ..
#  ^^ scripts directory

# Set environment variables
. env.sh

# Import the `try` helper
. ../dist/try.sh

# Copy all these scripts to the machine
try cp -r * ~

cd ~
#  ^ all is installed here

# ----------
# Essentials
# ----------

# Install rvm
try curl -#LO https://rvm.io/mpapis.asc
try gpg --import mpapis.asc
try curl -sSL https://get.rvm.io | bash -s stable
. /home/vagrant/.rvm/scripts/rvm

# Install ruby 2.0.0
try rvm install ruby-2.0.0-p481

# Install bundler
try gem install bundler

# Install postgresql
try sudo apt-get install -y postgresql libpq-dev

# Replace dash with bash
sudo ln -sf /bin/bash /bin/sh

# --------------
# Extra software
# --------------

# Install docker
try sudo apt-get install -y docker.io
sudo groupadd docker
try sudo gpasswd -a ${USER} docker
sudo service docker restart

# ------------
# Mumuki stuff
# ------------

# Create 'mumuki' user
try echo "create role mumuki with createdb login password 'mumuki';" > /tmp/create_role.sql
try sudo -u postgres psql -a -f /tmp/create_role.sql

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
try rake db:create db:migrate db:seed

# Compile the assets
try rake assets:precompile
