#!/bin/bash

# The `bootswatch-rails` gem does not support loading the fonts offline :(
cp ./_bootswatch.scss "$(rvm gemdir)/gems/bootswatch-rails*/vendor/assets/stylesheets/bootswatch/flatly/_bootswatch.scss"
cp -r ./googlefonts ~/mumuki-atheneum/app/assets/fonts
