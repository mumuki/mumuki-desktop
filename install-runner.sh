#!/bin/bash

# Gobstones
bundle install
git submodule update --init --recursive
bundle exec rackup

# // TODO
# en teoría http://thesaurus.mumuki.io/languages me da la info de los lenguajes
# ir a biblotheca a bajar la metadata e insertarla en un la bd
# guardar en un archivo los puertos asignados
# esto debería (o sería deseable) que sea un script de ruby

# en la base de datos mumuki_development;
# update languages set test_runner_url='http://localhost:9292' where id = 2;
