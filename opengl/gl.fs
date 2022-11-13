
\ gl.fs

\ This file is not a part of gforth or an official implementation of the Mesa 3-D graphics lib


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

C-LIBRARY gl
s" GL"   ADD-LIB

\c #if defined(__unix__) 

\c #if defined(__linux__) || defined(__FreeBSD__) || defined(__FreeBSD_kernel__)
\c #include <GL/gl.h>
\c #endif

\c #elif defined(__APPLE__) && defined(__MACH__)
\c #include <OpenGL/gl.h>

\c #endif

( 
    constants 
)

\ boolean values
0 CONSTANT GL-TRUE
1 CONSTANT GL-FALSE 

: GL-TRUE?  GL-TRUE  = ;


HEX
\ data sizes
4 CONSTANT GLenum 
1 CONSTANT GLbyte
1 CONSTANT GLboolean 
4 CONSTANT GLbitfield
2 CONSTANT GLshort
4 CONSTANT GLint
1 CONSTANT GLubyte
1 CONSTANT GLushort
4 CONSTANT GLuint
4 CONSTANT GLsizei 
8 CONSTANT GLfloat
8 CONSTANT GLdouble 
8 CONSTANT GLclampf 
8 CONSTANT GLclampd

\ data types

1400 CONSTANT GL-BYTE
1401 CONSTANT GL-UBYTE
1402 CONSTANT GL-SHORT
1403 CONSTANT GL-USHORT  
1404 CONSTANT GL-INT
1405 CONSTANT GL-UINT
1406 CONSTANT GL-FLOAT 
1407 CONSTANT GL-2BYTES
1408 CONSTANT GL-3BYTES
1409 CONSTANT GL-4BYTES
140A CONSTANT GL-DOUBLE

\ primitives
0000 CONSTANT GL-POINTS
0001 CONSTANT GL-LINES  
0002 CONSTANT GL-LINE-LOOP
0003 CONSTANT GL-LINE-STRIP 
0004 CONSTANT GL-TRIANGLES 
0005 CONSTANT GL-TRIANGLE-STRIP 
0006 CONSTANT GL-TRIANGLE-FAN 
0007 CONSTANT GL-QUADS 
0008 CONSTANT GL-QUAD-STRIP  
0009 CONSTANT GL-POLYGON

\ vertex arrays
8074 CONSTANT GL-VERTEX-ARRAY 
8075 CONSTANT GL-NORMAL-ARRAY
8076 CONSTANT GL-COLOR-ARRAY
8077 CONSTANT GL-INDEX-ARRAY 
8078 CONSTANT GL-TEXTEURE-COORD-ARRAY 
8079 CONSTANT GL-EDGE-FLAG-ARRAY 
807A CONSTANT GL-VERTEX-ARRAY-SIZE 
807B CONSTANT GL-VERTEX-ARRAY-TYPE 
807C CONSTANT GL-VERTEX-ARRAY-STRIDE
807E CONSTANT GL-NORMAL-ARRAY-TYPE 
807F CONSTANT GL-NORMAL-ARRAY-STRIDE
8081 CONSTANT GL-COLOR-ARRAY-SIZE 
8082 CONSTANT GL-COLOR-ARRAY-TYPE
8083 CONSTANT GL-COLOR-ARRAY-STRIDE 
8085 CONSTANT GL-INDEX-ARRAY-TYPE
8086 CONSTANT GL-INDEX-ARRAY-STRIDE 
8088 CONSTANT GL-TEXTURE-COORD-ARRAY-SIZE 
8089 CONSTANT GL-TEXTURE-COORD-ARRAY-TYPE 
808A CONSTANT GL-TEXTURE-COORD-ARRAY-STRIDE
808C CONSTANT GL-EDGE-FLAG-ARRAY-STRIDE 
808E CONSTANT GL-VERTEX-ARRAY-POINTER 
808F CONSTANT GL-NORMAL-ARRAY-POINTER 
8090 CONSTANT GL-COLOR-ARRAY-POINTER 
8091 CONSTANT GL-INDEX-ARRAY-POINTER 
8092 CONSTANT GL-TEXTURE-COORD-ARRAY-POINTER 
8093 CONSTANT GL-EDGE-FLAG-ARRAY-POINTER
2A20 CONSTANT GL-V2F 
2A21 CONSTANT GL-V3F
2A22 CONSTANT GL-C4UB-V2F 
2A23 CONSTANT GL-C4UB-V3F
2A24 CONSTANT GL-C3F-V3F
2A25 CONSTANT GL-N3F-V3F 
2A26 CONSTANT GL-C4F-N3F-V3F
2A27 CONSTANT GL-T2F-V3F 
2A28 CONSTANT GL-T4F-V3F
2A29 CONSTANT GL-T2F-C4UB-V3F 
2A2A CONSTANT GL-T2F-C3F-V3F 
2A2B CONSTANT GL-T2F-N3F-V3F
2A2C CONSTANT GL-T2F-C4F-N3F-V3F 
2A2D CONSTANT GL-T3F-C4F-N3F-V4F

\ matrix mode 
0BA0 CONSTANT GL-MATRIX-MODE
1700 CONSTANT GL-MODELVIEW
1701 CONSTANT GL-PROJECTION
1702 CONSTANT GL-TEXTURE

\ points
0B10 CONSTANT GL-POINT-SMOOTH
0B11 CONSTANT GL-POINT-SIZE 
0B13 CONSTANT GL-POINT-SIZE-GRANULARITY
0B12 CONSTANT GL-POINT-SIZE-RANGE

\ lines
0B20 CONSTANT GL-LINE-SMOOTH 
0B24 CONSTANT GL-LINE-STIPPLE
0B25 CONSTANT GL-LINE-STIPPLE-PATTERN 
0B26 CONSTANT GL-LINE-STIPPLE-REPEAT
0B21 CONSTANT GL-LINE-WIDTH
0B23 CONSTANT GL-LINE-WIDTH-GRANULARITY 
0B22 CONSTANT GL-LINE-WIDTH-RANGE

\ polygons
1B00 CONSTANT GL-POINT 
1B01 CONSTANT GL-LINE
1B02 CONSTANT GL-FILL 
0900 CONSTANT GL-CW
0901 CONSTANT GL-CCW
0404 CONSTANT GL-FRONT
0405 CONSTANT GL-BACK
0B40 CONSTANT GL-POLYGON-MODE 
0B41 CONSTANT GL-POLYGON-SMOOTH 
0B42 CONSTANT GL-POLYGON-STIPPLE
0B43 CONSTANT GL-EDGE-FLAG 
0B44 CONSTANT GL-CULL-FACE
0B45 CONSTANT GL-CULL-FACE-MODE 
0B46 CONSTANT GL-FRONT-FACE 
8038 CONSTANT GL-POLYGON-OFFSET-FACTOR
2A00 CONSTANT GL-POLYGON-OFFSET-UNITS
2A01 CONSTANT GL-POLYGON-OFFSET-POINT 
2A02 CONSTANT GL-POLYGON-OFFSET-LINE 
8037 CONSTANT GL-POLYGON-OFFSET-FILL

\ display lists
1300 CONSTANT GL-COMPILE				
1301 CONSTANT GL-COMPILE-AND-EXECUTE	
0B32 CONSTANT GL-LIST-BASE			
0B33 CONSTANT GL-LIST-INDEX			
0B30 CONSTANT GL-LIST-MODE

\ depth buffer
0200 CONSTANT GL-NEVER			
0201 CONSTANT GL-LESS				
0202 CONSTANT GL-EQUAL			
0203 CONSTANT GL-LEQUAL			
0204 CONSTANT GL-GREATER			
0205 CONSTANT GL-NOTEQUAL			
0206 CONSTANT GL-GEQUAL			
0207 CONSTANT GL-ALWAYS			
0B71 CONSTANT GL-DEPTH-TEST		
0D56 CONSTANT GL-DEPTH-BITS		
0B73 CONSTANT GL-DEPTH-CLEAR-VALUE
0B74 CONSTANT GL-DEPTH-FUNC		
0B70 CONSTANT GL-DEPTH-RANGE		
0B72 CONSTANT GL-DEPTH-WRITEMASK	
1902 CONSTANT GL-DEPTH-COMPONENT

\ lighting
0B50 CONSTANT GL-LIGHTING				      
4000 CONSTANT GL-LIGHT0				      
4001 CONSTANT GL-LIGHT1				      
4002 CONSTANT GL-LIGHT2				      
4003 CONSTANT GL-LIGHT3				      
4004 CONSTANT GL-LIGHT4				      
4005 CONSTANT GL-LIGHT5				      
4006 CONSTANT GL-LIGHT6				      
4007 CONSTANT GL-LIGHT7				      
1205 CONSTANT GL-SPOT-EXPONENT		      
1206 CONSTANT GL-SPOT-CUTOFF			      
12   CONSTANT GL-CONSTANT-ATTENUATION	      
12   CONSTANT GL-LINEAR-ATTENUATION	      
12   CONSTANT GL-QUADRATIC-ATTENUATION      
1200 CONSTANT GL-AMBIENT				      
1201 CONSTANT GL-DIFFUSE				      
1202 CONSTANT GL-SPECULAR				      
1601 CONSTANT GL-SHININESS			      
1600 CONSTANT GL-EMISSION				      
1203 CONSTANT GL-POSITION				      
1204 CONSTANT GL-SPOT-DIRECTION		      
16   CONSTANT GL-AMBIENT-AND-DIFFUSE	      
1603 CONSTANT GL-COLOR-INDEXES		      
0B   CONSTANT GL-LIGHT-MODEL-TWO-SIDE	
0B   CONSTANT GL-LIGHT-MODEL-LOCAL-VIEWER
0B   CONSTANT GL-LIGHT-MODEL-AMBIENT	
0408 CONSTANT GL-FRONT-AND-BACK			  
0B54 CONSTANT GL-SHADE-MODEL				  
1D00 CONSTANT GL-FLAT					      
1D01 CONSTANT GL-SMOOTH				      
0B57 CONSTANT GL-COLOR-MATERIAL			  
0B   CONSTANT GL-COLOR-MATERIAL-FACE	
0B   CONSTANT GL-COLOR-MATERIAL-PARAMETER
0BA1 CONSTANT GL-NORMALIZE				  

\ user clipping panes
3000 CONSTANT GL-CLIP-PLANE0
3001 CONSTANT GL-CLIP-PLANE1
3002 CONSTANT GL-CLIP-PLANE2
3003 CONSTANT GL-CLIP-PLANE3
3004 CONSTANT GL-CLIP-PLANE4
3005 CONSTANT GL-CLIP-PLANE5

\ accumulation buffer
0D58 CONSTANT GL-ACCUM-RED-BITS		 
0D59 CONSTANT GL-ACCUM-GREEN-BITS		 
0D5A CONSTANT GL-ACCUM-BLUE-BITS		 
0D5B CONSTANT GL-ACCUM-ALPHA-BITS		 
0B80 CONSTANT GL-ACCUM-CLEAR-VALUE	 
0100 CONSTANT GL-ACCUM				 
0104 CONSTANT GL-ADD					 
0101 CONSTANT GL-LOAD					 
0103 CONSTANT GL-MULT					 
0102 CONSTANT GL-RETURN				 

\ alpha testing
0BC0 CONSTANT GL-ALPHA-TEST
0BC2 CONSTANT GL-ALPHA-TEST-REF
0BC1 CONSTANT GL-ALPHA-TEST-FUNC

\ blending
0BE2 CONSTANT GL-BLEND				
0BE1 CONSTANT GL-BLEND-SRC			
0BE0 CONSTANT GL-BLEND-DST			
0000 CONSTANT GL-ZERO					
0001 CONSTANT GL-ONE					
0300 CONSTANT GL-SRC-COLOR			
0301 CONSTANT GL-ONE-MINUS-SRC-COLOR	
0302 CONSTANT GL-SRC-ALPHA			
0303 CONSTANT GL-ONE-MINUS-SRC-ALPHA	
0304 CONSTANT GL-DST-ALPHA			
0305 CONSTANT GL-ONE-MINUS-DST-ALPHA	
0306 CONSTANT GL-DST-COLOR			
0307 CONSTANT GL-ONE-MINUS-DST-COLOR	
0308 CONSTANT GL-SRC-ALPHA-SATURATE	

\ render mode
1C01 CONSTANT GL-FEEDBACK	
1C00 CONSTANT GL-RENDER	
1C02 CONSTANT GL-SELECT	

\ feedback
0600 CONSTANT GL-2D					    
0601 CONSTANT GL-3D					    
0602 CONSTANT GL-3D-COLOR				    
0603 CONSTANT GL-3D-COLOR-TEXTURE			
0604 CONSTANT GL-4D-COLOR-TEXTURE			
0701 CONSTANT GL-POINT-TOKEN				
0702 CONSTANT GL-LINE-TOKEN				
0707 CONSTANT GL-LINE-RESET-TOKEN			
0703 CONSTANT GL-POLYGON-TOKEN			
0704 CONSTANT GL-BITMAP-TOKEN				
0705 CONSTANT GL-DRAW-PIXEL-TOKEN			
0706 CONSTANT GL-COPY-PIXEL-TOKEN			
0700 CONSTANT GL-PASS-THROUGH-TOKEN		
0DF0 CONSTANT GL-FEEDBACK-BUFFER-POINTER	
0DF1 CONSTANT GL-FEEDBACK-BUFFER-SIZE		
0DF2 CONSTANT GL-FEEDBACK-BUFFER-TYPE		

\ selection 
0DF3 CONSTANT GL-SELECTION-BUFFER-POINTER	
0DF4 CONSTANT GL-SELECTION-BUFFER-SIZE	

\ fog
0B60 CONSTANT GL-FOG			
0B65 CONSTANT GL-FOG-MODE		
0B62 CONSTANT GL-FOG-DENSITY	
0B66 CONSTANT GL-FOG-COLOR	
0B61 CONSTANT GL-FOG-INDEX	
0B63 CONSTANT GL-FOG-START	
0B64 CONSTANT GL-FOG-END		
2601 CONSTANT GL-LINEAR		
0800 CONSTANT GL-EXP			
0801 CONSTANT GL-EXP2

\ logic ops
0BF1 CONSTANT GL-LOGIC-OP		
0BF1 CONSTANT GL-INDEX-LOGIC-OP
0BF2 CONSTANT GL-COLOR-LOGIC-OP
0BF0 CONSTANT GL-LOGIC-OP-MODE
1500 CONSTANT GL-CLEAR		
150F CONSTANT GL-SET			
1503 CONSTANT GL-COPY			
150C CONSTANT GL-COPY-INVERTED
1505 CONSTANT GL-NOOP			
150A CONSTANT GL-INVERT		
1501 CONSTANT GL-AND			
150E CONSTANT GL-NAND			
1507 CONSTANT GL-OR			
1508 CONSTANT GL-NOR			
1506 CONSTANT GL-XOR			
1509 CONSTANT GL-EQUIV		
1502 CONSTANT GL-AND-REVERSE	
1504 CONSTANT GL-AND-INVERTED	
150B CONSTANT GL-OR-REVERSE	
150D CONSTANT GL-OR-INVERTED	

0D57 CONSTANT GL-STENCIL-BITS				
0B90 CONSTANT GL-STENCIL-TEST				
0B91 CONSTANT GL-STENCIL-CLEAR-VALUE		
0B92 CONSTANT GL-STENCIL-FUNC				
0B93 CONSTANT GL-STENCIL-VALUE-MASK		
0B94 CONSTANT GL-STENCIL-FAIL				
0B95 CONSTANT GL-STENCIL-PASS-DEPTH-FAIL	
0B96 CONSTANT GL-STENCIL-PASS-DEPTH-PASS	
0B97 CONSTANT GL-STENCIL-REF				
0B98 CONSTANT GL-STENCIL-WRITEMASK		
1901 CONSTANT GL-STENCIL-INDEX			
1E00 CONSTANT GL-KEEP					    
1E01 CONSTANT GL-REPLACE				    
1E02 CONSTANT GL-INCR					    
1E03 CONSTANT GL-DECR					    

\ buffers, pixel drawing/reading 
0000 CONSTANT GL-NONE					
0406 CONSTANT GL-LEFT					
0407 CONSTANT GL-RIGHT
0400 CONSTANT GL-FRONT-LEFT	
0401 CONSTANT GL-FRONT-RIGHT	
0402 CONSTANT GL-BACK-LEFT	
0403 CONSTANT GL-BACK-RIGHT	
0409 CONSTANT GL-AUX0			
040A CONSTANT GL-AUX1			
040B CONSTANT GL-AUX2			
040C CONSTANT GL-AUX3			
1900 CONSTANT GL-COLOR-INDEX	
1903 CONSTANT GL-RED			
1904 CONSTANT GL-GREEN		
1905 CONSTANT GL-BLUE			
1906 CONSTANT GL-ALPHA		
1909 CONSTANT GL-LUMINANCE	
190A CONSTANT GL-LUMINANCE-ALPHA
0D55 CONSTANT GL-ALPHA-BITS	
0D52 CONSTANT GL-RED-BITS		
0D53 CONSTANT GL-GREEN-BITS	
0D54 CONSTANT GL-BLUE-BITS	
0D51 CONSTANT GL-INDEX-BITS	
0D50 CONSTANT GL-SUBPIXEL-BITS
0C00 CONSTANT GL-AUX-BUFFERS	
0C02 CONSTANT GL-READ-BUFFER	
0C01 CONSTANT GL-DRAW-BUFFER	
0C32 CONSTANT GL-DOUBLEBUFFER	
0C33 CONSTANT GL-STEREO		
1A00 CONSTANT GL-BITMAP		
1800 CONSTANT GL-COLOR		
1801 CONSTANT GL-DEPTH		
1802 CONSTANT GL-STENCIL		
0BD0 CONSTANT GL-DITHER		
1907 CONSTANT GL-RGB			
1908 CONSTANT GL-RGBA			

\ implementation limits
0B31 CONSTANT GL-MAX-LIST-NESTING			    
0D30 CONSTANT GL-MAX-EVAL-ORDER			    
0D31 CONSTANT GL-MAX-LIGHTS				    
0D32 CONSTANT GL-MAX-CLIP-PLANES			    
0D33 CONSTANT GL-MAX-TEXTURE-SIZE			    
0D34 CONSTANT GL-MAX-PIXEL-MAP-TABLE			
0D35 CONSTANT GL-MAX-ATTRIB-STACK-DEPTH		
0D36 CONSTANT GL-MAX-MODELVIEW-STACK-DEPTH    
0D37 CONSTANT GL-MAX-NAME-STACK-DEPTH			
0D38 CONSTANT GL-MAX-PROJECTION-STACK-DEPTH	
0D39 CONSTANT GL-MAX-TEXTURE-STACK-DEPTH		
0D3A CONSTANT GL-MAX-VIEWPORT-DIMS			
0D3B CONSTANT GL-MAX-CLIENT-ATTRIB-STACK-DEPTH

\ gets
0BB0 CONSTANT GL-ATTRIB-STACK-DEPTH			 
0BB1 CONSTANT GL-CLIENT-ATTRIB-STACK-DEPTH	 
0C22 CONSTANT GL-COLOR-CLEAR-VALUE			 
0C23 CONSTANT GL-COLOR-WRITEMASK			     
0B01 CONSTANT GL-CURRENT-INDEX			     
0B00 CONSTANT GL-CURRENT-COLOR			     
0B02 CONSTANT GL-CURRENT-NORMAL			     
0B04 CONSTANT GL-CURRENT-RASTER-COLOR			 
0B09 CONSTANT GL-CURRENT-RASTER-DISTANCE		 
0B05 CONSTANT GL-CURRENT-RASTER-INDEX			 
0B07 CONSTANT GL-CURRENT-RASTER-POSITION		 
0B06 CONSTANT GL-CURRENT-RASTER-TEXTURE-COORDS 
0B08 CONSTANT GL-CURRENT-RASTER-POSITION-VALID 
0B03 CONSTANT GL-CURRENT-TEXTURE-COORDS		 
0C20 CONSTANT GL-INDEX-CLEAR-VALUE			 
0C30 CONSTANT GL-INDEX-MODE				     
0C21 CONSTANT GL-INDEX-WRITEMASK			     
0BA6 CONSTANT GL-MODELVIEW-MATRIX			     
0BA3 CONSTANT GL-MODELVIEW-STACK-DEPTH		 
0D70 CONSTANT GL-NAME-STACK-DEPTH			     
0BA7 CONSTANT GL-PROJECTION-MATRIX			 
0BA4 CONSTANT GL-PROJECTION-STACK-DEPTH		 
0C40 CONSTANT GL-RENDER-MODE				     
0C31 CONSTANT GL-RGBA-MODE				     
0BA8 CONSTANT GL-TEXTURE-MATRIX			     
0BA5 CONSTANT GL-TEXTURE-STACK-DEPTH			 
0BA2 CONSTANT GL-VIEWPORT

\hints
0C50 CONSTANT GL-PERSPECTIVE-CORRECTION-HINT
0C51 CONSTANT GL-POINT-SMOOTH-HINT
0C52 CONSTANT GL-LINE-SMOOTH-HINT	
0C53 CONSTANT GL-POLYGON-SMOOTH-HINT
0C54 CONSTANT GL-FOG-HINT			
1100 CONSTANT GL-DONT-CARE		
1101 CONSTANT GL-FASTEST			
1102 CONSTANT GL-NICEST			

\ scissor box
0C10 CONSTANT GL-SCISSOR-BOX
0C11 CONSTANT GL-SCISSOR-TEST

\ pixel mode / transfer
0D10 CONSTANT GL-MAP-COLOR				
0D11 CONSTANT GL-MAP-STENCIL				
0D12 CONSTANT GL-INDEX-SHIFT				
0D13 CONSTANT GL-INDEX-OFFSET				
0D14 CONSTANT GL-RED-SCALE				
0D15 CONSTANT GL-RED-BIAS				    
0D18 CONSTANT GL-GREEN-SCALE				
0D19 CONSTANT GL-GREEN-BIAS				
0D1A CONSTANT GL-BLUE-SCALE				
0D1B CONSTANT GL-BLUE-BIAS				
0D1C CONSTANT GL-ALPHA-SCALE				
0D1D CONSTANT GL-ALPHA-BIAS				
0D1E CONSTANT GL-DEPTH-SCALE				
0D1F CONSTANT GL-DEPTH-BIAS				
0CB1 CONSTANT GL-PIXEL-MAP-S-TO-S-SIZE	
0CB0 CONSTANT GL-PIXEL-MAP-I-TO-I-SIZE	
0CB2 CONSTANT GL-PIXEL-MAP-I-TO-R-SIZE	
0CB3 CONSTANT GL-PIXEL-MAP-I-TO-G-SIZE	
0CB4 CONSTANT GL-PIXEL-MAP-I-TO-B-SIZE	
0CB5 CONSTANT GL-PIXEL-MAP-I-TO-A-SIZE	
0CB6 CONSTANT GL-PIXEL-MAP-R-TO-R-SIZE	
0CB7 CONSTANT GL-PIXEL-MAP-G-TO-G-SIZE	
0CB8 CONSTANT GL-PIXEL-MAP-B-TO-B-SIZE	
0CB9 CONSTANT GL-PIXEL-MAP-A-TO-A-SIZE	
0C71 CONSTANT GL-PIXEL-MAP-S-TO-S			
0C70 CONSTANT GL-PIXEL-MAP-I-TO-I			
0C72 CONSTANT GL-PIXEL-MAP-I-TO-R			
0C73 CONSTANT GL-PIXEL-MAP-I-TO-G			
0C74 CONSTANT GL-PIXEL-MAP-I-TO-B			
0C75 CONSTANT GL-PIXEL-MAP-I-TO-A			
0C76 CONSTANT GL-PIXEL-MAP-R-TO-R			
0C77 CONSTANT GL-PIXEL-MAP-G-TO-G			
0C78 CONSTANT GL-PIXEL-MAP-B-TO-B			
0C79 CONSTANT GL-PIXEL-MAP-A-TO-A			
0D05 CONSTANT GL-PACK-ALIGNMENT			
0D01 CONSTANT GL-PACK-LSB-FIRST			
0D02 CONSTANT GL-PACK-ROW-LENGTH			
0D04 CONSTANT GL-PACK-SKIP-PIXELS			
0D03 CONSTANT GL-PACK-SKIP-ROWS			
0D00 CONSTANT GL-PACK-SWAP-BYTES			
0CF5 CONSTANT GL-UNPACK-ALIGNMENT			
0CF1 CONSTANT GL-UNPACK-LSB-FIRST			
0CF2 CONSTANT GL-UNPACK-ROW-LENGTH		
0CF4 CONSTANT GL-UNPACK-SKIP-PIXELS		
0CF3 CONSTANT GL-UNPACK-SKIP-ROWS			
0CF0 CONSTANT GL-UNPACK-SWAP-BYTES		
0D16 CONSTANT GL-ZOOM-X				    
0D17 CONSTANT GL-ZOOM-Y				    

2300 CONSTANT GL-TEXTURE-ENV			
2200 CONSTANT GL-TEXTURE-ENV-MODE		
0DE0 CONSTANT GL-TEXTURE-1D			
0DE1 CONSTANT GL-TEXTURE-2D			
2802 CONSTANT GL-TEXTURE-WRAP-S		
2803 CONSTANT GL-TEXTURE-WRAP-T		
2800 CONSTANT GL-TEXTURE-MAG-FILTER	
2801 CONSTANT GL-TEXTURE-MIN-FILTER	
2201 CONSTANT GL-TEXTURE-ENV-COLOR	
0C60 CONSTANT GL-TEXTURE-GEN-S		
0C61 CONSTANT GL-TEXTURE-GEN-T		
0C62 CONSTANT GL-TEXTURE-GEN-R		
0C63 CONSTANT GL-TEXTURE-GEN-Q		
2500 CONSTANT GL-TEXTURE-GEN-MODE		
1004 CONSTANT GL-TEXTURE-BORDER-COLOR	
1000 CONSTANT GL-TEXTURE-WIDTH		
1001 CONSTANT GL-TEXTURE-HEIGHT		
1005 CONSTANT GL-TEXTURE-BORDER		
1003 CONSTANT GL-TEXTURE-COMPONENTS	
805C CONSTANT GL-TEXTURE-RED-SIZE		
805D CONSTANT GL-TEXTURE-GREEN-SIZE	
805E CONSTANT GL-TEXTURE-BLUE-SIZE	
805F CONSTANT GL-TEXTURE-ALPHA-SIZE	
8060 CONSTANT GL-TEXTURE-LUMINANCE-SIZE
8061 CONSTANT GL-TEXTURE-INTENSITY-SIZE
2700 CONSTANT GL-NEAREST-MIPMAP-NEAREST
2702 CONSTANT GL-NEAREST-MIPMAP-LINEAR
2701 CONSTANT GL-LINEAR-MIPMAP-NEAREST
2703 CONSTANT GL-LINEAR-MIPMAP-LINEAR	
2401 CONSTANT GL-OBJECT-LINEAR		
2501 CONSTANT GL-OBJECT-PLANE			
2400 CONSTANT GL-EYE-LINEAR			
2502 CONSTANT GL-EYE-PLANE			
2402 CONSTANT GL-SPHERE-MAP			
2101 CONSTANT GL-DECAL				   
2100 CONSTANT GL-MODULATE				   
2600 CONSTANT GL-NEAREST				   
2901 CONSTANT GL-REPEAT				   
2900 CONSTANT GL-CLAMP				   
2000 CONSTANT GL-S					   
2001 CONSTANT GL-T					   
2002 CONSTANT GL-R					   
2003 CONSTANT GL-Q 

\
\   Utility
\
1F00 CONSTANT GL-VENDOR				
1F01 CONSTANT GL-RENDERER				
1F02 CONSTANT GL-VERSION				
1F03 CONSTANT GL-EXTENSIONS		    

\ 
\   Errors
\
0000 CONSTANT GL-NO-ERROR 		
0500 CONSTANT GL-INVALID-ENUM		
0501 CONSTANT GL-INVALID-VALUE	
0502 CONSTANT GL-INVALID-OPERATION 
0503 CONSTANT GL-STACK-OVERFLOW	
0504 CONSTANT GL-STACK-UNDERFLOW	
0505 CONSTANT GL-OUT-OF-MEMORY	

\
\   glPush/PopAttrib bits
\
00000001 CONSTANT GL-CURRENT-BIT				
00000002 CONSTANT GL-POINT-BIT				
00000004 CONSTANT GL-LINE-BIT				    
00000008 CONSTANT GL-POLYGON-BIT				
00000010 CONSTANT GL-POLYGON-STIPPLE-BIT		
00000020 CONSTANT GL-PIXEL-MODE-BIT			
00000040 CONSTANT GL-LIGHTING-BIT				
00000080 CONSTANT GL-FOG-BIT				    
00000100 CONSTANT GL-DEPTH-BUFFER-BIT			
00000200 CONSTANT GL-ACCUM-BUFFER-BIT			
00000400 CONSTANT GL-STENCIL-BUFFER-BIT		
00000800 CONSTANT GL-VIEWPORT-BIT				
00001000 CONSTANT GL-TRANSFORM-BIT			
00002000 CONSTANT GL-ENABLE-BIT				
00004000 CONSTANT GL-COLOR-BUFFER-BIT			
00008000 CONSTANT GL-HINT-BIT				    
00010000 CONSTANT GL-EVAL-BIT				    
00020000 CONSTANT GL-LIST-BIT				    
00040000 CONSTANT GL-TEXTURE-BIT				
00080000 CONSTANT GL-SCISSOR-BIT				
FFFFFFFF CONSTANT GL-ALL-ATTRIB-BITS

( 
    OpenGL 1.1
)

8063 CONSTANT GL-PROXY-TEXTURE-1D			
8064 CONSTANT GL-PROXY-TEXTURE-2D			
8066 CONSTANT GL-TEXTURE-PRIORITY			
8067 CONSTANT GL-TEXTURE-RESIDENT			
8068 CONSTANT GL-TEXTURE-BINDING-1D		
8069 CONSTANT GL-TEXTURE-BINDING-2D		
1003 CONSTANT GL-TEXTURE-INTERNAL-FORMAT	
803B CONSTANT GL-ALPHA4				    
803C CONSTANT GL-ALPHA8				    
803D CONSTANT GL-ALPHA12				    
803E CONSTANT GL-ALPHA16				    
803F CONSTANT GL-LUMINANCE4				
8040 CONSTANT GL-LUMINANCE8				
8041 CONSTANT GL-LUMINANCE12				
8042 CONSTANT GL-LUMINANCE16				
8043 CONSTANT GL-LUMINANCE4-ALPHA4		
8044 CONSTANT GL-LUMINANCE6-ALPHA2		
8045 CONSTANT GL-LUMINANCE8-ALPHA8		
8046 CONSTANT GL-LUMINANCE12-ALPHA4		
8047 CONSTANT GL-LUMINANCE12-ALPHA12		
8048 CONSTANT GL-LUMINANCE16-ALPHA16		
8049 CONSTANT GL-INTENSITY				
804A CONSTANT GL-INTENSITY4				
804B CONSTANT GL-INTENSITY8				
804C CONSTANT GL-INTENSITY12				
804D CONSTANT GL-INTENSITY16				
2A10 CONSTANT GL-R3-G3-B2				    
804F CONSTANT GL-RGB4					    
8050 CONSTANT GL-RGB5					    
8051 CONSTANT GL-RGB8					    
8052 CONSTANT GL-RGB10				    
8053 CONSTANT GL-RGB12				    
8054 CONSTANT GL-RGB16				    
8055 CONSTANT GL-RGBA2				    
8056 CONSTANT GL-RGBA4				    
8057 CONSTANT GL-RGB5-A1				    
8058 CONSTANT GL-RGBA8				    
8059 CONSTANT GL-RGB10-A2				    
805A CONSTANT GL-RGBA12				    
805B CONSTANT GL-RGBA16

00000001 CONSTANT GL-CLIENT-PIXEL-STORE-BIT
00000002 CONSTANT GL-CLIENT-VERTEX-ARRAY-BIT
FFFFFFFF CONSTANT GL-ALL-CLIENT-ATTRIB-BITS 
FFFFFFFF CONSTANT GL-CLIENT-ALL-ATTRIB-BITS

DECIMAL

: GLbytes     ( n -- n )
    GLbyte * ;

: GLshorts    ( n -- n )
    GLshort * ;

: GLenums     ( n -- n )
    GLenum * ;

: GLints      ( n -- n )
    GLint * ;

: GLubytes      ( n -- n )
    GLubytes * ;

: GLushorts      ( n -- n )
    GLushorts * ;

: GLints      ( n -- n )
    GLint * ;

: GLbooleans  ( n -- n )
    GLboolean * ;

: GLbitfields ( n -- n )
    GLbitfield * ;

: GLsizes     ( n -- n )
    GLsizei * ;

: GLfloats    ( n -- n )
    GLfloat * ;

: GLdoubles   ( n -- n )
    GLdouble * ;

: GLclampfs   ( n -- n )
    GLclampf * ;

: GLclampds   ( n -- n )
    GLclampd * ;

( 
    Miscellaneous 
)

\ void glClear(int);
C-FUNCTION glClear              glClear              n       -- void

\ void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
C-FUNCTION glClearAccum         glClearAccum         r r r r -- void

\ void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
C-FUNCTION glClearColor         glClearColor         r r r r -- void

\ void glIndexMask(GLuint mask);
C-FUNCTION glIndexMask          glIndexMask          n       -- void

\ void glAlphaFunc(GLenum func, GLclampf ref);
C-FUNCTION glAlphaFunc          glAlphaFunc          n r     -- void

\ void glBlendFunc(GLenum sfactor, GLenum dfactor);
C-FUNCTION glBlendFunc          glBlendFunc          n n     -- void

\ void glLogicOp(GLenum opcode);
C-FUNCTION glLogicOp            glLogicOp            n       -- void

\ void glCullFace( GLenum mode );
C-FUNCTION glCullFace           glCullFace           n       -- void

\ void glFrontFace( GLenum mode );
C-FUNCTION glFrontFace          glFrontFace          n       -- void

\ void glPointSize( GLfloat size );
C-FUNCTION glPointSize          glPointSize          r       -- void

\ void glLineWidth( GLfloat width );
C-FUNCTION glLineWidth          glLineWidth          r       -- void

\ void glLineStipple( GLint factor, GLushort pattern );
C-FUNCTION glLineStipple        glLineStipple        n n     -- void

\ void glPolygonMode( GLenum face, GLenum mode );
C-FUNCTION glPolygonMode        glPolygonMode        n n     -- void

\ void glPolygonOffset( GLfloat factor, GLfloat units );
C-FUNCTION glPolygonOffset      glPolygonOffset      r r     -- void

\ void glPolygonStipple( const GLubyte *mask );
C-FUNCTION glPolygonStipple     glPolygonStipple     a       -- void

\ void glGetPolygonStipple( GLubyte *mask );
C-FUNCTION glGetPolygonStipple  glGetPolygonStipple  a       -- void

\ void glEdgeFlag( GLboolean flag );
C-FUNCTION glGetEdgeFlag        glGetEdgeFlag        n       -- void

\ void glEdgeFlagv( const GLboolean *flag );
C-FUNCTION glEdgeFlagv          glEdgeFlagv          a       -- void

\ void glScissor( GLint x, GLint y, GLsizei width, GLsizei height);
C-FUNCTION glScissor            glScissor            n n n n  -- void 

\ void glClipPlane( GLenum plane, const GLdouble *equation );
C-FUNCTION glClipPlane          glClipPlane          n a      -- void 

\ void glGetClipPlane( GLenum plane, GLdouble *equation );
C-FUNCTION glGetClipPlane       glGetClipPlane       n a      -- void

\ void glDrawBuffer( GLenum mode );
C-FUNCTION glDrawBuffer         glDrawBuffer         n        -- void

\ void glReadBuffer( GLenum mode );
C-FUNCTION glReadBuffer         glReadBuffer         n        -- void

\ void glEnable( GLenum cap );
C-FUNCTION glEnable             glEnable             n        -- void

\ void glDisable( GLenum cap );
C-FUNCTION glDisable            glDisable            n        -- void

\ GLboolean  glIsEnabled( GLenum cap );
C-FUNCTION glEnabeld?           glIsEnabled          n        -- n


\ void glEnableClientState( GLenum cap );  /* 1.1 */
C-FUNCTION glEnableClientState  glEnableClientState  n        -- void  

\ void glDisableClientState( GLenum cap );  /* 1.1 */
C-FUNCTION glDisableClientState glDisableClientState n        -- void


\ void glGetBooleanv( GLenum pname, GLboolean *params );
C-FUNCTION glGetBooleanv        glGetBooleanv        n a      -- void

\ void glGetDoublev( GLenum pname, GLdouble *params );
C-FUNCTION glGetDoublev         glGetDoublev         n a      -- void
 
\ void glGetFloatv( GLenum pname, GLfloat *params );
C-FUNCTION glGetFloatv          glGetFloatv          n a      -- void
 
\ void glGetIntegerv( GLenum pname, GLint *params );
C-FUNCTION glGetIntegerv        glGetIntegerv        n a      -- void


\ void glPushAttrib( GLbitfield mask );
C-FUNCTION glPushAttrib         glPushAttrib         n        -- void
 
\ void glPopAttrib( void );
C-FUNCTION glPopAttrib          glPopAttrib                   -- void
 
 
\ void glPushClientAttrib( GLbitfield mask );  /* 1.1 */
C-FUNCTION glPushClientAttrib   glPushClientAttrib   n        -- void
 
\ void glPopClientAttrib( void );  /* 1.1 */
C-FUNCTION glPopClientAttrib    glPopClientAttrib    n        -- void
 
 
\ GLint glRenderMode( GLenum mode );
C-FUNCTION glRenderMode         glRenderMode         n        -- n
 
\ GLenum glGetError( void );
C-FUNCTION glGetError           glGetError                    -- n
 
\ const GLubyte * glGetString( GLenum name );
C-FUNCTION glGetString          glGetString          n        -- a
 
\ void glFinish( void );
C-FUNCTION glFinish             glFinish                      -- void
 
\ void glFlush( void );
C-FUNCTION glFlush              glFlush                       -- void
 
\ void glHint( GLenum target, GLenum mode );
C-FUNCTION glHint               glHint               n n      -- void


( 
    Depth Buffer 
)

\ void glClearDepth( GLclampd depth );
C-FUNCTION glClearDepth         glClearDepth        r         -- void

\ void glDepthFunc( GLenum func );
C-FUNCTION glDepthFunc          glDepthFunc         n         -- void

\ void glDepthMask( GLboolean flag );
C-FUNCTION glDepthMask          glDepthMask         n         -- void

\ void glDepthRange( GLclampd near_val, GLclampd far_val );
C-FUNCTION glDepthRange         glDepthRange        r r       -- void


( 
    Accumulation Buffer 
)

\ void glClearAccum( GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha );
C-FUNCTION glClearAccum         glClearAccum        r r r r   -- void

\ void glAccum( GLenum op, GLfloat value );
C-FUNCTION glAccum              glAccum             n r       -- void


(
    Transformation
)

\ void glMatrixMode( GLenum mode );
C-FUNCTION glMatrixMode        glMatrixMode        n          -- void           

\ void glOrtho( GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble near_val, GLdouble far_val );
C-FUNCTION glOrtho             glOrtho             r r r r r r -- void

\ void glFrustum( GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble near_val, GLdouble far_val );
C-FUNCTION glFrustum           glFrustum           r r r r r r -- void

\ void glViewport( GLint x, GLint y, GLsizei width, GLsizei height );
C-FUNCTION glViewport          glViewport          n n n n    -- void

\ void glPushMatrix( void );
C-FUNCTION glPushMatrix        glPushMatrix                   -- void

\ void glPopMatrix( void );
C-FUNCTION glPopMatrix         glPopMatrix                    -- void

\ void glLoadIdentity( void );
C-FUNCTION glLoadIdentity      glLoadIdentity                 -- void

\ void glLoadMatrixd( const GLdouble *m );
C-FUNCTION glLoadMatrixd       glLoadMatrixd      a           -- void

\ void glLoadMatrixf( const GLfloat *m );
C-FUNCTION glLoadMatrixf       glLoadMatrixf      a           -- void

\ void glMultMatrixd( const GLdouble *m );
C-FUNCTION glMultMatrixd       glLoadMatrixd      a           -- void

\ void glMultMatrixf( const GLfloat *m );
C-FUNCTION glMultMatrixf       glMultMatrixf      a           -- void

\ void glRotated( GLdouble angle, GLdouble x, GLdouble y, GLdouble z );
C-FUNCTION glRotated           glRotated          r r r r     -- void

\ void glRotatef( GLfloat angle, GLfloat x, GLfloat y, GLfloat z );
C-FUNCTION glRotatef           glRotatef          r r r r     -- void

\ void glScaled( GLdouble x, GLdouble y, GLdouble z );
C-FUNCTION glScaled            glScaled           r r r       -- void

\ void glScalef( GLfloat x, GLfloat y, GLfloat z );
C-FUNCTION glScalef            glScalef           r r r       -- void

\ void glTranslated( GLdouble x, GLdouble y, GLdouble z );
C-FUNCTION glTranslated        glTranslated       r r r       -- void


(
    Display Lists
)

\ GLboolean glIsList( GLuint list );
C-FUNCTION glIsList            glIsLIst           n           -- n

\ void glDeleteLists( GLuint list, GLsizei range );
C-FUNCTION glDeleteList        glDeleteList       n n         -- void

\ GLuint glGenLists( GLsizei range );
C-FUNCTION glGenLists          glDeleteLists      n           -- n

\ void glNewList( GLuint list, GLenum mode );
C-FUNCTION glNewList           glNewList          n n         -- void

\ void glEndList( void );
C-FUNCTION glEndList           glEndList                      -- void

\ void glCallList( GLuint list );
C-FUNCTION glCallList          glCallList         n           -- void

\ void glCallLists( GLsizei n, GLenum type, const GLvoid *lists );
C-FUNCTION glCallLists         glCallLists        n n a       -- void 

\ void glListBase( GLuint base );
C-FUNCTION glListBase          glListBase         n           -- void

(
    Drawing Functions
)

\ void glBegin( GLenum mode );
C-FUNCTION glBegin             glBegin           n            -- void

\ void glEnd( void );
C-FUNCTION glEnd               glEnd                          -- void


( vertex )

\ void glVertex2d( GLdouble x, GLdouble y );
C-FUNCTION glVertex2d          glVertex2d        r r          -- void

\ void glVertex2f( GLfloat x, GLfloat y );
C-FUNCTION glVertex2f          glVertex2f        r r          -- void

\ void glVertex2i( GLint x, GLint y );
C-FUNCTION glVertex2i          glVertex2i        n n          -- void

\ void glVertex2s( GLshort x, GLshort y );
C-FUNCTION glVertex2s          glVertex2s        n n          -- void


\ void glVertex3d( GLdouble x, GLdouble y, GLdouble z );
C-FUNCTION glVertex3d          glVertex3d        r r r        -- void

\ void glVertex3f( GLfloat x, GLfloat y, GLfloat z );
C-FUNCTION glVertex3f          glVertex3f        r r r        -- void

\ void glVertex3i( GLint x, GLint y, GLint z );
C-FUNCTION glVertex3i          glVertex3i        n n n        -- void

\ void glVertex3s( GLshort x, GLshort y, GLshort z );
C-FUNCTION glVertex3s          glVertex3s        n n n        -- void


\ void glVertex4d( GLdouble x, GLdouble y, GLdouble z, GLdouble w );
C-FUNCTION glVertex4d          glVertex4d        r r r r      -- void

\ void glVertex4f( GLfloat x, GLfloat y, GLfloat z, GLfloat w );
C-FUNCTION glVertex4f          glVertex4f        r r r r      -- void

\ void glVertex4i( GLint x, GLint y, GLint z, GLint w );
C-FUNCTION glVertex4i          glVertex4i        n n n n      -- void

\ void glVertex4s( GLshort x, GLshort y, GLshort z, GLshort w );
C-FUNCTION glVertex4s          glVertex4s        n n n n      -- void


\ void glVertex2dv( const GLdouble *v );
C-FUNCTION glVertex2dv         glVertex2dv       a            -- void

\ void glVertex2fv( const GLfloat *v );
C-FUNCTION glVertex2fv         glVertex2fv       a            -- void

\ void glVertex2iv( const GLint *v );
C-FUNCTION glVertex2iv         glVertex2iv       a            -- void    

\ void glVertex2sv( const GLshort *v );
C-FUNCTION glVertex2sv         glVertex2sv       a            -- void


\ void glVertex3dv( const GLdouble *v );
C-FUNCTION glVertex3dv         glVertex3dv       a            -- void

\ void glVertex3fv( const GLfloat *v );
C-FUNCTION glVertex3fv         glVertex3fv       a            -- void         

\ void glVertex3iv( const GLint *v );
C-FUNCTION glVertex3iv         glVertex3iv       a            -- void

\ void glVertex3sv( const GLshort *v );
C-FUNCTION glVertex3sv         glVertex3sv       a            -- void


\ void glVertex4dv( const GLdouble *v );
C-FUNCTION GlVertex4dv          glVertex4dv      a            -- void

\ void glVertex4fv( const GLfloat *v );
C-FUNCTION glVertex4fv          glVertex4dv      a            -- void

\ void glVertex4iv( const GLint *v );
C-FUNCTION glVertex4iv          glVertex4dv      a            -- void

\ void glVertex4sv( const GLshort *v );
C-FUNCTION glVertex4sv          glVertex4sv      a            -- void


( normal )

\ void glNormal3b( GLbyte nx, GLbyte ny, GLbyte nz );
C-FUNCTION glNormal3b           glNormal3b       n n n        -- void

\ void glNormal3d( GLdouble nx, GLdouble ny, GLdouble nz );
C-FUNCTION glNormal3d           glNormal3d       r r r        -- void

\ void glNormal3f( GLfloat nx, GLfloat ny, GLfloat nz );
C-FUNCTION glNormal3f           glNormal3f       r r r        -- void

\ void glNormal3i( GLint nx, GLint ny, GLint nz );
C-FUNCTION glNormal3i           glNormal3i       n n n        -- void

\ void glNormal3s( GLshort nx, GLshort ny, GLshort nz );
C-FUNCTION glNormal3s           glNormal3s       n n n        -- void


\ void glNormal3bv( const GLbyte *v );
C-FUNCTION glNormal3bv          glNormal3bv      a            -- void

\ void glNormal3dv( const GLdouble *v );
C-FUNCTION glNormal3dv          glNormal3dv      a            -- void

\ void glNormal3fv( const GLfloat *v );
C-FUNCTION glNormal3fv          glNormal3fv      a            -- void

\ void glNormal3iv( const GLint *v );
C-FUNCTION glNormal3iv          glNormal3iv      a            -- void

\ void glNormal3sv( const GLshort *v );
C-FUNCTION glNormal3sv          glNormal3sv      a            -- void


\ void glIndexd( GLdouble c );
C-FUNCTION glIndexd             glIndexd         r            -- void

\ void glIndexf( GLfloat c );
C-FUNCTION glIndexf             glIndexf         r            -- void

\ void glIndexi( GLint c );
C-FUNCTION glIndexi             glIndexi         n            -- void

\ void glIndexs( GLshort c );
C-FUNCTION glIndexs             glIndexs         n            -- void

\ void glIndexub( GLubyte c );  /* 1.1 */
C-FUNCTION glIndexub            glIndexub        n            -- void


\ void glIndexdv( const GLdouble *c );
C-FUNCTION glIndexdv            glIndexdv        a            -- void

\ void glIndexfv( const GLfloat *c );
C-FUNCTION glInduxfv            glIndexfv        a            -- void

\ void glIndexiv( const GLint *c );
C-FUNCTION glIndexiv            glIndexiv        a            -- void

\ void glIndexsv( const GLshort *c );
C-FUNCTION glIndexsv            glIndexsv        a            -- void

\ void glIndexubv( const GLubyte *c );  /* 1.1 */
C-FUNCTION glIndexbv            glIndexbv        a            -- void


( color )

\ void glColor3b( GLbyte red, GLbyte green, GLbyte blue );
C-FUNCTION glColor3b            glColor3b        n n n        -- void

\ void glColor3d( GLdouble red, GLdouble green, GLdouble blue );
C-FUNCTION glColor3d            glColor3d        r r r        -- void

\ void glColor3f( GLfloat red, GLfloat green, GLfloat blue );
C-FUNCTION glColor3d            glColor3d        r r r        -- void

\ void glColor3i( GLint red, GLint green, GLint blue );
C-FUNCTION glColor3i            glColor3i        n n n        -- void

\ void glColor3s( GLshort red, GLshort green, GLshort blue );
C-FUNCTION glColor3s            glColor3s        n n n        -- void

\ void glColor3ub( GLubyte red, GLubyte green, GLubyte blue );
C-FUNCTION glColor3ub           glColor3ub       n n n        -- void

\ void glColor3ui( GLuint red, GLuint green, GLuint blue );
C-FUNCTION glColor3ui           glColor3ui       n n n        -- void

\ void glColor3us( GLushort red, GLushort green, GLushort blue );
C-FUNCTION glColor3us           glColor3us       n n n        -- void

\ void glColor4b( GLbyte red, GLbyte green, GLbyte blue, GLbyte alpha );
C-FUNCTION glColor4b            glColor4b        n n n n      -- void

\ void glColor4d( GLdouble red, GLdouble green, GLdouble blue, GLdouble alpha );
C-FUNCTION glColor4d            glColor4d        r r r r      -- void

\ void glColor4f( GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha );
C-FUNCTION glColor4f            glColor4f        r r r r      -- void

\ void glColor4i( GLint red, GLint green, GLint blue, GLint alpha );
C-FUNCTION glColor4i            glColor4i        n n n n      -- void

\ void glColor4s( GLshort red, GLshort green, GLshort blue, GLshort alpha );
C-FUNCTION glColor4s            glColor4s        n n n n      -- void

\ void glColor4ub( GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha );
C-FUNCTION glColo4ub            glColor4ub       n n n n      -- void

\ void glColor4ui( GLuint red, GLuint green, GLuint blue, GLuint alpha );
C-FUNCTION glColor4ui           glColor4ui       n n n n      -- void 

\ void glColor4us( GLushort red, GLushort green, GLushort blue, GLushort alpha );
C-FUNCTION glColor4us           glColor4us       n n n n      -- void


\ void glColor3bv( const GLbyte *v );
C-FUNCTION glColor3bv           glColor3bv       a            -- void

\ void glColor3dv( const GLdouble *v );
C-FUNCTION glColor3dv           glColor3dv       a            -- void

\ void glColor3fv( const GLfloat *v );
C-FUNCTION glColor3fv           glColor3fv       a            -- void

\ void glColor3iv( const GLint *v );
C-FUNCTION glColor3iv           glColor3iv       a            -- void

\ void glColor3sv( const GLshort *v );
C-FUNCTION glColor3sv           glColor3sv       a            -- void

\ void glColor3ubv( const GLubyte *v );
C-FUNCTION glColor3ubv          glColor3ubv      a            -- void

\ void glColor3uiv( const GLuint *v );
C-FUNCTION glColor3uiv          glColor3uiv      a            -- void

\ void glColor3usv( const GLushort *v );
C-FUNCTION glColor3usv          glColor3usv      a            -- void


\ void glColor4bv( const GLbyte *v );
C-FUNCTION glColor4bv           glColor4bv       a            -- void

\ void glColor4dv( const GLdouble *v );
C-FUNCTION glColor4dv           glColor4dv       a            -- void

\ void glColor4fv( const GLfloat *v );
C-FUNCTION glColor4fv           glColor4fv       a            -- void

\ void glColor4iv( const GLint *v );
C-FUNCTION glColor4iv           glColor4iv       a            -- void

\ void glColor4sv( const GLshort *v );
C-FUNCTION glColor4sv           glColor4sv       a            -- void

\ void glColor4ubv( const GLubyte *v );
C-FUNCTION glColor4ubv          glColor4ubv      a            -- void

\ void glColor4uiv( const GLuint *v );
C-FUNCTION glColor4uiv          glColor4uiv      a            -- void

\ void glColor4usv( const GLushort *v );
C-FUNCTION glColor4usv          glColor4usv      a            -- void



( texcoords )

\ void glTexCoord1d( GLdouble s );
C-FUNCTION glTexCoord1d         glTexCoord1d     r            -- void

\ void glTexCoord1f( GLfloat s );
C-FUCTION  glTexCoord1f         glTexCoord1f     r            -- void

\ void glTexCoord1i( GLint s );
C-FUNCTION glTexCoodr1i         glTexCoord1i     n            -- void

\ void glTexCoord1s( GLshort s );
C-FUNCTION glTexCoord1s         glTexCoord1s     n            -- void        


\ void glTexCoord2d( GLdouble s, GLdouble t );
C-FUNCTION glTexCoord2d         glTexCoord2d     r r          -- void

\ void glTexCoord2f( GLfloat s, GLfloat t );
C-FUNCTION glTexCoord2f         glTexCoord2f     r r          -- void

\ void glTexCoord2i( GLint s, GLint t );
C-FUNCTION glTexCoord2i         glTexCoord2i     n n          -- void

\ void glTexCoord2s( GLshort s, GLshort t );
C-FUNCTION glTexCoord2s         glTexCoord2s     n n          -- void


\ void glTexCoord3d( GLdouble s, GLdouble t, GLdouble r );
C-FUNCTION glTexCoord3d         glTexCoord3d     r r r        -- void 

\ void glTexCoord3f( GLfloat s, GLfloat t, GLfloat r );
C-FUNCTION glTexCoord3f         glTexCoord3f     r r r        -- void 

\ void glTexCoord3i( GLint s, GLint t, GLint r );
C-FUNCTION glTexCoord3i         glTexCoord3i     n n n        -- void 

\ void glTexCoord3s( GLshort s, GLshort t, GLshort r );
C-FUNCTION glTexCoord3s         glTexCoord3s     n n n        -- void


\ void glTexCoord4d( GLdouble s, GLdouble t, GLdouble r, GLdouble q );
C-FUNCTION glTexCoord4d         glTexCoord4d     r r r r      -- void   

\ void glTexCoord4f( GLfloat s, GLfloat t, GLfloat r, GLfloat q );
C-FUNCTION glTexCoord4f         glTexCoord4f     r r r r      -- void

\ void glTexCoord4i( GLint s, GLint t, GLint r, GLint q );
C-FUNCTION glTexCoord4i         glTexCoord4i     n n n n      -- void 

\ void glTexCoord4s( GLshort s, GLshort t, GLshort r, GLshort q );
C-FUNCTION glTexCoord4s         glTexCoord4s     n n n n      -- void


\ void glTexCoord1dv( const GLdouble *v );
C-FUNCTION glTexCoord1dv        glTexCoord1dv    a            -- void

\ void glTexCoord1fv( const GLfloat *v );
C-FUNCTION glTexCoord1fv        glTexCoord1fv    a            -- void

\ void glTexCoord1iv( const GLint *v );
C-FUNCTION glTexCoord1iv        glTexCoord1iv    a            -- void

\ void glTexCoord1sv( const GLshort *v );
C-FUNCTION glTexCoord1sv        glTexCoord1sv    a            -- void


\ void glTexCoord2dv( const GLdouble *v );
C-FUNCTION glTexCoord2dv        glTexCoord2dv    a            -- void

\ void glTexCoord2fv( const GLfloat *v );
C-FUNCTION glTexCoord2fv        glTexCoord2fv    a            -- void

\ void glTexCoord2iv( const GLint *v );
C-FUNCTION glTexCoordiv         glTexCoord2iv    a            -- void

\ void glTexCoord2sv( const GLshort *v );
C-FUNCTION glTexCoord2sv        glTexCoord2sv    a            -- void               


\ void glTexCoord3dv( const GLdouble *v );
C-FUNCTION glTexCoord3dv        glTexCoord3dv    a            -- void

\ void glTexCoord3fv( const GLfloat *v );
C-FUNCTION glTexCoord3fv        glTexCoord3fv    a            -- void

\ void glTexCoord3iv( const GLint *v );
C-FUNCTION glTexCoord3iv        glTexCoord3iv    a            -- void

\ void glTexCoord3sv( const GLshort *v );
C-FUNCTION glTexCoord3sv        glTexCoord3sv    a            -- void


\ void glTexCoord4dv( const GLdouble *v );
C-FUNCTION glTexCoord4dv        glTexCoord4dv    a            -- void

\ void glTexCoord4fv( const GLfloat *v );
C-FUNCTION glTexCoord4fv        glTexCoord4fv    a            -- void

\ void glTexCoord4iv( const GLint *v );
C-FUNCTION glTexCoord4iv        glTexCoord4iv    a            -- void

\ void glTexCoord4sv( const GLshort *v );
C-FUNCTION glTexCoord4sv        glTexCoord4sv    a            -- void


( raster )

\ void glRasterPos2d( GLdouble x, GLdouble y );
C-FUNCTION glRasterPos2d        glRasterPos2d    r r          -- void

\ void glRasterPos2f( GLfloat x, GLfloat y );
C-FUNCTION glRasterPos2f        glRasterPos2f    r r          -- void

\ void glRasterPos2i( GLint x, GLint y );
C-FUNCTION glRasterPos2i        glRasterPos2i    n n          -- void

\ void glRasterPos2s( GLshort x, GLshort y );
C-FUNCTION glRasterPos2s        glRasterPos2s    n n          -- void


\ void glRasterPos3d( GLdouble x, GLdouble y, GLdouble z );


\ void glRasterPos3f( GLfloat x, GLfloat y, GLfloat z );


\ void glRasterPos3i( GLint x, GLint y, GLint z );


\ void glRasterPos3s( GLshort x, GLshort y, GLshort z );



\ void glRasterPos4d( GLdouble x, GLdouble y, GLdouble z, GLdouble w );


\ void glRasterPos4f( GLfloat x, GLfloat y, GLfloat z, GLfloat w );


\ void glRasterPos4i( GLint x, GLint y, GLint z, GLint w );


\ void glRasterPos4s( GLshort x, GLshort y, GLshort z, GLshort w );



\ void glRasterPos2dv( const GLdouble *v );


\ void glRasterPos2fv( const GLfloat *v );


\ void glRasterPos2iv( const GLint *v );


\ void glRasterPos2sv( const GLshort *v );



\ void glRasterPos3dv( const GLdouble *v );


\ void glRasterPos3fv( const GLfloat *v );


\ void glRasterPos3iv( const GLint *v );


\ void glRasterPos3sv( const GLshort *v );





\ void glRasterPos4dv( const GLdouble *v );


\ void glRasterPos4fv( const GLfloat *v );


\ void glRasterPos4iv( const GLint *v );


\ void glRasterPos4sv( const GLshort *v );



( rect )

\ void glRectd( GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2 );


\ void glRectf( GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2 );


\ void glRecti( GLint x1, GLint y1, GLint x2, GLint y2 );


\ void glRects( GLshort x1, GLshort y1, GLshort x2, GLshort y2 );


 
\ void glRectdv( const GLdouble *v1, const GLdouble *v2 );


\ void glRectfv( const GLfloat *v1, const GLfloat *v2 );


\ void glRectiv( const GLint *v1, const GLint *v2 );


\ void glRectsv( const GLshort *v1, const GLshort *v2 );


(
    Vertex Arrays (1.1) 
)

\ void glVertexPointer( GLint size, GLenum type, GLsizei stride, const GLvoid *ptr );

 
\ void glNormalPointer( GLenum type, GLsizei stride, const GLvoid *ptr );
 

\ void glColorPointer( GLint size, GLenum type, GLsizei stride, const GLvoid *ptr );
 

\ void glIndexPointer( GLenum type, GLsizei stride, const GLvoid *ptr );


\ void glTexCoordPointer( GLint size, GLenum type, GLsizei stride, const GLvoid *ptr );


\ void glEdgeFlagPointer( GLsizei stride, const GLvoid *ptr );
 

\ void glGetPointerv( GLenum pname, GLvoid **params );
 

\ void glArrayElement( GLint i );
 


\ void glDrawArrays( GLenum mode, GLint first, GLsizei count );


\ void glDrawElements( GLenum mode, GLsizei count, GLenum type, const GLvoid *indices );


\ void glInterleavedArrays( GLenum format, GLsizei stride, const GLvoid *pointer );

(
    Lighting
)
 
\ void glShadeModel( GLenum mode );


( light )

\ void glLightf( GLenum light, GLenum pname, GLfloat param );


\ void glLighti( GLenum light, GLenum pname, GLint param );



\ void glLightfv( GLenum light, GLenum pname,const GLfloat *params );


\ void glLightiv( GLenum light, GLenum pname, const GLint *params );



\ void glGetLightfv( GLenum light, GLenum pname, GLfloat *params );


\ void glGetLightiv( GLenum light, GLenum pname, GLint *params );
 


\ void glLightModelf( GLenum pname, GLfloat param );


\ void glLightModeli( GLenum pname, GLint param );



\ void glLightModelfv( GLenum pname, const GLfloat *params );


\ void glLightModeliv( GLenum pname, const GLint *params );



( material )

\ void glMaterialf( GLenum face, GLenum pname, GLfloat param );


\ void glMateriali( GLenum face, GLenum pname, GLint param );



\ void glMaterialfv( GLenum face, GLenum pname, const GLfloat *params );


\ void glMaterialiv( GLenum face, GLenum pname, const GLint *params );



\ void glGetMaterialfv( GLenum face, GLenum pname, GLfloat *params );


\ void glGetMaterialiv( GLenum face, GLenum pname, GLint *params );
 

\ void glColorMaterial( GLenum face, GLenum mode );
 
 
(
     Raster functions
)
 
\ void glPixelZoom( GLfloat xfactor, GLfloat yfactor );



\ void glPixelStoref( GLenum pname, GLfloat param );


\ void glPixelStorei( GLenum pname, GLint param );



\ void glPixelTransferf( GLenum pname, GLfloat param );


\ void glPixelTransferi( GLenum pname, GLint param );



\ void glPixelMapfv( GLenum map, GLsizei mapsize, const GLfloat *values );


\ void glPixelMapuiv( GLenum map, GLsizei mapsize,const GLuint *values );


\ void glPixelMapusv( GLenum map, GLsizei mapsize, const GLushort *values );



\ void glGetPixelMapfv( GLenum map, GLfloat *values );


\ void glGetPixelMapuiv( GLenum map, GLuint *values );


\ void glGetPixelMapusv( GLenum map, GLushort *values );
 


\ void glBitmap( GLsizei width, GLsizei height, GLfloat xorig, GLfloat yorig, GLfloat xmove, GLfloat ymove, const GLubyte *bitmap );



\ void glReadPixels( GLint x, GLint y, GLsizei width, GLsizei height, GLenum format, GLenum type, GLvoid *pixels );


\ void glDrawPixels( GLsizei width, GLsizei height, GLenum format, GLenum type,const GLvoid *pixels );


\ void glCopyPixels( GLint x, GLint y, GLsizei width, GLsizei height, GLenum type );



(
    Stenciling
)
 
\ void glStencilFunc( GLenum func, GLint ref, GLuint mask );


\ void glStencilMask( GLuint mask );


\ void glStencilOp( GLenum fail, GLenum zfail, GLenum zpass );


\ void glClearStencil( GLint s );
 
 
 
(
    Texture mapping
)
 
\ void glTexGend( GLenum coord, GLenum pname, GLdouble param );


\ void glTexGenf( GLenum coord, GLenum pname, GLfloat param );


\ void glTexGeni( GLenum coord, GLenum pname, GLint param );
 

\ void glTexGendv( GLenum coord, GLenum pname, const GLdouble *params );


\ void glTexGenfv( GLenum coord, GLenum pname, const GLfloat *params );


\ void glTexGeniv( GLenum coord, GLenum pname, const GLint *params );



\ void glGetTexGendv( GLenum coord, GLenum pname, GLdouble *params );


\ void glGetTexGenfv( GLenum coord, GLenum pname, GLfloat *params );


\ void glGetTexGeniv( GLenum coord, GLenum pname, GLint *params );



\ void glTexEnvf( GLenum target, GLenum pname, GLfloat param );


\ void glTexEnvi( GLenum target, GLenum pname, GLint param );



\ void glTexEnvfv( GLenum target, GLenum pname, const GLfloat *params );


\ void glTexEnviv( GLenum target, GLenum pname, const GLint *params );



\ void glGetTexEnvfv( GLenum target, GLenum pname, GLfloat *params );


\ void glGetTexEnviv( GLenum target, GLenum pname, GLint *params );



\ void glTexParameterf( GLenum target, GLenum pname, GLfloat param );


\ void glTexParameteri( GLenum target, GLenum pname, GLint param );



\ void glTexParameterfv( GLenum target, GLenum pname, const GLfloat *params );


\ void glTexParameteriv( GLenum target, GLenum pname, const GLint *params );



\ void glGetTexParameterfv( GLenum target, GLenum pname, GLfloat *params);


\ void glGetTexParameteriv( GLenum target, GLenum pname, GLint *params );


\ void glGetTexLevelParameterfv( GLenum target, GLint level,
\                                                 GLenum pname, GLfloat *params );

\ void glGetTexLevelParameteriv( GLenum target, GLint level,
\                                                 GLenum pname, GLint *params );


\ void glTexImage1D( GLenum target, GLint level,
\                                     GLint internalFormat,
\                                     GLsizei width, GLint border,
\                                     GLenum format, GLenum type,
\                                     const GLvoid *pixels );
 

\ void glTexImage2D( GLenum target, GLint level,
\                                     GLint internalFormat,
\                                     GLsizei width, GLsizei height,
\                                     GLint border, GLenum format, GLenum type,
\                                     const GLvoid *pixels );
 

\ void glGetTexImage( GLenum target, GLint level,
\                                      GLenum format, GLenum type,
\                                      GLvoid *pixels );


( 1.1 functions )
\ 
\ void glGenTextures( GLsizei n, GLuint *textures );



\ void glDeleteTextures( GLsizei n, const GLuint *textures);


\ void glBindTexture( GLenum target, GLuint texture );


\ void glPrioritizeTextures( GLsizei n,
\                                             const GLuint *textures,
\                                             const GLclampf *priorities ); 


\ GLboolean glAreTexturesResident( GLsizei n,
\                                                   const GLuint *textures,
\                                                   GLboolean *residences );



\ GLboolean glIsTexture( GLuint texture );


\ void glTexSubImage1D( GLenum target, GLint level,
\                                        GLint xoffset,
\                                        GLsizei width, GLenum format,
\                                        GLenum type, const GLvoid *pixels ); 


\ void glTexSubImage2D( GLenum target, GLint level,
\                                        GLint xoffset, GLint yoffset,
\                                        GLsizei width, GLsizei height,
\                                        GLenum format, GLenum type,
\                                        const GLvoid *pixels );


\ void glCopyTexImage1D( GLenum target, GLint level,
\                                         GLenum internalformat,
\                                         GLint x, GLint y,
\                                         GLsizei width, GLint border );
 
 


\ void glCopyTexImage2D( GLenum target, GLint level,
\                                         GLenum internalformat,
\                                         GLint x, GLint y,
\                                         GLsizei width, GLsizei height,
\                                         GLint border );



\ void glCopyTexSubImage1D( GLenum target, GLint level,
\                                            GLint xoffset, GLint x, GLint y,
\                                            GLsizei width );


\ void glCopyTexSubImage2D( GLenum target, GLint level,
\                                            GLint xoffset, GLint yoffset,
\                                            GLint x, GLint y,
\                                            GLsizei width, GLsizei height ); 



(
    Evaluators
)
 
\ void glMap1d( GLenum target, GLdouble u1, GLdouble u2, GLint stride, GLint order, const GLdouble *points );


\ void glMap1f( GLenum target, GLfloat u1, GLfloat u2,  GLint stride, GLint order, const GLfloat *points );



\ void glMap2d( GLenum target,
\ 	            GLdouble u1, GLdouble u2, GLint ustride, GLint uorder,
\ 		        GLdouble v1, GLdouble v2, GLint vstride, GLint vorder,
\ 		        const GLdouble *points );


\ void glMap2f( GLenum target,
\ 		     GLfloat u1, GLfloat u2, GLint ustride, GLint uorder,
\ 		     GLfloat v1, GLfloat v2, GLint vstride, GLint vorder, const GLfloat *points );
 


\ void glGetMapdv( GLenum target, GLenum query, GLdouble *v );


\ void glGetMapfv( GLenum target, GLenum query, GLfloat *v );


\ void glGetMapiv( GLenum target, GLenum query, GLint *v );
 


\ void glEvalCoord1d( GLdouble u );


\ void glEvalCoord1f( GLfloat u );
 


\ void glEvalCoord1dv( const GLdouble *u );


\ void glEvalCoord1fv( const GLfloat *u );
 


\ void glEvalCoord2d( GLdouble u, GLdouble v );


\ void glEvalCoord2f( GLfloat u, GLfloat v );
 

\ void glEvalCoord2dv( const GLdouble *u );


\ void glEvalCoord2fv( const GLfloat *u );
 

\ void glMapGrid1d( GLint un, GLdouble u1, GLdouble u2 );


\ void glMapGrid1f( GLint un, GLfloat u1, GLfloat u2 );
 

\ void glMapGrid2d( GLint un, GLdouble u1, GLdouble u2, GLint vn, GLdouble v1, GLdouble v2 );


\ void glMapGrid2f( GLint un, GLfloat u1, GLfloat u2, GLint vn, GLfloat v1, GLfloat v2 );
 

\ void glEvalPoint1( GLint i );
 

\ void glEvalPoint2( GLint i, GLint j );
 

\ void glEvalMesh1( GLenum mode, GLint i1, GLint i2 );


\ void glEvalMesh2( GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2 );



(
    Fog
)
 
\ void glFogf( GLenum pname, GLfloat param );
 

\ void glFogi( GLenum pname, GLint param );
 

\ void glFogfv( GLenum pname, const GLfloat *params );


\ void glFogiv( GLenum pname, const GLint *params );



(
    Selection and Feedback
)
\ 
\ void glFeedbackBuffer( GLsizei size, GLenum type, GLfloat *buffer );
\ 
\ void glPassThrough( GLfloat token );
\ 
\ void glSelectBuffer( GLsizei size, GLuint *buffer );
\ 
\ void glInitNames( void );
\ 
\ void glLoadName( GLuint name );
\ 
\ void glPushName( GLuint name );
\ 
\ void glPopName( void );



(
    OpenGL (1.2)
)

\ #define GL_RESCALE_NORMAL			0x803A
\ #define GL_CLAMP_TO_EDGE			0x812F
\ #define GL_MAX_ELEMENTS_VERTICES		0x80E8
\ #define GL_MAX_ELEMENTS_INDICES			0x80E9
\ #define GL_BGR					0x80E0
\ #define GL_BGRA					0x80E1
\ #define GL_UNSIGNED_BYTE_3_3_2			0x8032
\ #define GL_UNSIGNED_BYTE_2_3_3_REV		0x8362
\ #define GL_UNSIGNED_SHORT_5_6_5			0x8363
\ #define GL_UNSIGNED_SHORT_5_6_5_REV		0x8364
\ #define GL_UNSIGNED_SHORT_4_4_4_4		0x8033
\ #define GL_UNSIGNED_SHORT_4_4_4_4_REV		0x8365
\ #define GL_UNSIGNED_SHORT_5_5_5_1		0x8034
\ #define GL_UNSIGNED_SHORT_1_5_5_5_REV		0x8366
\ #define GL_UNSIGNED_INT_8_8_8_8			0x8035
\ #define GL_UNSIGNED_INT_8_8_8_8_REV		0x8367
\ #define GL_UNSIGNED_INT_10_10_10_2		0x8036
\ #define GL_UNSIGNED_INT_2_10_10_10_REV		0x8368
\ #define GL_LIGHT_MODEL_COLOR_CONTROL		0x81F8
\ #define GL_SINGLE_COLOR				0x81F9
\ #define GL_SEPARATE_SPECULAR_COLOR		0x81FA
\ #define GL_TEXTURE_MIN_LOD			0x813A
\ #define GL_TEXTURE_MAX_LOD			0x813B
\ #define GL_TEXTURE_BASE_LEVEL			0x813C
\ #define GL_TEXTURE_MAX_LEVEL			0x813D
\ #define GL_SMOOTH_POINT_SIZE_RANGE		0x0B12
\ #define GL_SMOOTH_POINT_SIZE_GRANULARITY	0x0B13
\ #define GL_SMOOTH_LINE_WIDTH_RANGE		0x0B22
\ #define GL_SMOOTH_LINE_WIDTH_GRANULARITY	0x0B23
\ #define GL_ALIASED_POINT_SIZE_RANGE		0x846D
\ #define GL_ALIASED_LINE_WIDTH_RANGE		0x846E
\ #define GL_PACK_SKIP_IMAGES			0x806B
\ #define GL_PACK_IMAGE_HEIGHT			0x806C
\ #define GL_UNPACK_SKIP_IMAGES			0x806D
\ #define GL_UNPACK_IMAGE_HEIGHT			0x806E
\ #define GL_TEXTURE_3D				0x806F
\ #define GL_PROXY_TEXTURE_3D			0x8070
\ #define GL_TEXTURE_DEPTH			0x8071
\ #define GL_TEXTURE_WRAP_R			0x8072
\ #define GL_MAX_3D_TEXTURE_SIZE			0x8073
\ #define GL_TEXTURE_BINDING_3D			0x806A
\ 
\ void glDrawRangeElements( GLenum mode, GLuint start,
\ 	GLuint end, GLsizei count, GLenum type, const GLvoid *indices );
\ 
\ void glTexImage3D( GLenum target, GLint level,
\                                       GLint internalFormat,
\                                       GLsizei width, GLsizei height,
\                                       GLsizei depth, GLint border,
\                                       GLenum format, GLenum type,
\                                       const GLvoid *pixels );
\ 
\ void glTexSubImage3D( GLenum target, GLint level,
\                                          GLint xoffset, GLint yoffset,
\                                          GLint zoffset, GLsizei width,
\                                          GLsizei height, GLsizei depth,
\                                          GLenum format,
\                                          GLenum type, const GLvoid *pixels);
\ 
\ void glCopyTexSubImage3D( GLenum target, GLint level,
\                                              GLint xoffset, GLint yoffset,
\                                              GLint zoffset, GLint x,
\                                              GLint y, GLsizei width,
\                                              GLsizei height );
\ 
\ typedef void (APIENTRYP PFNGLDRAWRANGEELEMENTSPROC) (GLenum mode, GLuint start, GLuint end, GLsizei count, GLenum type, const GLvoid *indices);
\ typedef void (APIENTRYP PFNGLTEXIMAGE3DPROC) (GLenum target, GLint level, GLint internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLenum format, GLenum type, const GLvoid *pixels);
\ typedef void (APIENTRYP PFNGLTEXSUBIMAGE3DPROC) (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const GLvoid *pixels);
\ typedef void (APIENTRYP PFNGLCOPYTEXSUBIMAGE3DPROC) (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLint x, GLint y, GLsizei width, GLsizei height);
\ 
\ 
\ /*
\  * GL_ARB_imaging
\  */
\ 
\ #define GL_CONSTANT_COLOR			0x8001
\ #define GL_ONE_MINUS_CONSTANT_COLOR		0x8002
\ #define GL_CONSTANT_ALPHA			0x8003
\ #define GL_ONE_MINUS_CONSTANT_ALPHA		0x8004
\ #define GL_COLOR_TABLE				0x80D0
\ #define GL_POST_CONVOLUTION_COLOR_TABLE		0x80D1
\ #define GL_POST_COLOR_MATRIX_COLOR_TABLE	0x80D2
\ #define GL_PROXY_COLOR_TABLE			0x80D3
\ #define GL_PROXY_POST_CONVOLUTION_COLOR_TABLE	0x80D4
\ #define GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE	0x80D5
\ #define GL_COLOR_TABLE_SCALE			0x80D6
\ #define GL_COLOR_TABLE_BIAS			0x80D7
\ #define GL_COLOR_TABLE_FORMAT			0x80D8
\ #define GL_COLOR_TABLE_WIDTH			0x80D9
\ #define GL_COLOR_TABLE_RED_SIZE			0x80DA
\ #define GL_COLOR_TABLE_GREEN_SIZE		0x80DB
\ #define GL_COLOR_TABLE_BLUE_SIZE		0x80DC
\ #define GL_COLOR_TABLE_ALPHA_SIZE		0x80DD
\ #define GL_COLOR_TABLE_LUMINANCE_SIZE		0x80DE
\ #define GL_COLOR_TABLE_INTENSITY_SIZE		0x80DF
\ #define GL_CONVOLUTION_1D			0x8010
\ #define GL_CONVOLUTION_2D			0x8011
\ #define GL_SEPARABLE_2D				0x8012
\ #define GL_CONVOLUTION_BORDER_MODE		0x8013
\ #define GL_CONVOLUTION_FILTER_SCALE		0x8014
\ #define GL_CONVOLUTION_FILTER_BIAS		0x8015
\ #define GL_REDUCE				0x8016
\ #define GL_CONVOLUTION_FORMAT			0x8017
\ #define GL_CONVOLUTION_WIDTH			0x8018
\ #define GL_CONVOLUTION_HEIGHT			0x8019
\ #define GL_MAX_CONVOLUTION_WIDTH		0x801A
\ #define GL_MAX_CONVOLUTION_HEIGHT		0x801B
\ #define GL_POST_CONVOLUTION_RED_SCALE		0x801C
\ #define GL_POST_CONVOLUTION_GREEN_SCALE		0x801D
\ #define GL_POST_CONVOLUTION_BLUE_SCALE		0x801E
\ #define GL_POST_CONVOLUTION_ALPHA_SCALE		0x801F
\ #define GL_POST_CONVOLUTION_RED_BIAS		0x8020
\ #define GL_POST_CONVOLUTION_GREEN_BIAS		0x8021
\ #define GL_POST_CONVOLUTION_BLUE_BIAS		0x8022
\ #define GL_POST_CONVOLUTION_ALPHA_BIAS		0x8023
\ #define GL_CONSTANT_BORDER			0x8151
\ #define GL_REPLICATE_BORDER			0x8153
\ #define GL_CONVOLUTION_BORDER_COLOR		0x8154
\ #define GL_COLOR_MATRIX				0x80B1
\ #define GL_COLOR_MATRIX_STACK_DEPTH		0x80B2
\ #define GL_MAX_COLOR_MATRIX_STACK_DEPTH		0x80B3
\ #define GL_POST_COLOR_MATRIX_RED_SCALE		0x80B4
\ #define GL_POST_COLOR_MATRIX_GREEN_SCALE	0x80B5
\ #define GL_POST_COLOR_MATRIX_BLUE_SCALE		0x80B6
\ #define GL_POST_COLOR_MATRIX_ALPHA_SCALE	0x80B7
\ #define GL_POST_COLOR_MATRIX_RED_BIAS		0x80B8
\ #define GL_POST_COLOR_MATRIX_GREEN_BIAS		0x80B9
\ #define GL_POST_COLOR_MATRIX_BLUE_BIAS		0x80BA
\ #define GL_POST_COLOR_MATRIX_ALPHA_BIAS		0x80BB
\ #define GL_HISTOGRAM				0x8024
\ #define GL_PROXY_HISTOGRAM			0x8025
\ #define GL_HISTOGRAM_WIDTH			0x8026
\ #define GL_HISTOGRAM_FORMAT			0x8027
\ #define GL_HISTOGRAM_RED_SIZE			0x8028
\ #define GL_HISTOGRAM_GREEN_SIZE			0x8029
\ #define GL_HISTOGRAM_BLUE_SIZE			0x802A
\ #define GL_HISTOGRAM_ALPHA_SIZE			0x802B
\ #define GL_HISTOGRAM_LUMINANCE_SIZE		0x802C
\ #define GL_HISTOGRAM_SINK			0x802D
\ #define GL_MINMAX				0x802E
\ #define GL_MINMAX_FORMAT			0x802F
\ #define GL_MINMAX_SINK				0x8030
\ #define GL_TABLE_TOO_LARGE			0x8031
\ #define GL_BLEND_EQUATION			0x8009
\ #define GL_MIN					0x8007
\ #define GL_MAX					0x8008
\ #define GL_FUNC_ADD				0x8006
\ #define GL_FUNC_SUBTRACT			0x800A
\ #define GL_FUNC_REVERSE_SUBTRACT		0x800B
\ #define GL_BLEND_COLOR				0x8005
\ 
\ 
\ void glColorTable( GLenum target, GLenum internalformat,
\                                     GLsizei width, GLenum format,
\                                     GLenum type, const GLvoid *table );
\ 
\ void glColorSubTable( GLenum target,
\                                        GLsizei start, GLsizei count,
\                                        GLenum format, GLenum type,
\                                        const GLvoid *data );
\ 
\ void glColorTableParameteriv(GLenum target, GLenum pname,
\                                               const GLint *params);
\ 
\ void glColorTableParameterfv(GLenum target, GLenum pname,
\                                               const GLfloat *params);
\ 
\ void glCopyColorSubTable( GLenum target, GLsizei start,
\                                            GLint x, GLint y, GLsizei width );
\ 
\ void glCopyColorTable( GLenum target, GLenum internalformat,
\                                         GLint x, GLint y, GLsizei width );
\ 
\ void glGetColorTable( GLenum target, GLenum format,
\                                        GLenum type, GLvoid *table );
\ 
\ void glGetColorTableParameterfv( GLenum target, GLenum pname,
\                                                   GLfloat *params );
\ 
\ void glGetColorTableParameteriv( GLenum target, GLenum pname,
\                                                   GLint *params );
\ 
\ void glBlendEquation( GLenum mode );
\ 
\ void glBlendColor( GLclampf red, GLclampf green,
\                                     GLclampf blue, GLclampf alpha );
\ 
\ void glHistogram( GLenum target, GLsizei width,
\ 				   GLenum internalformat, GLboolean sink );
\ 
\ void glResetHistogram( GLenum target );
\ 
\ void glGetHistogram( GLenum target, GLboolean reset,
\ 				      GLenum format, GLenum type,
\ 				      GLvoid *values );
\ 
\ void glGetHistogramParameterfv( GLenum target, GLenum pname,
\ 						 GLfloat *params );
\ 
\ void glGetHistogramParameteriv( GLenum target, GLenum pname,
\ 						 GLint *params );
\ 
\ void glMinmax( GLenum target, GLenum internalformat,
\ 				GLboolean sink );
\ 
\ void glResetMinmax( GLenum target );
\ 
\ void glGetMinmax( GLenum target, GLboolean reset,
\                                    GLenum format, GLenum types,
\                                    GLvoid *values );
\ 
\ void glGetMinmaxParameterfv( GLenum target, GLenum pname,
\ 					      GLfloat *params );
\ 
\ void glGetMinmaxParameteriv( GLenum target, GLenum pname,
\ 					      GLint *params );
\ 
\ void glConvolutionFilter1D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLenum format, GLenum type,
\ 	const GLvoid *image );
\ 
\ void glConvolutionFilter2D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLsizei height, GLenum format,
\ 	GLenum type, const GLvoid *image );
\ 
\ void glConvolutionParameterf( GLenum target, GLenum pname,
\ 	GLfloat params );
\ 
\ void glConvolutionParameterfv( GLenum target, GLenum pname,
\ 	const GLfloat *params );
\ 
\ void glConvolutionParameteri( GLenum target, GLenum pname,
\ 	GLint params );
\ 
\ void glConvolutionParameteriv( GLenum target, GLenum pname,
\ 	const GLint *params );
\ 
\ void glCopyConvolutionFilter1D( GLenum target,
\ 	GLenum internalformat, GLint x, GLint y, GLsizei width );
\ 
\ void glCopyConvolutionFilter2D( GLenum target,
\ 	GLenum internalformat, GLint x, GLint y, GLsizei width,
\ 	GLsizei height);
\ 
\ void glGetConvolutionFilter( GLenum target, GLenum format,
\ 	GLenum type, GLvoid *image );
\ 
\ void glGetConvolutionParameterfv( GLenum target, GLenum pname,
\ 	GLfloat *params );
\ 
\ void glGetConvolutionParameteriv( GLenum target, GLenum pname,
\ 	GLint *params );
\ 
\ void glSeparableFilter2D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLsizei height, GLenum format,
\ 	GLenum type, const GLvoid *row, const GLvoid *column );
\ 
\ void glGetSeparableFilter( GLenum target, GLenum format,
\ 	GLenum type, GLvoid *row, GLvoid *column, GLvoid *span );
\ 
\ 
\ 
\ 
(
    OpenGL 1.3
)

\ 
\ /* multitexture */
\ #define GL_TEXTURE0				0x84C0
\ #define GL_TEXTURE1				0x84C1
\ #define GL_TEXTURE2				0x84C2
\ #define GL_TEXTURE3				0x84C3
\ #define GL_TEXTURE4				0x84C4
\ #define GL_TEXTURE5				0x84C5
\ #define GL_TEXTURE6				0x84C6
\ #define GL_TEXTURE7				0x84C7
\ #define GL_TEXTURE8				0x84C8
\ #define GL_TEXTURE9				0x84C9
\ #define GL_TEXTURE10				0x84CA
\ #define GL_TEXTURE11				0x84CB
\ #define GL_TEXTURE12				0x84CC
\ #define GL_TEXTURE13				0x84CD
\ #define GL_TEXTURE14				0x84CE
\ #define GL_TEXTURE15				0x84CF
\ #define GL_TEXTURE16				0x84D0
\ #define GL_TEXTURE17				0x84D1
\ #define GL_TEXTURE18				0x84D2
\ #define GL_TEXTURE19				0x84D3
\ #define GL_TEXTURE20				0x84D4
\ #define GL_TEXTURE21				0x84D5
\ #define GL_TEXTURE22				0x84D6
\ #define GL_TEXTURE23				0x84D7
\ #define GL_TEXTURE24				0x84D8
\ #define GL_TEXTURE25				0x84D9
\ #define GL_TEXTURE26				0x84DA
\ #define GL_TEXTURE27				0x84DB
\ #define GL_TEXTURE28				0x84DC
\ #define GL_TEXTURE29				0x84DD
\ #define GL_TEXTURE30				0x84DE
\ #define GL_TEXTURE31				0x84DF
\ #define GL_ACTIVE_TEXTURE			0x84E0
\ #define GL_CLIENT_ACTIVE_TEXTURE		0x84E1
\ #define GL_MAX_TEXTURE_UNITS			0x84E2
\ /* texture_cube_map */
\ #define GL_NORMAL_MAP				0x8511
\ #define GL_REFLECTION_MAP			0x8512
\ #define GL_TEXTURE_CUBE_MAP			0x8513
\ #define GL_TEXTURE_BINDING_CUBE_MAP		0x8514
\ #define GL_TEXTURE_CUBE_MAP_POSITIVE_X		0x8515
\ #define GL_TEXTURE_CUBE_MAP_NEGATIVE_X		0x8516
\ #define GL_TEXTURE_CUBE_MAP_POSITIVE_Y		0x8517
\ #define GL_TEXTURE_CUBE_MAP_NEGATIVE_Y		0x8518
\ #define GL_TEXTURE_CUBE_MAP_POSITIVE_Z		0x8519
\ #define GL_TEXTURE_CUBE_MAP_NEGATIVE_Z		0x851A
\ #define GL_PROXY_TEXTURE_CUBE_MAP		0x851B
\ #define GL_MAX_CUBE_MAP_TEXTURE_SIZE		0x851C
\ /* texture_compression */
\ #define GL_COMPRESSED_ALPHA			0x84E9
\ #define GL_COMPRESSED_LUMINANCE			0x84EA
\ #define GL_COMPRESSED_LUMINANCE_ALPHA		0x84EB
\ #define GL_COMPRESSED_INTENSITY			0x84EC
\ #define GL_COMPRESSED_RGB			0x84ED
\ #define GL_COMPRESSED_RGBA			0x84EE
\ #define GL_TEXTURE_COMPRESSION_HINT		0x84EF
\ #define GL_TEXTURE_COMPRESSED_IMAGE_SIZE	0x86A0
\ #define GL_TEXTURE_COMPRESSED			0x86A1
\ #define GL_NUM_COMPRESSED_TEXTURE_FORMATS	0x86A2
\ #define GL_COMPRESSED_TEXTURE_FORMATS		0x86A3
\ /* multisample */
\ #define GL_MULTISAMPLE				0x809D
\ #define GL_SAMPLE_ALPHA_TO_COVERAGE		0x809E
\ #define GL_SAMPLE_ALPHA_TO_ONE			0x809F
\ #define GL_SAMPLE_COVERAGE			0x80A0
\ #define GL_SAMPLE_BUFFERS			0x80A8
\ #define GL_SAMPLES				0x80A9
\ #define GL_SAMPLE_COVERAGE_VALUE		0x80AA
\ #define GL_SAMPLE_COVERAGE_INVERT		0x80AB
\ #define GL_MULTISAMPLE_BIT			0x20000000
\ /* transpose_matrix */
\ #define GL_TRANSPOSE_MODELVIEW_MATRIX		0x84E3
\ #define GL_TRANSPOSE_PROJECTION_MATRIX		0x84E4
\ #define GL_TRANSPOSE_TEXTURE_MATRIX		0x84E5
\ #define GL_TRANSPOSE_COLOR_MATRIX		0x84E6
\ /* texture_env_combine */
\ #define GL_COMBINE				0x8570
\ #define GL_COMBINE_RGB				0x8571
\ #define GL_COMBINE_ALPHA			0x8572
\ #define GL_SOURCE0_RGB				0x8580
\ #define GL_SOURCE1_RGB				0x8581
\ #define GL_SOURCE2_RGB				0x8582
\ #define GL_SOURCE0_ALPHA			0x8588
\ #define GL_SOURCE1_ALPHA			0x8589
\ #define GL_SOURCE2_ALPHA			0x858A
\ #define GL_OPERAND0_RGB				0x8590
\ #define GL_OPERAND1_RGB				0x8591
\ #define GL_OPERAND2_RGB				0x8592
\ #define GL_OPERAND0_ALPHA			0x8598
\ #define GL_OPERAND1_ALPHA			0x8599
\ #define GL_OPERAND2_ALPHA			0x859A
\ #define GL_RGB_SCALE				0x8573
\ #define GL_ADD_SIGNED				0x8574
\ #define GL_INTERPOLATE				0x8575
\ #define GL_SUBTRACT				0x84E7
\ #define GL_CONSTANT				0x8576
\ #define GL_PRIMARY_COLOR			0x8577
\ #define GL_PREVIOUS				0x8578
\ /* texture_env_dot3 */
\ #define GL_DOT3_RGB				0x86AE
\ #define GL_DOT3_RGBA				0x86AF
\ /* texture_border_clamp */
\ #define GL_CLAMP_TO_BORDER			0x812D
\ 
\ void glActiveTexture( GLenum texture );
\ 
\ void glClientActiveTexture( GLenum texture );
\ 
\ void glCompressedTexImage1D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ void glCompressedTexImage2D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ void glCompressedTexImage3D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ void glCompressedTexSubImage1D( GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ void glCompressedTexSubImage2D( GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ void glCompressedTexSubImage3D( GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ void glGetCompressedTexImage( GLenum target, GLint lod, GLvoid *img );
\ 
\ void glMultiTexCoord1d( GLenum target, GLdouble s );
\ 
\ void glMultiTexCoord1dv( GLenum target, const GLdouble *v );
\ 
\ void glMultiTexCoord1f( GLenum target, GLfloat s );
\ 
\ void glMultiTexCoord1fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord1i( GLenum target, GLint s );
\ 
\ void glMultiTexCoord1iv( GLenum target, const GLint *v );
\ 
\ void glMultiTexCoord1s( GLenum target, GLshort s );
\ 
\ void glMultiTexCoord1sv( GLenum target, const GLshort *v );
\ 
\ void glMultiTexCoord2d( GLenum target, GLdouble s, GLdouble t );
\ 
\ void glMultiTexCoord2dv( GLenum target, const GLdouble *v );
\ 
\ void glMultiTexCoord2f( GLenum target, GLfloat s, GLfloat t );
\ 
\ void glMultiTexCoord2fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord2i( GLenum target, GLint s, GLint t );
\ 
\ void glMultiTexCoord2iv( GLenum target, const GLint *v );
\ 
\ void glMultiTexCoord2s( GLenum target, GLshort s, GLshort t );
\ 
\ void glMultiTexCoord2sv( GLenum target, const GLshort *v );
\ 
\ void glMultiTexCoord3d( GLenum target, GLdouble s, GLdouble t, GLdouble r );
\ 
\ void glMultiTexCoord3dv( GLenum target, const GLdouble *v );
\ 
\ void glMultiTexCoord3f( GLenum target, GLfloat s, GLfloat t, GLfloat r );
\ 
\ void glMultiTexCoord3fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord3i( GLenum target, GLint s, GLint t, GLint r );
\ 
\ void glMultiTexCoord3iv( GLenum target, const GLint *v );
\ 
\ void glMultiTexCoord3s( GLenum target, GLshort s, GLshort t, GLshort r );
\ 
\ void glMultiTexCoord3sv( GLenum target, const GLshort *v );
\ 
\ void glMultiTexCoord4d( GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q );
\ 
\ void glMultiTexCoord4dv( GLenum target, const GLdouble *v );
\ 
\ void glMultiTexCoord4f( GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q );
\ 
\ void glMultiTexCoord4fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord4i( GLenum target, GLint s, GLint t, GLint r, GLint q );
\ 
\ void glMultiTexCoord4iv( GLenum target, const GLint *v );
\ 
\ void glMultiTexCoord4s( GLenum target, GLshort s, GLshort t, GLshort r, GLshort q );
\ 
\ void glMultiTexCoord4sv( GLenum target, const GLshort *v );
\ 
\ 
\ void glLoadTransposeMatrixd( const GLdouble m[16] );
\ 
\ void glLoadTransposeMatrixf( const GLfloat m[16] );
\ 
\ void glMultTransposeMatrixd( const GLdouble m[16] );
\ 
\ void glMultTransposeMatrixf( const GLfloat m[16] );
\ 
\ void glSampleCoverage( GLclampf value, GLboolean invert );
\ 
\ 
\ typedef void (APIENTRYP PFNGLACTIVETEXTUREPROC) (GLenum texture);
\ typedef void (APIENTRYP PFNGLSAMPLECOVERAGEPROC) (GLclampf value, GLboolean invert);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXIMAGE3DPROC) (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXIMAGE2DPROC) (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXIMAGE1DPROC) (GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC) (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC) (GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC) (GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, const GLvoid *data);
\ typedef void (APIENTRYP PFNGLGETCOMPRESSEDTEXIMAGEPROC) (GLenum target, GLint level, GLvoid *img);
\ 
\ 
\ 
(
    GL_ARB_multitexture (ARB extension 1 and OpenGL 1.2.1)
)
\ #ifndef GL_ARB_multitexture
\ #define GL_ARB_multitexture 1
\ 
\ #define GL_TEXTURE0_ARB				0x84C0
\ #define GL_TEXTURE1_ARB				0x84C1
\ #define GL_TEXTURE2_ARB				0x84C2
\ #define GL_TEXTURE3_ARB				0x84C3
\ #define GL_TEXTURE4_ARB				0x84C4
\ #define GL_TEXTURE5_ARB				0x84C5
\ #define GL_TEXTURE6_ARB				0x84C6
\ #define GL_TEXTURE7_ARB				0x84C7
\ #define GL_TEXTURE8_ARB				0x84C8
\ #define GL_TEXTURE9_ARB				0x84C9
\ #define GL_TEXTURE10_ARB			0x84CA
\ #define GL_TEXTURE11_ARB			0x84CB
\ #define GL_TEXTURE12_ARB			0x84CC
\ #define GL_TEXTURE13_ARB			0x84CD
\ #define GL_TEXTURE14_ARB			0x84CE
\ #define GL_TEXTURE15_ARB			0x84CF
\ #define GL_TEXTURE16_ARB			0x84D0
\ #define GL_TEXTURE17_ARB			0x84D1
\ #define GL_TEXTURE18_ARB			0x84D2
\ #define GL_TEXTURE19_ARB			0x84D3
\ #define GL_TEXTURE20_ARB			0x84D4
\ #define GL_TEXTURE21_ARB			0x84D5
\ #define GL_TEXTURE22_ARB			0x84D6
\ #define GL_TEXTURE23_ARB			0x84D7
\ #define GL_TEXTURE24_ARB			0x84D8
\ #define GL_TEXTURE25_ARB			0x84D9
\ #define GL_TEXTURE26_ARB			0x84DA
\ #define GL_TEXTURE27_ARB			0x84DB
\ #define GL_TEXTURE28_ARB			0x84DC
\ #define GL_TEXTURE29_ARB			0x84DD
\ #define GL_TEXTURE30_ARB			0x84DE
\ #define GL_TEXTURE31_ARB			0x84DF
\ #define GL_ACTIVE_TEXTURE_ARB			0x84E0
\ #define GL_CLIENT_ACTIVE_TEXTURE_ARB		0x84E1
\ #define GL_MAX_TEXTURE_UNITS_ARB		0x84E2
\ 
\ void glActiveTextureARB(GLenum texture);
\ void glClientActiveTextureARB(GLenum texture);
\ void glMultiTexCoord1dARB(GLenum target, GLdouble s);
\ void glMultiTexCoord1dvARB(GLenum target, const GLdouble *v);
\ void glMultiTexCoord1fARB(GLenum target, GLfloat s);
\ void glMultiTexCoord1fvARB(GLenum target, const GLfloat *v);
\ void glMultiTexCoord1iARB(GLenum target, GLint s);
\ void glMultiTexCoord1ivARB(GLenum target, const GLint *v);
\ void glMultiTexCoord1sARB(GLenum target, GLshort s);
\ void glMultiTexCoord1svARB(GLenum target, const GLshort *v);
\ void glMultiTexCoord2dARB(GLenum target, GLdouble s, GLdouble t);
\ void glMultiTexCoord2dvARB(GLenum target, const GLdouble *v);
\ void glMultiTexCoord2fARB(GLenum target, GLfloat s, GLfloat t);
\ void glMultiTexCoord2fvARB(GLenum target, const GLfloat *v);
\ void glMultiTexCoord2iARB(GLenum target, GLint s, GLint t);
\ void glMultiTexCoord2ivARB(GLenum target, const GLint *v);
\ void glMultiTexCoord2sARB(GLenum target, GLshort s, GLshort t);
\ void glMultiTexCoord2svARB(GLenum target, const GLshort *v);
\ void glMultiTexCoord3dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r);
\ void glMultiTexCoord3dvARB(GLenum target, const GLdouble *v);
\ void glMultiTexCoord3fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r);
\ void glMultiTexCoord3fvARB(GLenum target, const GLfloat *v);
\ void glMultiTexCoord3iARB(GLenum target, GLint s, GLint t, GLint r);
\ void glMultiTexCoord3ivARB(GLenum target, const GLint *v);
\ void glMultiTexCoord3sARB(GLenum target, GLshort s, GLshort t, GLshort r);
\ void glMultiTexCoord3svARB(GLenum target, const GLshort *v);
\ void glMultiTexCoord4dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
\ void glMultiTexCoord4dvARB(GLenum target, const GLdouble *v);
\ void glMultiTexCoord4fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
\ void glMultiTexCoord4fvARB(GLenum target, const GLfloat *v);
\ void glMultiTexCoord4iARB(GLenum target, GLint s, GLint t, GLint r, GLint q);
\ void glMultiTexCoord4ivARB(GLenum target, const GLint *v);
\ void glMultiTexCoord4sARB(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
\ void glMultiTexCoord4svARB(GLenum target, const GLshort *v);

\ typedef void (APIENTRYP PFNGLACTIVETEXTUREARBPROC) (GLenum texture);
\ typedef void (APIENTRYP PFNGLCLIENTACTIVETEXTUREARBPROC) (GLenum texture);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1DARBPROC) (GLenum target, GLdouble s);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1DVARBPROC) (GLenum target, const GLdouble *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1FARBPROC) (GLenum target, GLfloat s);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1FVARBPROC) (GLenum target, const GLfloat *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1IARBPROC) (GLenum target, GLint s);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1IVARBPROC) (GLenum target, const GLint *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1SARBPROC) (GLenum target, GLshort s);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD1SVARBPROC) (GLenum target, const GLshort *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2DARBPROC) (GLenum target, GLdouble s, GLdouble t);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2DVARBPROC) (GLenum target, const GLdouble *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2FARBPROC) (GLenum target, GLfloat s, GLfloat t);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2FVARBPROC) (GLenum target, const GLfloat *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2IARBPROC) (GLenum target, GLint s, GLint t);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2IVARBPROC) (GLenum target, const GLint *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2SARBPROC) (GLenum target, GLshort s, GLshort t);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD2SVARBPROC) (GLenum target, const GLshort *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3DARBPROC) (GLenum target, GLdouble s, GLdouble t, GLdouble r);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3DVARBPROC) (GLenum target, const GLdouble *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3FARBPROC) (GLenum target, GLfloat s, GLfloat t, GLfloat r);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3FVARBPROC) (GLenum target, const GLfloat *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3IARBPROC) (GLenum target, GLint s, GLint t, GLint r);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3IVARBPROC) (GLenum target, const GLint *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3SARBPROC) (GLenum target, GLshort s, GLshort t, GLshort r);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD3SVARBPROC) (GLenum target, const GLshort *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4DARBPROC) (GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4DVARBPROC) (GLenum target, const GLdouble *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4FARBPROC) (GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4FVARBPROC) (GLenum target, const GLfloat *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4IARBPROC) (GLenum target, GLint s, GLint t, GLint r, GLint q);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4IVARBPROC) (GLenum target, const GLint *v);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4SARBPROC) (GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
\ typedef void (APIENTRYP PFNGLMULTITEXCOORD4SVARBPROC) (GLenum target, const GLshort *v);
\ 
\ #endif /* GL_ARB_multitexture */
\ 
\ 
\ 
\ /*
\  * Define this token if you want "old-style" header file behaviour (extensions
\  * defined in gl.h).  Otherwise, extensions will be included from glext.h.
\  */
\ #if defined(GL_GLEXT_LEGACY)
\ 
\ /* All extensions that used to be here are now found in glext.h */
\ 
\ #else  /* GL_GLEXT_LEGACY */
\ 
\ #include <GL/glext.h>
\ 
\ #endif  /* GL_GLEXT_LEGACY */
\ 
\ 
\ 
\ /*
\  * ???. GL_MESA_packed_depth_stencil
\  * XXX obsolete
\  */
\ #ifndef GL_MESA_packed_depth_stencil
\ #define GL_MESA_packed_depth_stencil 1
\ 
\ #define GL_DEPTH_STENCIL_MESA			0x8750
\ #define GL_UNSIGNED_INT_24_8_MESA		0x8751
\ #define GL_UNSIGNED_INT_8_24_REV_MESA		0x8752
\ #define GL_UNSIGNED_SHORT_15_1_MESA		0x8753
\ #define GL_UNSIGNED_SHORT_1_15_REV_MESA		0x8754
\ 
\ #endif /* GL_MESA_packed_depth_stencil */
\ 
\ 
\ #ifndef GL_ATI_blend_equation_separate
\ #define GL_ATI_blend_equation_separate 1
\ 
\ #define GL_ALPHA_BLEND_EQUATION_ATI	        0x883D
\ 
\ GLAPI void GLAPIENTRY glBlendEquationSeparateATI( GLenum modeRGB, GLenum modeA );
\ typedef void (APIENTRYP PFNGLBLENDEQUATIONSEPARATEATIPROC) (GLenum modeRGB, GLenum modeA);
\ 
\ #endif /* GL_ATI_blend_equation_separate */
\ 
\ 
\ /* GL_OES_EGL_image */
\ #if !defined(GL_OES_EGL_image) && !defined(GL_EXT_EGL_image_storage)
\ typedef void* GLeglImageOES;
\ #endif
\ 
\ #ifndef GL_OES_EGL_image
\ #define GL_OES_EGL_image 1
\ #ifdef GL_GLEXT_PROTOTYPES
\ GLAPI void APIENTRY glEGLImageTargetTexture2DOES (GLenum target, GLeglImageOES image);
\ GLAPI void APIENTRY glEGLImageTargetRenderbufferStorageOES (GLenum target, GLeglImageOES image);
\ #endif
\ typedef void (APIENTRYP PFNGLEGLIMAGETARGETTEXTURE2DOESPROC) (GLenum target, GLeglImageOES image);
\ typedef void (APIENTRYP PFNGLEGLIMAGETARGETRENDERBUFFERSTORAGEOESPROC) (GLenum target, GLeglImageOES image);
\ #endif
\ 
\ 
\ #ifdef __cplusplus
\ }
\ #endif
\ 
\ #endif /* __gl_h_ */

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
GLU-FALSE CONSTANT GLU-VERSION-1.1
GLU-FALSE CONSTANT GLU-VERSION-1.2
GLU-FALSE CONSTANT GLU-VERSION-1.3

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
(        GLU-FILL )
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

cell  CONSTANT GLUnurbs
cell  CONSTANT GLUquadric
cell  CONSTANT GLUtesselator


\ void gluBeginCurve (GLUnurbs* nurb);
C-FUNCTION gluBeginCurve            gluBeginCurve           a                         -- void

\ void gluBeginPolygon (GLUtesselator* tess);
C-FUNCTION gluBeginPolygon          gluBeginPolygon         a                         -- void

\ void gluBeginSurface (GLUnurbs* nurb);
C-FUNCTION gluBeginSurface          gluBeginSurface         a                         -- void

\ void gluBeginTrim (GLUnurbs* nurb);
C-FUNCTION gluBeginTrim             gluBeginTrim            a                         -- void

\ GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);
C-FUNCTION c-gluCheckExtension      gluCheckExtension       a a                       -- n

\ void gluCylinder (GLUquadric* quad, GLdouble base, GLdouble top, GLdouble height, GLint slices, GLint stacks);
C-FUNCTION c-gluCylinder            gluCylinder             a n n n n n               -- void

\ void gluDeleteNurbsRenderer (GLUnurbs* nurb);
C-FUNCTION gluDeleteNurbsRenderer   gluDeleteNurbsRenderer  a                         -- void  

\ void gluDeleteQuadric (GLUquadric* quad);
C-FUNCTION gluDeleteQuadric         gluDeleteQuadric        a                         -- void 

\ void gluDeleteTess (GLUtesselator* tess);
C-FUNCTION gluDeleteTess            gluDeleteTess           a                         -- void 

\ void gluDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);
C-FUNCTION c-gluDisk                gluDisk                 a r r n n                 -- void

\ void gluEndCurve (GLUnurbs* nurb);
C-FUNCTION gluEndCurve              gluEndCurve             a                         -- void 

\ void gluEndPolygon (GLUtesselator* tess);
C-FUNCTION gluEndPolygon            gluEndPolygon           a                         -- void

\ void gluEndSurface (GLUnurbs* nurb);
C-FUNCTION gluEndSurface            gluEndSurface           a                         -- void

\ void gluEndTrim (GLUnurbs* nurb);
C-FUNCTION gluEndTrim               gluEndTrim              a                         -- void

\ const GLubyte * gluErrorString (GLenum error);
C-FUNCTION gluErrorString           gluErrorString          n                         -- a

\ void gluGetNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat* data);
C-FUNCTION gluGetNurbsProperty      gluGetNurbsProperty     a n a                     -- void

\ const GLubyte * gluGetString (GLenum name);
C-FUNCTION gluGetString             gluGetString            n                         -- a

\ void gluGetTessProperty (GLUtesselator* tess, GLenum which, GLdouble* data);
C-FUNCTION gluGetTessProperty       gluGetTessProperty      a n a                     -- void


\ void gluLoadSamplingMatrices (GLUnurbs* nurb, const GLfloat *model, const GLfloat *perspective, const GLint *view);
C-FUNCTION gluGetSamplingMatrices   gluGetSamplingMatrices  a a a a                   -- void

\ void gluLookAt (GLdouble eyeX, GLdouble eyeY, GLdouble eyeZ, GLdouble centerX, GLdouble centerY, GLdouble centerZ, GLdouble upX, GLdouble upY, GLdouble upZ);
C-FUNCTION gluLookAt                gluLookAt               r r r r r r r r r         -- void

\ GLUnurbs* gluNewNurbsRenderer (void);
C-FUNCTION gluNewNurbsRenderer      gluNewNurbsRenderer                               -- a

\ GLUquadric* gluNewQuadric (void);
C-FUNCTION gluNewQuadric            gluNewQuadric                                     -- a

\ GLUtesselator* gluNewTess (void);
C-FUNCTION gluNewTess               gluNewTess                                        -- a

\ void gluNextContour (GLUtesselator* tess, GLenum type);
C-FUNCTION gluNextContour           gluNextContour          a n                       -- void

\ void gluNurbsCallback (GLUnurbs* nurb, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluNurbsCallback         gluNurbsCallback        a n a                     -- void

\ void gluNurbsCallbackData (GLUnurbs* nurb, GLvoid* userData);
C-FUNCTION gluNurbsCallbackData     gluNurbsCallback        a a                       -- void

\ void gluNurbsCallbackDataEXT (GLUnurbs* nurb, GLvoid* userData);
C-FUNCTION gluNurbsCallbackDataEXT  gluNurbsCallbackDataEXT a a                       -- void

\ void gluNurbsCurve (GLUnurbs* nurb, GLint knotCount, GLfloat *knots, GLint stride, GLfloat *control, GLint order, GLenum type);
C-FUNCTION gluNurbsCurve            gluNurbsCurve           a n a n a n n             -- void

\ void gluNurbsProperty (GLUnurbs* nurb, GLenum property, GLfloat value);
C-FUNCTION gluNurbsProperty         gluNurbsProperty        a n r                     -- void

\ void gluNurbsSurface (GLUnurbs* nurb, GLint sKnotCount, GLfloat* sKnots, GLint tKnotCount, GLfloat* tKnots, GLint sStride, GLint tStride, GLfloat* control, GLint sOrder, GLint tOrder, GLenum type);
C-FUNCTION gluNurbsSurface         gluNurbsSurface          a n a n a n n a n n n     -- void

\ void gluOrtho2D (GLdouble left, GLdouble right, GLdouble bottom, GLdouble top);
C-FUNCTION gluOrtho2D              gluOrtho2D               r r r r                   -- void

\ void gluPartialDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops, GLdouble start, GLdouble sweep);
C-FUNCTION gluPartialDisk          gluPartialDisk           a r r n n r r             -- void

\ void gluPerspective (GLdouble fovy, GLdouble aspect, GLdouble zNear, GLdouble zFar);
C-FUNCTION gluPerspective          gluPerspective           r r r r                   -- void

\ void gluPickMatrix (GLdouble x, GLdouble y, GLdouble delX, GLdouble delY, GLint *viewport);
C-FUNCTION gluPickMatrix           gluPickMatrix            r r r r a                 -- void

\ GLint gluProject (GLdouble objX, GLdouble objY, GLdouble objZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* winX, GLdouble* winY, GLdouble* winZ);
C-FUNCTION gluProject              gluProject               r r r a a a a a a         -- n

\ void gluPwlCurve (GLUnurbs* nurb, GLint count, GLfloat* data, GLint stride, GLenum type);
C-FUNCTION gluPwlCurve             gluPwlCurve              a n a n n                 -- void

\ void gluQuadricCallback (GLUquadric* quad, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluQuadricCallback      gluQuadricCallback       a n a                     -- void

\ void gluQuadricDrawStyle (GLUquadric* quad, GLenum draw);
C-FUNCTION gluQuadricDrawStyle     gluQuadricDrawStyle      a n                       -- void

\ void gluQuadricNormals (GLUquadric* quad, GLenum normal);
C-FUNCTION gluQuadricNormals       gluQuadricNormals        a n                       -- void

\ void gluQuadricOrientation (GLUquadric* quad, GLenum orientation);
C-FUNCTION gluQuadricOrientation   gluQuadricOrientation    a n                       -- void

\ void gluQuadricTexture (GLUquadric* quad, GLboolean texture);
C-FUNCTION gluQuadricTexture       gluQuadricTexture        a n                       -- void

\ GLint gluScaleImage (GLenum format, GLsizei wIn, GLsizei hIn, GLenum typeIn, const void *dataIn, GLsizei wOut, GLsizei hOut, GLenum typeOut, GLvoid* dataOut);
C-FUNCTION gluScaleImage           gluScaleImage            n n n n a n n n a         -- n

\ void gluSphere (GLUquadric* quad, GLdouble radius, GLint slices, GLint stacks);
C-FUNCTION gluSphere               gluSphere                a r n n                   -- void

\ void gluTessBeginContour (GLUtesselator* tess);
C-FUNCTION gluTessBeginContour     gluTessBeginContour      a                         -- void

\ void gluTessBeginPolygon (GLUtesselator* tess, GLvoid* data);
C-FUNCTION gluTessBeginPolygon     gluTessBeginPolygon      a a                       -- void

\ void gluTessCallback (GLUtesselator* tess, GLenum which, _GLUfuncptr CallBackFunc);
C-FUNCTION gluTessCallback         gluTessCallback          a n a                     -- void

\ void gluTessEndContour (GLUtesselator* tess);
C-FUNCTION gluTessEndCountour      gluTessEndContour        a                         -- void

\ void gluTessEndPolygon (GLUtesselator* tess);
C-FUNCTION gluTessEndPolygon       gluTessEndPolygon        a                         -- void

\ void gluTessNormal (GLUtesselator* tess, GLdouble valueX, GLdouble valueY, GLdouble valueZ);
C-FUNCTION gluTessNormal           gluTessNormal            a r r r                   -- void

\ void gluTessProperty (GLUtesselator* tess, GLenum which, GLdouble data);
C-FUNCTION gluTessProperty         gluTessProperty          a n r                     -- void

\ void gluTessVertex (GLUtesselator* tess, GLdouble *location, GLvoid* data);
C-FUNCTION gluTessVectex           gluTessVertex            a a a                     -- void

\ GLint gluUnProject (GLdouble winX, GLdouble winY, GLdouble winZ, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble* objX, GLdouble* objY, GLdouble* objZ);
C-FUNCTION gluUnProject            gluUnProject             r r r a a a a a a a       -- n

\ GLint gluUnProject4 (GLdouble winX, GLdouble winY, GLdouble winZ, GLdouble clipW, const GLdouble *model, const GLdouble *proj, const GLint *view, GLdouble nearVal, GLdouble farVal, GLdouble* objX, GLdouble* objY, GLdouble* objZ, GLdouble* objW);
C-FUNCTION gluProject4             gluProject4              r r r r a a a r r a a a a -- n


( mipmaps )

\ GLint gluBuild1DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
C-FUNCTION gluBuild1DMipmampLevels gluBuild1DMipmapLevels   n n n n n n n n a     -- n

\ GLint gluBuild1DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLenum format, GLenum type, const void *data);
C-FUNCTION gluBuild1DMipmaps       gluBuild1DMipmaps        n n n n n a           -- n

\ GLint gluBuild2DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
C-FUNCTION gluBuild2DMipmapLevels  gluBuild2DMipmapLevels   n n n n n n n n n a   -- n

\ GLint gluBuild2DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLenum format, GLenum type, const void *data);
C-FUNCTION gluBuild2DMipmaps       gluBuild2DMipmaps        n n n n n n a         -- n

\ GLint gluBuild3DMipmapLevels (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, GLint level, GLint base, GLint max, const void *data);
C-FUNCTION gluBuild3DMipmapLevels  gluBuild3DMipmapLevels   n n n n n n n n n n a -- n 

\ GLint gluBuild3DMipmaps (GLenum target, GLint internalFormat, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLenum type, const void *data);
C-FUNCTION gluBuild3DMipmaps       gluBuild3DMipmaps        n n n n n n n a       -- n

END-C-LIBRARY
