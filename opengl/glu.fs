\
\ glu.4th
\
\ A FORTH "Implementation/Wrapper" for the "Mesa 3-D grapics library"
\ 
\ Original C code liscence:
\ SGI FREE SOFTWARE LICENSE B (Version 2.0, Sept. 18, 2008)
\ Copyright (C) 1991-2000 Silicon Graphics, Inc. All Rights Reserved.
\ 
\ Permission is hereby granted, free of charge, to any person obtaining a
\ copy of this software and associated documentation files (the "Software"),
\ to deal in the Software without restriction, including without limitation
\ the rights to use, copy, modify, merge, publish, distribute, sublicense,
\ and/or sell copies of the Software, and to permit persons to whom the
\ Software is furnished to do so, subject to the following conditions:
\ 
\ The above copyright notice including the dates of first publication and
\ either this permission notice or a reference to
\ http://oss.sgi.com/projects/FreeB/
\ shall be included in all copies or substantial portions of the Software.
\ 
\ THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
\ OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
\ FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
\ SILICON GRAPHICS, INC. BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
\ WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
\ OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
\ SOFTWARE.
\ 
\ Except as contained in this notice, the name of Silicon Graphics, Inc.
\ shall not be used in advertising or otherwise to promote the sale, use or
\ other dealings in this Software without prior written authorization from
\ Silicon Graphics, Inc.
\
\
\ FORTH "Implementation/Wrapper?" Subliscence:
\ 
\ BSD 3-Clause License
\ 
\ Copyright (c) 2022, Christopher Stephen Rafuse (Fluffykins/Sanguine Night)
\ All rights reserved.
\ 
\ Redistribution and use in source and binary forms, with or without
\ modification, are permitted provided that the following conditions are met:
\ 
\ 1. Redistributions of source code must retain the above copyright notice, this
\    list of conditions and the following disclaimer.
\ 
\ 2. Redistributions in binary form must reproduce the above copyright notice,
\    this list of conditions and the following disclaimer in the documentation
\    and/or other materials provided with the distribution.
\ 
\ 3. Neither the name of the copyright holder nor the names of its
\    contributors may be used to endorse or promote products derived from
\    this software without specific prior written permission.
\ 
\ THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
\ AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
\ IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
\ DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
\ FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
\ DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
\ SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
\ CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
\ OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
\ OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
\ 

INCLUDE ./gl.fs

C-LIBRARY glu_lib
s" GLU" ADD-LIB

\c #if defined(__unix__) 

\c #if defined(__linux__) || defined(__FreeBSD__) || defined(__FreeBSD_kernel__)
\c #include <GL/glu.h>
\c #endif

\c #elif defined(__APPLE__) && defined(__MACH__)
\c #include <OpenGL/glu.h>

\c #endif

( Extensions )
1 CONSTANT GLU-EXT.object-space-tess
1 CONSTANT GLU-EXT.nurbs-tessellator

( Boolean )
GL-FALSE CONSTANT GLU-FALSE
GL-TRUE  CONSTANT GLU-TRUE

: GLU-TRUE? GLU-TRUE  = ;

( Version )
GLU-TRUE CONSTANT GLU-VERSION-1.1
GLU-TRUE CONSTANT GLU-VERSION-1.2
GLU-TRUE CONSTANT GLU-VERSION-1.3

( StringName )
100800 CONSTANT GLU-VERSION   
100801 CONSTANT GLU-EXTENSIONS

( ErrorCode )
100900 CONSTANT GLU-INVALID-ENUM           
100901 CONSTANT GLU-INVALID-VALUE          
100902 CONSTANT GLU-OUT-OF-MEMORY          
100903 CONSTANT GLU-INCOMPATIBLE-GL-VERSION
100904 CONSTANT GLU-INVALID-OPERATION      

( NurbsDisplay )
100240 CONSTANT GLU-OUTLINE-POLYGON
100241 CONSTANT GLU-OUTLINE-PATCH  

( NurbsCallback )
100103 CONSTANT GLU-NURBS-ERROR             
100103 CONSTANT GLU-ERROR                   
100164 CONSTANT GLU-NURBS-BEGIN             
100164 CONSTANT GLU-NURBS-BEGIN-EXT         
100165 CONSTANT GLU-NURBS-VERTEX            
100165 CONSTANT GLU-NURBS-VERTEX-EXT        
100166 CONSTANT GLU-NURBS-NORMAL            
100166 CONSTANT GLU-NURBS-NORMAL-EXT        
100167 CONSTANT GLU-NURBS-COLOR             
100167 CONSTANT GLU-NURBS-COLOR-EXT         
100168 CONSTANT GLU-NURBS-TEXTURE-COORD     
100168 CONSTANT GLU-NURBS-TEX-COORD-EXT     
100169 CONSTANT GLU-NURBS-END               
100169 CONSTANT GLU-NURBS-END-EXT           
100170 CONSTANT GLU-NURBS-BEGIN-DATA        
100170 CONSTANT GLU-NURBS-BEGIN-DATA-EXT    
100171 CONSTANT GLU-NURBS-VERTEX-DATA       
100171 CONSTANT GLU-NURBS-VERTEX-DATA-EXT   
100172 CONSTANT GLU-NURBS-NORMAL-DATA       
100172 CONSTANT GLU-NURBS-NORMAL-DATA-EXT   
100173 CONSTANT GLU-NURBS-COLOR-DATA        
100173 CONSTANT GLU-NURBS-COLOR-DATA-EXT    
100174 CONSTANT GLU-NURBS-TEXTURE-COORD-DATA
100174 CONSTANT GLU-NURBS-TEX-COORD-DATA-EXT
100175 CONSTANT GLU-NURBS-END-DATA          
100175 CONSTANT GLU-NURBS-END-DATA-EXT      

( NurbsError )
100251 CONSTANT GLU-NURBS-ERROR1 
100252 CONSTANT GLU-NURBS-ERROR2 
100253 CONSTANT GLU-NURBS-ERROR3 
100254 CONSTANT GLU-NURBS-ERROR4 
100255 CONSTANT GLU-NURBS-ERROR5 
100256 CONSTANT GLU-NURBS-ERROR6 
100257 CONSTANT GLU-NURBS-ERROR7 
100258 CONSTANT GLU-NURBS-ERROR8 
100259 CONSTANT GLU-NURBS-ERROR9 
100260 CONSTANT GLU-NURBS-ERROR10
100261 CONSTANT GLU-NURBS-ERROR11
100262 CONSTANT GLU-NURBS-ERROR12
100263 CONSTANT GLU-NURBS-ERROR13
100264 CONSTANT GLU-NURBS-ERROR14
100265 CONSTANT GLU-NURBS-ERROR15
100266 CONSTANT GLU-NURBS-ERROR16
100267 CONSTANT GLU-NURBS-ERROR17
100268 CONSTANT GLU-NURBS-ERROR18
100269 CONSTANT GLU-NURBS-ERROR19
100270 CONSTANT GLU-NURBS-ERROR20
100271 CONSTANT GLU-NURBS-ERROR21
100272 CONSTANT GLU-NURBS-ERROR22
100273 CONSTANT GLU-NURBS-ERROR23
100274 CONSTANT GLU-NURBS-ERROR24
100275 CONSTANT GLU-NURBS-ERROR25
100276 CONSTANT GLU-NURBS-ERROR26
100277 CONSTANT GLU-NURBS-ERROR27
100278 CONSTANT GLU-NURBS-ERROR28
100279 CONSTANT GLU-NURBS-ERROR29
100280 CONSTANT GLU-NURBS-ERROR30
100281 CONSTANT GLU-NURBS-ERROR31
100282 CONSTANT GLU-NURBS-ERROR32
100283 CONSTANT GLU-NURBS-ERROR33
100284 CONSTANT GLU-NURBS-ERROR34
100285 CONSTANT GLU-NURBS-ERROR35
100286 CONSTANT GLU-NURBS-ERROR36
100287 CONSTANT GLU-NURBS-ERROR37

( NurbsProperty )
100200 GLU-AUTO-LOAD-MATRIX     
100201 GLU-CULLING              
100203 GLU-SAMPLING-TOLERANCE   
100204 GLU-DISPLAY-MODE         
100202 GLU-PARAMETRIC-TOLERANCE 
100205 GLU-SAMPLING-METHOD      
100206 GLU-U-STEP               
100207 GLU-V-STEP               
100160 GLU-NURBS-MODE           
100160 GLU-NURBS-MODE-EXT       
100161 GLU-NURBS-TESSELLATOR    
100161 GLU-NURBS-TESSELLATOR-EXT
100162 GLU-NURBS-RENDERER       
100162 GLU-NURBS-RENDERER-EXT   

( NurbsSampling )
100208 GLU-OBJECT-PARAMETRIC-ERROR    
100208 GLU-OBJECT-PARAMETRIC-ERROR-EXT
100209 GLU-OBJECT-PATH-LENGTH         
100209 GLU-OBJECT-PATH-LENGTH-EXT     
100215 GLU-PATH-LENGTH                
100216 GLU-PARAMETRIC-ERROR           
100217 GLU-DOMAIN-DISTANCE            

( NurbsTrim )
100210 CONSTANT GLU-MAP1-TRIM-2                    
100211 CONSTANT GLU-MAP1-TRIM-3                    

( QuadricDrawStyle )
100010 CONSTANT GLU-POINT     
100011 CONSTANT GLU-LINE      
100012 CONSTANT GLU-FILL      
100013 CONSTANT GLU-SILHOUETTE

( QuadricCallback )
(        GLU-ERROR )

( QuadricNormal )
100000 CONSTANT GLU-SMOOTH
100001 CONSTANT GLU-FLAT  
100002 CONSTANT GLU-NONE  

( QuadricOrientation )
100020 CONSTANT GLU-OUTSIDE      
100021 CONSTANT GLU-INSIDE       

( TessCallback )
100100 CONSTANT GLU-TESS-BEGIN         
100100 CONSTANT GLU-BEGIN              
100101 CONSTANT GLU-TESS-VERTEX        
100101 CONSTANT GLU-VERTEX             
100102 CONSTANT GLU-TESS-END           
100102 CONSTANT GLU-END                
100103 CONSTANT GLU-TESS-ERROR         
100104 CONSTANT GLU-TESS-EDGE-FLAG     
100104 CONSTANT GLU-EDGE-FLAG          
100105 CONSTANT GLU-TESS-COMBINE       
100106 CONSTANT GLU-TESS-BEGIN-DATA    
100107 CONSTANT GLU-TESS-VERTEX-DATA   
100108 CONSTANT GLU-TESS-END-DATA      
100109 CONSTANT GLU-TESS-ERROR-DATA    
100110 CONSTANT GLU-TESS-EDGE-FLAG-DATA
100111 CONSTANT GLU-TESS-COMBINE-DATA  

( TessContour )
100120 CONSTANT GLU-CW      
100121 CONSTANT GLU-CCW     
100122 CONSTANT GLU-INTERIOR
100123 CONSTANT GLU-EXTERIOR
100124 CONSTANT GLU-UNKNOWN 

( TessProperty )
100140 CONSTANT GLU-TESS-WINDING-RULE 
100141 CONSTANT GLU-TESS-BOUNDARY-ONLY
100142 CONSTANT GLU-TESS-TOLERANCE    

( TessError )
100151 CONSTANT GLU-TESS-ERROR1               
100152 CONSTANT GLU-TESS-ERROR2               
100153 CONSTANT GLU-TESS-ERROR3               
100154 CONSTANT GLU-TESS-ERROR4               
100155 CONSTANT GLU-TESS-ERROR5               
100156 CONSTANT GLU-TESS-ERROR6               
100157 CONSTANT GLU-TESS-ERROR7               
100158 CONSTANT GLU-TESS-ERROR8               
100151 CONSTANT GLU-TESS-MISSING-BEGIN-POLYGON
100152 CONSTANT GLU-TESS-MISSING-BEGIN-CONTOUR
100153 CONSTANT GLU-TESS-MISSING-END-POLYGON  
100154 CONSTANT GLU-TESS-MISSING-END-CONTOUR  
100155 CONSTANT GLU-TESS-COORD-TOO-LARGE      
100156 CONSTANT GLU-TESS-NEED-COMBINE-CALLBACK

( TessWinding )
100130  CONSTANT  GLU-TESS-WINDING-ODD        
100131  CONSTANT  GLU-TESS-WINDING-NONZERO    
100132  CONSTANT  GLU-TESS-WINDING-POSITIVE   
100133  CONSTANT  GLU-TESS-WINDING-NEGATIVE   
100134  CONSTANT  GLU-TESS-WINDING-ABS-GEQ-TWO
1.0e150 FCONSTANT GLU-TESS-MAX-COORD

\ void gluBeginCurve (GLUnurbs* nurb);
C-FUNCTION gluBeginCurve            gluBeginCurve          a                     -- void

\ void gluBeginPolygon (GLUtesselator* tess);
C-FUNCTION gluBeginPolygon          gluBeginPolygon        a                     -- void

\ void gluBeginSurface (GLUnurbs* nurb);
C-FUNCTION gluBeginSurface          gluBeginSurface        a                     -- void

\ void gluBeginTrim (GLUnurbs* nurb);
C-FUNCTION gluBeginTrim             gluBeginTrim           a                     -- void

\ GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);
C-FUNCTION c-gluCheckExtension      gluCheckExtension      a a                   -- n

\ void gluCylinder (GLUquadric* quad, GLdouble base, GLdouble top, GLdouble height, GLint slices, GLint stacks);
C-FUNCTION c-gluCylinder            gluCylinder            a n n n n n           -- void

\ void gluDeleteNurbsRenderer (GLUnurbs* nurb);
C-FUNCTION gluDeleteNurbsRenderer   gluDeleteNurbsRenderer a                     -- void  

\ void gluDeleteQuadric (GLUquadric* quad);
C-FUNCTION gluDeleteQuadric         gluDeleteQuadric       a                     -- void 

\ void gluDeleteTess (GLUtesselator* tess);
C-FUNCTION gluDeleteTess            gluDeleteTess          a                     -- void 

\ void gluDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);
C-FUNCTION c-gluDisk                gluDisk                a r r n n             -- void

\ void gluEndCurve (GLUnurbs* nurb);
C-FUNCTION gluEndCurve              gluEndCurve            a                     -- void 

\ void gluEndPolygon (GLUtesselator* tess);
C-FUNCTION gluEndPolygon            gluEndPolygon          a                     -- void

\ void gluEndSurface (GLUnurbs* nurb);
C-FUNCTION gluEndSurface            gluEndSurface          a                     -- void

\ void gluEndTrim (GLUnurbs* nurb);
C-FUNCTION gluEndTrim               gluEndTrim             a                     -- void

\ const GLubyte * gluErrorString (GLenum error);
C-FUNCTION gluErrorString           gluErrorString         n                     -- a

\ void gluGetNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat* data);
C-FUNCTION gluGetNurbsProperty      gluGetNurbsProperty    a n a                 -- void

\ const GLubyte * gluGetString (GLenum name);
C-FUNCTION gluGetString             gluGetString           n                     -- a

\ void gluGetTessProperty (GLUtesselator* tess, GLenum which, GLdouble* data);
C-FUNCTION gluGetTessProperty       gluGetTessProperty     a n a                 -- void


\ void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);
C-FUNCTION gluGetSamplingMatrices  gluGetSamplingMatrices  a a a a               -- void

\ void gluLookAt (GLdouble eyeX, GLdouble eyeY, GLdouble eyeZ, GLdouble centerX, GLdouble centerY, GLdouble centerZ, GLdouble upX, GLdouble upY, GLdouble upZ);
C-FUNCTION gluLookAt               gluLookAt               r r r r r r r r r     -- void

\ GLUnurbs* gluNewNurbsRenderer (void);
C-FUNCTION gluNewNurbsRenderer     gluNewNurbsRenderer                           -- a

\ GLUquadric* gluNewQuadric (void);
C-FUNCTION gluNewQuadric           gluNewQuadric                                 -- a

\ GLUtesselator* gluNewTess (void);
C-FUNCTION gluNewTess              gluNewTess                                    -- a

\ void gluNextContour (GLUtesselator* tess, GLenum type);
C-FUNCTION gluNextContour          gluNextContour         a n                    -- void

\ void gluNurbsCallback (GLUnurbs* nurb, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluNurbsCallback        gluNurbsCallback       a n a                  -- void

\ void gluNurbsCallbackData (GLUnurbs* nurb, GLvoid* userData);
C-FUNCTION gluNurbsCallbackData    gluNurbsCallback       a a                    -- void

\ void gluNurbsCallbackDataEXT (GLUnurbs* nurb, GLvoid* userData);
C-FUNCTION gluNurbsCallbackDataEXT gluNurbsCallbackDataEXT a a                   -- void

\ void gluNurbsCurve (GLUnurbs* nurb, GLint knotCount, GLfloat *knots, GLint stride, GLfloat *control, GLint order, GLenum type);
C-FUNCTION gluNurbsCurve           gluNurbsCurve           a n a n a n n         -- void

\ void gluNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat value);
C-FUNCTION gluNurbsProperty        gluNurbsProperty        a n r                 -- void

\ void gluNurbsSurface (GLUnurbs* nurb, GLint sKnotCount, GLfloat* sKnots, GLint tKnotCount, GLfloat* tKnots, GLint sStride, GLint tStride, GLfloat* control, GLint sOrder, GLint tOrder, GLenum type);
C-FUNCTION gluNurbsSurface         gluNurbsSurface         a n a n a n n a n n n -- void

\ void gluOrtho2D (GLdouble left, GLdouble right, GLdouble bottom, GLdouble top);
C-FUNCTION gluOrtho2D              gluOrtho2D              r r r r               -- void

\ void gluPartialDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops, GLdouble start, GLdouble sweep);
C-FUNCTION gluPartialDisk          gluPartialDisk          a r r n n r r         -- void

\ void gluPerspective (GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar);
C-FUNCTION gluPerspective          gluPerspective          r r r r               -- void

\ void gluPickMatrix (GLdouble x, GLdouble y, GLdouble delX, GLdouble delY, GLint *viewport);
C-FUNCTION gluPickMatrix           gluPickMatrix           r r r r a             -- void

\ GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);
C-FUNCTION gluProject              gluProject              r r r a a a a a a     -- n

\ void gluPwlCurve (GLUnurbs* nurb, GLint count, GLfloat* data, GLint stride, GLenum type);
C-FUNCTION gluPwlCurve             gluPwlCurve             a n a n n             -- void

\ void gluQuadricCallback (GLUquadric* quad, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluQuadricCallback      gluQuadricCallback      a n a                 -- void

\ void gluQuadricDrawStyle (GLUquadric* quad, GLenum draw);
C-FUNCTION gluQuadricDrawStyle     gluQuadricDrawStyle     a n                   -- void

\ void gluQuadricNormals (GLUquadric* quad, GLenum normal);
C-FUNCTION gluQuadricNormals       gluQuadricNormals       a n                   -- void

\ void gluQuadricOrientation (GLUquadric* quad, GLenum orientation);
C-FUNCTION gluQuadricNormals       gluQuadric              a n                   -- void

\ void gluQuadricTexture (GLUquadric* quad, GLboolean texture);
C-FUNCTION gluQuadricTexture       gluQuadricTexture       a n                   -- void

\ GLint gluScaleImage (GLenum format, GLsizei wIn, GLsizei hIn, GLenum typeIn, const void *dataIn, GLsizei wOut, GLsizei hOut, GLenum typeOut, GLvoid* dataOut);
C-FUNCTION gluScaleImage           gluScaleImage           n n n n a n n n a     -- n

\ void gluSphere (GLUquadric* quad, GLdouble radius, GLint slices, GLint stacks);
C-FUNCTION gluSphere               gluSphere               a r n n               -- void

\ void gluTessBeginContour (GLUtesselator* tess);
C-FUNCTION gluTessBeginContour     gluTessBeginContour     a                     -- void

\ void gluTessBeginPolygon (GLUtesselator* tess, GLvoid* data);
C-FUNCTION gluTessBeginPolygon     gluTessBeginPolygon     a a                   -- void

\ void gluTessCallback (GLUtesselator* tess, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluTessCallback         gluTessCallback         a n a                 -- void

\ void gluTessEndContour (GLUtesselator* tess);
C-FUNCTION gluTessEndCountour      gluTessEndContour       a                     -- void

\ void gluTessEndPolygon (GLUtesselator* tess);
C-FUNCTION gluTessEndPolygon       gluTessEndPolygon       a                     -- void

\ void gluTessNormal (GLUtesselator* tess, GLdouble valueX, GLdouble valueY, GLdouble valueZ);
C-FUNCTION gluTessNormal           gluTessNormal           a r r r               -- void

\ void gluTessProperty (GLUtesselator* tess, GLenum which, GLdouble data);
C-FUNCTION gluTessProperty         gluTessProperty          a n r                -- void

\ void gluTessVertex (GLUtesselator* tess, GLdouble *location, GLvoid* data);
C-FUNCTION gluTessVectex           gluTessVertex            a a a                -- void

\ GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);
C-FUNCTION gluUnProject            gluUnProject             r r r a a a a a a a  -- void

\ GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearVal, GLdouble farVal, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);
C-FUNCTION gluProject4             gluProject4              r r r r a a a r r a a a a -- void

\ GLint gluBuild1DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
\ GLint gluBuild1DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, const void *data);
\ GLint gluBuild2DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
\ GLint gluBuild2DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, const void *data);
\ GLint gluBuild3DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
\ GLint gluBuild3DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const void *data);

END-C-LIBRARY a
