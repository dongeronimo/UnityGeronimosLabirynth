cd build-webgl
sudo heroku container:login
sudo heroku container:push web -a hello-emscripten-sdl
sudo heroku container:release web -a hello-emscripten-sdl

