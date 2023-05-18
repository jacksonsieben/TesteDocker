@echo off

cd ./WebAPI

docker-compose build
docker-compose up -d

timeout 10

start firefox localhost:9001
