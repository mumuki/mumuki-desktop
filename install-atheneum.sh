#!/bin/bash

REPO="https://github.com/rodri042/mumuki-atheneum"

# Install rvm
gpg --keyserver hkp://keys.gnupg.net --recv-keys 409B6B1796C275462A1703113804BB82D39DC0E3
curl -sSL https://get.rvm.io | bash -s stable
source /home/vagrant/.rvm/scripts/rvm

# Install ruby 2.0.0
rvm install ruby-2.0.0-p481

# Install bundle
gem install bundle

# Install postgresql
sudo apt-get install -y postgresql libpq-dev

# Create 'mumuki' user
echo "create role mumuki with createdb login password 'mumuki';" > create_role.sql
sudo -u postgres psql -a -f create_role.sql

# Install git and clone the repo
sudo apt-get install -y git
git clone "$REPO"

# ----------------
cd mumuki-atheneum
# ----------------

# Install atheneum dependencies
bundle install

# Create and seed the db
rake db:create
rake db:migrate
rake db:seed