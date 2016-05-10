#!/bin/bash

# The `bootswatch-rails` gem does not support loading the fonts offline :(
THEME_DIR=$(rvm gemdir)/gems/bootswatch-rails*/vendor/assets/stylesheets/bootswatch/flatly
cp ./_bootswatch.scss $THEME_DIR/_bootswatch.scss
cp -r ./googlefonts ~/mumuki-atheneum/app/assets/fonts
