opengl: ./opengl/*
  @echo Compiling OpenGL for GForth Systems >,..,>
  @gforth -e "include ./opengl/opengl.fth bye"
  @echo Done ^,..,^
