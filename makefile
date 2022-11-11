opengl: ./opengl/*
  @echo Compiling OpenGL for GForth Systems >,..,>
  @gforth -e "include ./opengl/gl.fs bye"
  @gforth -e "include ./opengl/glu.fs bye"
  @echo Done ^,..,^
