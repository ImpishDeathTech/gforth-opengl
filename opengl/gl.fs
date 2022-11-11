\
\ gl.4th
\
\ An unofficial FORTH "Implementation/Wrapper" for the "Mesa 3-D grapics library"
\
\ Original C code liscence:
\ Mesa 3-D graphics library
\ 
\ Copyright (C) 1999-2006  Brian Paul   All Rights Reserved.
\ Copyright (C) 2009  VMware, Inc.  All Rights Reserved.
\ 
\ Permission is hereby granted, free of charge, to any person obtaining a
\ copy of this software and associated documentation files (the "Software"),
\ to deal in the Software without restriction, including without limitation
\ the rights to use, copy, modify, merge, publish, distribute, sublicense,
\ and/or sell copies of the Software, and to permit persons to whom the
\ Software is furnished to do so, subject to the following conditions:
\ 
\ The above copyright notice and this permission notice shall be included
\ in all copies or substantial portions of the Software.
\ 
\ THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
\ OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
\ FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.  IN NO EVENT SHALL
\ THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
\ OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
\ ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
\ OTHER DEALINGS IN THE SOFTWARE.
\
\
\ FORTH "Implementation/Wrapper?" Subliscence:
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

C-LIBRARY gl_lib
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

\ utility
1F00 CONSTANT GL-VENDOR				
1F01 CONSTANT GL-RENDERER				
1F02 CONSTANT GL-VERSION				
1F03 CONSTANT GL-EXTENSIONS		    

\ errors
0000 CONSTANT GL-NO-ERROR 		
0500 CONSTANT GL-INVALID-ENUM		
0501 CONSTANT GL-INVALID-VALUE	
0502 CONSTANT GL-INVALID-OPERATION 
0503 CONSTANT GL-STACK-OVERFLOW	
0504 CONSTANT GL-STACK-UNDERFLOW	
0505 CONSTANT GL-OUT-OF-MEMORY	

\ glPush/PopAttrib bits
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

\ OpenGL 1.1
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

( miscellaneous )

\ void glClear(int);
C-FUNCTION glClear              glClear             n       -- void

\ void glClearAccum(GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
C-FUNCTION glClearAccum         glClearAccum        r r r r -- void

\ void glClearColor(GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
C-FUNCTION glClearColor         glClearColor        r r r r -- void

\ void glIndexMask(GLuint mask);
C-FUNCTION glIndexMask          glIndexMask         n       -- void

\ void glAlphaFunc(GLenum func, GLclampf ref);
C-FUNCTION glAlphaFunc          glAlphaFunc         n r     -- void

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
C-FUNCTION glScissor            glScissor            n n n n -- void 

\ void glClipPlane( GLenum plane, const GLdouble *equation );
C-FUNCTION glClipPlane          glClipPlane          n a     -- void 

\ void glGetClipPlane( GLenum plane, GLdouble *equation );
C-FUNCTION glGetClipPlane       glGetClipPlane       n a     -- void

\ void glDrawBuffer( GLenum mode );
C-FUNCTION glDrawBuffer         glDrawBuffer         n       -- void

\ void glReadBuffer( GLenum mode );
C-FUNCTION glReadBuffer         glReadBuffer         n       -- void

\ void glEnable( GLenum cap );
C-FUNCTION glEnable             glEnable             n       -- void

\ void glDisable( GLenum cap );
C-FUNCTION glDisable            glDisable            n       -- void

\ GLboolean  glIsEnabled( GLenum cap );
C-FUNCTION glEnabeld?           glIsEnabled          n       -- n


\ void glEnableClientState( GLenum cap );  /* 1.1 */
C-FUNCTION glEnableClientState  glEnableClientState  n       -- void  

\ void glDisableClientState( GLenum cap );  /* 1.1 */
C-FUNCTION glDisableClientState glDisableClientState n       -- void


\ void glGetBooleanv( GLenum pname, GLboolean *params );
C-FUNCTION glGetBooleanv        glGetBooleanv        n a     -- void

\ void glGetDoublev( GLenum pname, GLdouble *params );
C-FUNCTION glGetDoublev         glGetDoublev         n a     -- void
 
\ void glGetFloatv( GLenum pname, GLfloat *params );
C-FUNCTION glGetFloatv          glGetFloatv          n a     -- void
 
\ void glGetIntegerv( GLenum pname, GLint *params );
C-FUNCTION glGetIntegerv        glGetIntegerv        n a     -- void


\ void glPushAttrib( GLbitfield mask );
C-FUNCTION glPushAttrib         glPushAttrib         n        -- void
 
\ void glPopAttrib( void );
C-FUNCTION glPopAttrib          glPopAttrib                  -- void
 
 
\ void glPushClientAttrib( GLbitfield mask );  /* 1.1 */
C-FUNCTION glPushClientAttrib   glPushClientAttrib   n        -- void
 
\ void glPopClientAttrib( void );  /* 1.1 */
C-FUNCTION glPopClientAttrib    glPopClientAttrib    n        -- void
 
 
\ GLint glRenderMode( GLenum mode );
C-FUNCTION glRenderMode         glRenderMode         n        -- n
 
\ GLenum glGetError( void );
C-FUNCTION glGetError           glGetError                   -- n
 
\ const GLubyte * glGetString( GLenum name );
C-FUNCTION glGetString          glGetString          n        -- a
 
\ void glFinish( void );
C-FUNCTION glFinish             glFinish                     -- void
 
\ void glFlush( void );
C-FUNCTION glFlush              glFlush                      -- void
 
\ void glHint( GLenum target, GLenum mode );
C-FUNCTION glHint               glHint               n n      --void

( 
    depth buffer 
)

\ GLAPI void GLAPIENTRY glClearDepth( GLclampd depth );

\ GLAPI void GLAPIENTRY glDepthFunc( GLenum func );

\ GLAPI void GLAPIENTRY glDepthMask( GLboolean flag );

\ GLAPI void GLAPIENTRY glDepthRange( GLclampd near_val, GLclampd far_val );

( 
    accumulation buffer 
)

\ GLAPI void GLAPIENTRY glClearAccum( GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha );

\ GLAPI void GLAPIENTRY glAccum( GLenum op, GLfloat value );

(
    transformation
)

\ GLAPI void GLAPIENTRY glMatrixMode( GLenum mode );

\ GLAPI void GLAPIENTRY glOrtho( GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble near_val, GLdouble far_val );

\ GLAPI void GLAPIENTRY glFrustum( GLdouble left, GLdouble right, GLdouble bottom, GLdouble top, GLdouble near_val, GLdouble far_val );

\ GLAPI void GLAPIENTRY glViewport( GLint x, GLint y, GLsizei width, GLsizei height );

\ GLAPI void GLAPIENTRY glPushMatrix( void );

\ GLAPI void GLAPIENTRY glPopMatrix( void );

\ GLAPI void GLAPIENTRY glLoadIdentity( void );

\ GLAPI void GLAPIENTRY glLoadMatrixd( const GLdouble *m );
\ GLAPI void GLAPIENTRY glLoadMatrixf( const GLfloat *m );

\ GLAPI void GLAPIENTRY glMultMatrixd( const GLdouble *m );
\ GLAPI void GLAPIENTRY glMultMatrixf( const GLfloat *m );

\ GLAPI void GLAPIENTRY glRotated( GLdouble angle, GLdouble x, GLdouble y, GLdouble z );
\ GLAPI void GLAPIENTRY glRotatef( GLfloat angle, GLfloat x, GLfloat y, GLfloat z );

\ GLAPI void GLAPIENTRY glScaled( GLdouble x, GLdouble y, GLdouble z );
\ GLAPI void GLAPIENTRY glScalef( GLfloat x, GLfloat y, GLfloat z );

\ GLAPI void GLAPIENTRY glTranslated( GLdouble x, GLdouble y, GLdouble z );

(
    display lists 
)

\ GLAPI GLboolean GLAPIENTRY glIsList( GLuint list );

\ GLAPI void GLAPIENTRY glDeleteLists( GLuint list, GLsizei range );

\ GLAPI GLuint GLAPIENTRY glGenLists( GLsizei range );

\ GLAPI void GLAPIENTRY glNewList( GLuint list, GLenum mode );

\ GLAPI void GLAPIENTRY glEndList( void );

\ GLAPI void GLAPIENTRY glCallList( GLuint list );

\ GLAPI void GLAPIENTRY glCallLists( GLsizei n, GLenum type, const GLvoid *lists );

\ GLAPI void GLAPIENTRY glListBase( GLuint base );

(
    drawing functions
)

\ GLAPI void GLAPIENTRY glBegin( GLenum mode );
\ 
\ GLAPI void GLAPIENTRY glEnd( void );
\ 
\ 
\ GLAPI void GLAPIENTRY glVertex2d( GLdouble x, GLdouble y );
\ GLAPI void GLAPIENTRY glVertex2f( GLfloat x, GLfloat y );
\ GLAPI void GLAPIENTRY glVertex2i( GLint x, GLint y );
\ GLAPI void GLAPIENTRY glVertex2s( GLshort x, GLshort y );
\ 
\ GLAPI void GLAPIENTRY glVertex3d( GLdouble x, GLdouble y, GLdouble z );
\ GLAPI void GLAPIENTRY glVertex3f( GLfloat x, GLfloat y, GLfloat z );
\ GLAPI void GLAPIENTRY glVertex3i( GLint x, GLint y, GLint z );
\ GLAPI void GLAPIENTRY glVertex3s( GLshort x, GLshort y, GLshort z );
\ 
\ GLAPI void GLAPIENTRY glVertex4d( GLdouble x, GLdouble y, GLdouble z, GLdouble w );
\ GLAPI void GLAPIENTRY glVertex4f( GLfloat x, GLfloat y, GLfloat z, GLfloat w );
\ GLAPI void GLAPIENTRY glVertex4i( GLint x, GLint y, GLint z, GLint w );
\ GLAPI void GLAPIENTRY glVertex4s( GLshort x, GLshort y, GLshort z, GLshort w );
\ 
\ GLAPI void GLAPIENTRY glVertex2dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glVertex2fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glVertex2iv( const GLint *v );
\ GLAPI void GLAPIENTRY glVertex2sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glVertex3dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glVertex3fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glVertex3iv( const GLint *v );
\ GLAPI void GLAPIENTRY glVertex3sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glVertex4dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glVertex4fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glVertex4iv( const GLint *v );
\ GLAPI void GLAPIENTRY glVertex4sv( const GLshort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glNormal3b( GLbyte nx, GLbyte ny, GLbyte nz );
\ GLAPI void GLAPIENTRY glNormal3d( GLdouble nx, GLdouble ny, GLdouble nz );
\ GLAPI void GLAPIENTRY glNormal3f( GLfloat nx, GLfloat ny, GLfloat nz );
\ GLAPI void GLAPIENTRY glNormal3i( GLint nx, GLint ny, GLint nz );
\ GLAPI void GLAPIENTRY glNormal3s( GLshort nx, GLshort ny, GLshort nz );
\ 
\ GLAPI void GLAPIENTRY glNormal3bv( const GLbyte *v );
\ GLAPI void GLAPIENTRY glNormal3dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glNormal3fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glNormal3iv( const GLint *v );
\ GLAPI void GLAPIENTRY glNormal3sv( const GLshort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glIndexd( GLdouble c );
\ GLAPI void GLAPIENTRY glIndexf( GLfloat c );
\ GLAPI void GLAPIENTRY glIndexi( GLint c );
\ GLAPI void GLAPIENTRY glIndexs( GLshort c );
\ GLAPI void GLAPIENTRY glIndexub( GLubyte c );  /* 1.1 */
\ 
\ GLAPI void GLAPIENTRY glIndexdv( const GLdouble *c );
\ GLAPI void GLAPIENTRY glIndexfv( const GLfloat *c );
\ GLAPI void GLAPIENTRY glIndexiv( const GLint *c );
\ GLAPI void GLAPIENTRY glIndexsv( const GLshort *c );
\ GLAPI void GLAPIENTRY glIndexubv( const GLubyte *c );  /* 1.1 */
\ 
\ GLAPI void GLAPIENTRY glColor3b( GLbyte red, GLbyte green, GLbyte blue );
\ GLAPI void GLAPIENTRY glColor3d( GLdouble red, GLdouble green, GLdouble blue );
\ GLAPI void GLAPIENTRY glColor3f( GLfloat red, GLfloat green, GLfloat blue );
\ GLAPI void GLAPIENTRY glColor3i( GLint red, GLint green, GLint blue );
\ GLAPI void GLAPIENTRY glColor3s( GLshort red, GLshort green, GLshort blue );
\ GLAPI void GLAPIENTRY glColor3ub( GLubyte red, GLubyte green, GLubyte blue );
\ GLAPI void GLAPIENTRY glColor3ui( GLuint red, GLuint green, GLuint blue );
\ GLAPI void GLAPIENTRY glColor3us( GLushort red, GLushort green, GLushort blue );
\ 
\ GLAPI void GLAPIENTRY glColor4b( GLbyte red, GLbyte green,
\                                    GLbyte blue, GLbyte alpha );
\ GLAPI void GLAPIENTRY glColor4d( GLdouble red, GLdouble green,
\                                    GLdouble blue, GLdouble alpha );
\ GLAPI void GLAPIENTRY glColor4f( GLfloat red, GLfloat green,
\                                    GLfloat blue, GLfloat alpha );
\ GLAPI void GLAPIENTRY glColor4i( GLint red, GLint green,
\                                    GLint blue, GLint alpha );
\ GLAPI void GLAPIENTRY glColor4s( GLshort red, GLshort green,
\                                    GLshort blue, GLshort alpha );
\ GLAPI void GLAPIENTRY glColor4ub( GLubyte red, GLubyte green,
\                                     GLubyte blue, GLubyte alpha );
\ GLAPI void GLAPIENTRY glColor4ui( GLuint red, GLuint green,
\                                     GLuint blue, GLuint alpha );
\ GLAPI void GLAPIENTRY glColor4us( GLushort red, GLushort green,
\                                     GLushort blue, GLushort alpha );
\ 
\ 
\ GLAPI void GLAPIENTRY glColor3bv( const GLbyte *v );
\ GLAPI void GLAPIENTRY glColor3dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glColor3fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glColor3iv( const GLint *v );
\ GLAPI void GLAPIENTRY glColor3sv( const GLshort *v );
\ GLAPI void GLAPIENTRY glColor3ubv( const GLubyte *v );
\ GLAPI void GLAPIENTRY glColor3uiv( const GLuint *v );
\ GLAPI void GLAPIENTRY glColor3usv( const GLushort *v );
\ 
\ GLAPI void GLAPIENTRY glColor4bv( const GLbyte *v );
\ GLAPI void GLAPIENTRY glColor4dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glColor4fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glColor4iv( const GLint *v );
\ GLAPI void GLAPIENTRY glColor4sv( const GLshort *v );
\ GLAPI void GLAPIENTRY glColor4ubv( const GLubyte *v );
\ GLAPI void GLAPIENTRY glColor4uiv( const GLuint *v );
\ GLAPI void GLAPIENTRY glColor4usv( const GLushort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexCoord1d( GLdouble s );
\ GLAPI void GLAPIENTRY glTexCoord1f( GLfloat s );
\ GLAPI void GLAPIENTRY glTexCoord1i( GLint s );
\ GLAPI void GLAPIENTRY glTexCoord1s( GLshort s );
\ 
\ GLAPI void GLAPIENTRY glTexCoord2d( GLdouble s, GLdouble t );
\ GLAPI void GLAPIENTRY glTexCoord2f( GLfloat s, GLfloat t );
\ GLAPI void GLAPIENTRY glTexCoord2i( GLint s, GLint t );
\ GLAPI void GLAPIENTRY glTexCoord2s( GLshort s, GLshort t );
\ 
\ GLAPI void GLAPIENTRY glTexCoord3d( GLdouble s, GLdouble t, GLdouble r );
\ GLAPI void GLAPIENTRY glTexCoord3f( GLfloat s, GLfloat t, GLfloat r );
\ GLAPI void GLAPIENTRY glTexCoord3i( GLint s, GLint t, GLint r );
\ GLAPI void GLAPIENTRY glTexCoord3s( GLshort s, GLshort t, GLshort r );
\ 
\ GLAPI void GLAPIENTRY glTexCoord4d( GLdouble s, GLdouble t, GLdouble r, GLdouble q );
\ GLAPI void GLAPIENTRY glTexCoord4f( GLfloat s, GLfloat t, GLfloat r, GLfloat q );
\ GLAPI void GLAPIENTRY glTexCoord4i( GLint s, GLint t, GLint r, GLint q );
\ GLAPI void GLAPIENTRY glTexCoord4s( GLshort s, GLshort t, GLshort r, GLshort q );
\ 
\ GLAPI void GLAPIENTRY glTexCoord1dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glTexCoord1fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glTexCoord1iv( const GLint *v );
\ GLAPI void GLAPIENTRY glTexCoord1sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glTexCoord2dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glTexCoord2fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glTexCoord2iv( const GLint *v );
\ GLAPI void GLAPIENTRY glTexCoord2sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glTexCoord3dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glTexCoord3fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glTexCoord3iv( const GLint *v );
\ GLAPI void GLAPIENTRY glTexCoord3sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glTexCoord4dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glTexCoord4fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glTexCoord4iv( const GLint *v );
\ GLAPI void GLAPIENTRY glTexCoord4sv( const GLshort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glRasterPos2d( GLdouble x, GLdouble y );
\ GLAPI void GLAPIENTRY glRasterPos2f( GLfloat x, GLfloat y );
\ GLAPI void GLAPIENTRY glRasterPos2i( GLint x, GLint y );
\ GLAPI void GLAPIENTRY glRasterPos2s( GLshort x, GLshort y );
\ 
\ GLAPI void GLAPIENTRY glRasterPos3d( GLdouble x, GLdouble y, GLdouble z );
\ GLAPI void GLAPIENTRY glRasterPos3f( GLfloat x, GLfloat y, GLfloat z );
\ GLAPI void GLAPIENTRY glRasterPos3i( GLint x, GLint y, GLint z );
\ GLAPI void GLAPIENTRY glRasterPos3s( GLshort x, GLshort y, GLshort z );
\ 
\ GLAPI void GLAPIENTRY glRasterPos4d( GLdouble x, GLdouble y, GLdouble z, GLdouble w );
\ GLAPI void GLAPIENTRY glRasterPos4f( GLfloat x, GLfloat y, GLfloat z, GLfloat w );
\ GLAPI void GLAPIENTRY glRasterPos4i( GLint x, GLint y, GLint z, GLint w );
\ GLAPI void GLAPIENTRY glRasterPos4s( GLshort x, GLshort y, GLshort z, GLshort w );
\ 
\ GLAPI void GLAPIENTRY glRasterPos2dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glRasterPos2fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glRasterPos2iv( const GLint *v );
\ GLAPI void GLAPIENTRY glRasterPos2sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glRasterPos3dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glRasterPos3fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glRasterPos3iv( const GLint *v );
\ GLAPI void GLAPIENTRY glRasterPos3sv( const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glRasterPos4dv( const GLdouble *v );
\ GLAPI void GLAPIENTRY glRasterPos4fv( const GLfloat *v );
\ GLAPI void GLAPIENTRY glRasterPos4iv( const GLint *v );
\ GLAPI void GLAPIENTRY glRasterPos4sv( const GLshort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glRectd( GLdouble x1, GLdouble y1, GLdouble x2, GLdouble y2 );
\ GLAPI void GLAPIENTRY glRectf( GLfloat x1, GLfloat y1, GLfloat x2, GLfloat y2 );
\ GLAPI void GLAPIENTRY glRecti( GLint x1, GLint y1, GLint x2, GLint y2 );
\ GLAPI void GLAPIENTRY glRects( GLshort x1, GLshort y1, GLshort x2, GLshort y2 );
\ 
\ 
\ GLAPI void GLAPIENTRY glRectdv( const GLdouble *v1, const GLdouble *v2 );
\ GLAPI void GLAPIENTRY glRectfv( const GLfloat *v1, const GLfloat *v2 );
\ GLAPI void GLAPIENTRY glRectiv( const GLint *v1, const GLint *v2 );
\ GLAPI void GLAPIENTRY glRectsv( const GLshort *v1, const GLshort *v2 );
\ 
\ 
\ /*
\  * Vertex Arrays  (1.1)
\  */
\ 
\ GLAPI void GLAPIENTRY glVertexPointer( GLint size, GLenum type,
\                                        GLsizei stride, const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glNormalPointer( GLenum type, GLsizei stride,
\                                        const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glColorPointer( GLint size, GLenum type,
\                                       GLsizei stride, const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glIndexPointer( GLenum type, GLsizei stride,
\                                       const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glTexCoordPointer( GLint size, GLenum type, GLsizei stride, const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glEdgeFlagPointer( GLsizei stride, const GLvoid *ptr );
\ 
\ GLAPI void GLAPIENTRY glGetPointerv( GLenum pname, GLvoid **params );
\ 
\ GLAPI void GLAPIENTRY glArrayElement( GLint i );
\ 
\ GLAPI void GLAPIENTRY glDrawArrays( GLenum mode, GLint first, GLsizei count );
\ 
\ GLAPI void GLAPIENTRY glDrawElements( GLenum mode, GLsizei count, GLenum type, const GLvoid *indices );
\ 
\ GLAPI void GLAPIENTRY glInterleavedArrays( GLenum format, GLsizei stride, const GLvoid *pointer );

\ /*
\  * Lighting
\  */
\ 
\ GLAPI void GLAPIENTRY glShadeModel( GLenum mode );
\ 
\ GLAPI void GLAPIENTRY glLightf( GLenum light, GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glLighti( GLenum light, GLenum pname, GLint param );
\ GLAPI void GLAPIENTRY glLightfv( GLenum light, GLenum pname,
\                                  const GLfloat *params );
\ GLAPI void GLAPIENTRY glLightiv( GLenum light, GLenum pname,
\                                  const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetLightfv( GLenum light, GLenum pname,
\                                     GLfloat *params );
\ GLAPI void GLAPIENTRY glGetLightiv( GLenum light, GLenum pname,
\                                     GLint *params );
\ 
\ GLAPI void GLAPIENTRY glLightModelf( GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glLightModeli( GLenum pname, GLint param );
\ GLAPI void GLAPIENTRY glLightModelfv( GLenum pname, const GLfloat *params );
\ GLAPI void GLAPIENTRY glLightModeliv( GLenum pname, const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glMaterialf( GLenum face, GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glMateriali( GLenum face, GLenum pname, GLint param );
\ GLAPI void GLAPIENTRY glMaterialfv( GLenum face, GLenum pname, const GLfloat *params );
\ GLAPI void GLAPIENTRY glMaterialiv( GLenum face, GLenum pname, const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetMaterialfv( GLenum face, GLenum pname, GLfloat *params );
\ GLAPI void GLAPIENTRY glGetMaterialiv( GLenum face, GLenum pname, GLint *params );
\ 
\ GLAPI void GLAPIENTRY glColorMaterial( GLenum face, GLenum mode );
\ 
\ 
\ /*
\  * Raster functions
\  */
\ 
\ GLAPI void GLAPIENTRY glPixelZoom( GLfloat xfactor, GLfloat yfactor );
\ 
\ GLAPI void GLAPIENTRY glPixelStoref( GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glPixelStorei( GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glPixelTransferf( GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glPixelTransferi( GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glPixelMapfv( GLenum map, GLsizei mapsize,
\                                     const GLfloat *values );
\ GLAPI void GLAPIENTRY glPixelMapuiv( GLenum map, GLsizei mapsize,
\                                      const GLuint *values );
\ GLAPI void GLAPIENTRY glPixelMapusv( GLenum map, GLsizei mapsize,
\                                      const GLushort *values );
\ 
\ GLAPI void GLAPIENTRY glGetPixelMapfv( GLenum map, GLfloat *values );
\ GLAPI void GLAPIENTRY glGetPixelMapuiv( GLenum map, GLuint *values );
\ GLAPI void GLAPIENTRY glGetPixelMapusv( GLenum map, GLushort *values );
\ 
\ GLAPI void GLAPIENTRY glBitmap( GLsizei width, GLsizei height,
\                                 GLfloat xorig, GLfloat yorig,
\                                 GLfloat xmove, GLfloat ymove,
\                                 const GLubyte *bitmap );
\ 
\ GLAPI void GLAPIENTRY glReadPixels( GLint x, GLint y,
\                                     GLsizei width, GLsizei height,
\                                     GLenum format, GLenum type,
\                                     GLvoid *pixels );
\ 
\ GLAPI void GLAPIENTRY glDrawPixels( GLsizei width, GLsizei height,
\                                     GLenum format, GLenum type,
\                                     const GLvoid *pixels );
\ 
\ GLAPI void GLAPIENTRY glCopyPixels( GLint x, GLint y,
\                                     GLsizei width, GLsizei height,
\                                     GLenum type );
\ 
\ /*
\  * Stenciling
\  */
\ 
\ GLAPI void GLAPIENTRY glStencilFunc( GLenum func, GLint ref, GLuint mask );
\ 
\ GLAPI void GLAPIENTRY glStencilMask( GLuint mask );
\ 
\ GLAPI void GLAPIENTRY glStencilOp( GLenum fail, GLenum zfail, GLenum zpass );
\ 
\ GLAPI void GLAPIENTRY glClearStencil( GLint s );
\ 
\ 
\ 
\ /*
\  * Texture mapping
\  */
\ 
\ GLAPI void GLAPIENTRY glTexGend( GLenum coord, GLenum pname, GLdouble param );
\ GLAPI void GLAPIENTRY glTexGenf( GLenum coord, GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glTexGeni( GLenum coord, GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glTexGendv( GLenum coord, GLenum pname, const GLdouble *params );
\ GLAPI void GLAPIENTRY glTexGenfv( GLenum coord, GLenum pname, const GLfloat *params );
\ GLAPI void GLAPIENTRY glTexGeniv( GLenum coord, GLenum pname, const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetTexGendv( GLenum coord, GLenum pname, GLdouble *params );
\ GLAPI void GLAPIENTRY glGetTexGenfv( GLenum coord, GLenum pname, GLfloat *params );
\ GLAPI void GLAPIENTRY glGetTexGeniv( GLenum coord, GLenum pname, GLint *params );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexEnvf( GLenum target, GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glTexEnvi( GLenum target, GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glTexEnvfv( GLenum target, GLenum pname, const GLfloat *params );
\ GLAPI void GLAPIENTRY glTexEnviv( GLenum target, GLenum pname, const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetTexEnvfv( GLenum target, GLenum pname, GLfloat *params );
\ GLAPI void GLAPIENTRY glGetTexEnviv( GLenum target, GLenum pname, GLint *params );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexParameterf( GLenum target, GLenum pname, GLfloat param );
\ GLAPI void GLAPIENTRY glTexParameteri( GLenum target, GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glTexParameterfv( GLenum target, GLenum pname,
\                                           const GLfloat *params );
\ GLAPI void GLAPIENTRY glTexParameteriv( GLenum target, GLenum pname,
\                                           const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetTexParameterfv( GLenum target,
\                                            GLenum pname, GLfloat *params);
\ GLAPI void GLAPIENTRY glGetTexParameteriv( GLenum target,
\                                            GLenum pname, GLint *params );
\ 
\ GLAPI void GLAPIENTRY glGetTexLevelParameterfv( GLenum target, GLint level,
\                                                 GLenum pname, GLfloat *params );
\ GLAPI void GLAPIENTRY glGetTexLevelParameteriv( GLenum target, GLint level,
\                                                 GLenum pname, GLint *params );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexImage1D( GLenum target, GLint level,
\                                     GLint internalFormat,
\                                     GLsizei width, GLint border,
\                                     GLenum format, GLenum type,
\                                     const GLvoid *pixels );
\ 
\ GLAPI void GLAPIENTRY glTexImage2D( GLenum target, GLint level,
\                                     GLint internalFormat,
\                                     GLsizei width, GLsizei height,
\                                     GLint border, GLenum format, GLenum type,
\                                     const GLvoid *pixels );
\ 
\ GLAPI void GLAPIENTRY glGetTexImage( GLenum target, GLint level,
\                                      GLenum format, GLenum type,
\                                      GLvoid *pixels );
\ 
\ 
\ /* 1.1 functions */
\ 
\ GLAPI void GLAPIENTRY glGenTextures( GLsizei n, GLuint *textures );
\ 
\ GLAPI void GLAPIENTRY glDeleteTextures( GLsizei n, const GLuint *textures);
\ 
\ GLAPI void GLAPIENTRY glBindTexture( GLenum target, GLuint texture );
\ 
\ GLAPI void GLAPIENTRY glPrioritizeTextures( GLsizei n,
\                                             const GLuint *textures,
\                                             const GLclampf *priorities );
\ 
\ GLAPI GLboolean GLAPIENTRY glAreTexturesResident( GLsizei n,
\                                                   const GLuint *textures,
\                                                   GLboolean *residences );
\ 
\ GLAPI GLboolean GLAPIENTRY glIsTexture( GLuint texture );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexSubImage1D( GLenum target, GLint level,
\                                        GLint xoffset,
\                                        GLsizei width, GLenum format,
\                                        GLenum type, const GLvoid *pixels );
\ 
\ 
\ GLAPI void GLAPIENTRY glTexSubImage2D( GLenum target, GLint level,
\                                        GLint xoffset, GLint yoffset,
\                                        GLsizei width, GLsizei height,
\                                        GLenum format, GLenum type,
\                                        const GLvoid *pixels );
\ 
\ 
\ GLAPI void GLAPIENTRY glCopyTexImage1D( GLenum target, GLint level,
\                                         GLenum internalformat,
\                                         GLint x, GLint y,
\                                         GLsizei width, GLint border );
\ 
\ 
\ GLAPI void GLAPIENTRY glCopyTexImage2D( GLenum target, GLint level,
\                                         GLenum internalformat,
\                                         GLint x, GLint y,
\                                         GLsizei width, GLsizei height,
\                                         GLint border );
\ 
\ 
\ GLAPI void GLAPIENTRY glCopyTexSubImage1D( GLenum target, GLint level,
\                                            GLint xoffset, GLint x, GLint y,
\                                            GLsizei width );
\ 
\ 
\ GLAPI void GLAPIENTRY glCopyTexSubImage2D( GLenum target, GLint level,
\                                            GLint xoffset, GLint yoffset,
\                                            GLint x, GLint y,
\                                            GLsizei width, GLsizei height );
\ 
\ 
\ /*
\  * Evaluators
\  */
\ 
\ GLAPI void GLAPIENTRY glMap1d( GLenum target, GLdouble u1, GLdouble u2,
\                                GLint stride,
\                                GLint order, const GLdouble *points );
\ GLAPI void GLAPIENTRY glMap1f( GLenum target, GLfloat u1, GLfloat u2,
\                                GLint stride,
\                                GLint order, const GLfloat *points );
\ 
\ GLAPI void GLAPIENTRY glMap2d( GLenum target,
\ 		     GLdouble u1, GLdouble u2, GLint ustride, GLint uorder,
\ 		     GLdouble v1, GLdouble v2, GLint vstride, GLint vorder,
\ 		     const GLdouble *points );
\ GLAPI void GLAPIENTRY glMap2f( GLenum target,
\ 		     GLfloat u1, GLfloat u2, GLint ustride, GLint uorder,
\ 		     GLfloat v1, GLfloat v2, GLint vstride, GLint vorder,
\ 		     const GLfloat *points );
\ 
\ GLAPI void GLAPIENTRY glGetMapdv( GLenum target, GLenum query, GLdouble *v );
\ GLAPI void GLAPIENTRY glGetMapfv( GLenum target, GLenum query, GLfloat *v );
\ GLAPI void GLAPIENTRY glGetMapiv( GLenum target, GLenum query, GLint *v );
\ 
\ GLAPI void GLAPIENTRY glEvalCoord1d( GLdouble u );
\ GLAPI void GLAPIENTRY glEvalCoord1f( GLfloat u );
\ 
\ GLAPI void GLAPIENTRY glEvalCoord1dv( const GLdouble *u );
\ GLAPI void GLAPIENTRY glEvalCoord1fv( const GLfloat *u );
\ 
\ GLAPI void GLAPIENTRY glEvalCoord2d( GLdouble u, GLdouble v );
\ GLAPI void GLAPIENTRY glEvalCoord2f( GLfloat u, GLfloat v );
\ 
\ GLAPI void GLAPIENTRY glEvalCoord2dv( const GLdouble *u );
\ GLAPI void GLAPIENTRY glEvalCoord2fv( const GLfloat *u );
\ 
\ GLAPI void GLAPIENTRY glMapGrid1d( GLint un, GLdouble u1, GLdouble u2 );
\ GLAPI void GLAPIENTRY glMapGrid1f( GLint un, GLfloat u1, GLfloat u2 );
\ 
\ GLAPI void GLAPIENTRY glMapGrid2d( GLint un, GLdouble u1, GLdouble u2,
\                                    GLint vn, GLdouble v1, GLdouble v2 );
\ GLAPI void GLAPIENTRY glMapGrid2f( GLint un, GLfloat u1, GLfloat u2,
\                                    GLint vn, GLfloat v1, GLfloat v2 );
\ 
\ GLAPI void GLAPIENTRY glEvalPoint1( GLint i );
\ 
\ GLAPI void GLAPIENTRY glEvalPoint2( GLint i, GLint j );
\ 
\ GLAPI void GLAPIENTRY glEvalMesh1( GLenum mode, GLint i1, GLint i2 );
\ 
\ GLAPI void GLAPIENTRY glEvalMesh2( GLenum mode, GLint i1, GLint i2, GLint j1, GLint j2 );
\ 
\ 
\ /*
\  * Fog
\  */
\ 
\ GLAPI void GLAPIENTRY glFogf( GLenum pname, GLfloat param );
\ 
\ GLAPI void GLAPIENTRY glFogi( GLenum pname, GLint param );
\ 
\ GLAPI void GLAPIENTRY glFogfv( GLenum pname, const GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glFogiv( GLenum pname, const GLint *params );
\ 
\ 
\ /*
\  * Selection and Feedback
\  */
\ 
\ GLAPI void GLAPIENTRY glFeedbackBuffer( GLsizei size, GLenum type, GLfloat *buffer );
\ 
\ GLAPI void GLAPIENTRY glPassThrough( GLfloat token );
\ 
\ GLAPI void GLAPIENTRY glSelectBuffer( GLsizei size, GLuint *buffer );
\ 
\ GLAPI void GLAPIENTRY glInitNames( void );
\ 
\ GLAPI void GLAPIENTRY glLoadName( GLuint name );
\ 
\ GLAPI void GLAPIENTRY glPushName( GLuint name );
\ 
\ GLAPI void GLAPIENTRY glPopName( void );
\ 
\ 
\ 
\ /*
\  * OpenGL 1.2
\  */
\ 
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
\ GLAPI void GLAPIENTRY glDrawRangeElements( GLenum mode, GLuint start,
\ 	GLuint end, GLsizei count, GLenum type, const GLvoid *indices );
\ 
\ GLAPI void GLAPIENTRY glTexImage3D( GLenum target, GLint level,
\                                       GLint internalFormat,
\                                       GLsizei width, GLsizei height,
\                                       GLsizei depth, GLint border,
\                                       GLenum format, GLenum type,
\                                       const GLvoid *pixels );
\ 
\ GLAPI void GLAPIENTRY glTexSubImage3D( GLenum target, GLint level,
\                                          GLint xoffset, GLint yoffset,
\                                          GLint zoffset, GLsizei width,
\                                          GLsizei height, GLsizei depth,
\                                          GLenum format,
\                                          GLenum type, const GLvoid *pixels);
\ 
\ GLAPI void GLAPIENTRY glCopyTexSubImage3D( GLenum target, GLint level,
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
\ GLAPI void GLAPIENTRY glColorTable( GLenum target, GLenum internalformat,
\                                     GLsizei width, GLenum format,
\                                     GLenum type, const GLvoid *table );
\ 
\ GLAPI void GLAPIENTRY glColorSubTable( GLenum target,
\                                        GLsizei start, GLsizei count,
\                                        GLenum format, GLenum type,
\                                        const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glColorTableParameteriv(GLenum target, GLenum pname,
\                                               const GLint *params);
\ 
\ GLAPI void GLAPIENTRY glColorTableParameterfv(GLenum target, GLenum pname,
\                                               const GLfloat *params);
\ 
\ GLAPI void GLAPIENTRY glCopyColorSubTable( GLenum target, GLsizei start,
\                                            GLint x, GLint y, GLsizei width );
\ 
\ GLAPI void GLAPIENTRY glCopyColorTable( GLenum target, GLenum internalformat,
\                                         GLint x, GLint y, GLsizei width );
\ 
\ GLAPI void GLAPIENTRY glGetColorTable( GLenum target, GLenum format,
\                                        GLenum type, GLvoid *table );
\ 
\ GLAPI void GLAPIENTRY glGetColorTableParameterfv( GLenum target, GLenum pname,
\                                                   GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glGetColorTableParameteriv( GLenum target, GLenum pname,
\                                                   GLint *params );
\ 
\ GLAPI void GLAPIENTRY glBlendEquation( GLenum mode );
\ 
\ GLAPI void GLAPIENTRY glBlendColor( GLclampf red, GLclampf green,
\                                     GLclampf blue, GLclampf alpha );
\ 
\ GLAPI void GLAPIENTRY glHistogram( GLenum target, GLsizei width,
\ 				   GLenum internalformat, GLboolean sink );
\ 
\ GLAPI void GLAPIENTRY glResetHistogram( GLenum target );
\ 
\ GLAPI void GLAPIENTRY glGetHistogram( GLenum target, GLboolean reset,
\ 				      GLenum format, GLenum type,
\ 				      GLvoid *values );
\ 
\ GLAPI void GLAPIENTRY glGetHistogramParameterfv( GLenum target, GLenum pname,
\ 						 GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glGetHistogramParameteriv( GLenum target, GLenum pname,
\ 						 GLint *params );
\ 
\ GLAPI void GLAPIENTRY glMinmax( GLenum target, GLenum internalformat,
\ 				GLboolean sink );
\ 
\ GLAPI void GLAPIENTRY glResetMinmax( GLenum target );
\ 
\ GLAPI void GLAPIENTRY glGetMinmax( GLenum target, GLboolean reset,
\                                    GLenum format, GLenum types,
\                                    GLvoid *values );
\ 
\ GLAPI void GLAPIENTRY glGetMinmaxParameterfv( GLenum target, GLenum pname,
\ 					      GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glGetMinmaxParameteriv( GLenum target, GLenum pname,
\ 					      GLint *params );
\ 
\ GLAPI void GLAPIENTRY glConvolutionFilter1D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLenum format, GLenum type,
\ 	const GLvoid *image );
\ 
\ GLAPI void GLAPIENTRY glConvolutionFilter2D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLsizei height, GLenum format,
\ 	GLenum type, const GLvoid *image );
\ 
\ GLAPI void GLAPIENTRY glConvolutionParameterf( GLenum target, GLenum pname,
\ 	GLfloat params );
\ 
\ GLAPI void GLAPIENTRY glConvolutionParameterfv( GLenum target, GLenum pname,
\ 	const GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glConvolutionParameteri( GLenum target, GLenum pname,
\ 	GLint params );
\ 
\ GLAPI void GLAPIENTRY glConvolutionParameteriv( GLenum target, GLenum pname,
\ 	const GLint *params );
\ 
\ GLAPI void GLAPIENTRY glCopyConvolutionFilter1D( GLenum target,
\ 	GLenum internalformat, GLint x, GLint y, GLsizei width );
\ 
\ GLAPI void GLAPIENTRY glCopyConvolutionFilter2D( GLenum target,
\ 	GLenum internalformat, GLint x, GLint y, GLsizei width,
\ 	GLsizei height);
\ 
\ GLAPI void GLAPIENTRY glGetConvolutionFilter( GLenum target, GLenum format,
\ 	GLenum type, GLvoid *image );
\ 
\ GLAPI void GLAPIENTRY glGetConvolutionParameterfv( GLenum target, GLenum pname,
\ 	GLfloat *params );
\ 
\ GLAPI void GLAPIENTRY glGetConvolutionParameteriv( GLenum target, GLenum pname,
\ 	GLint *params );
\ 
\ GLAPI void GLAPIENTRY glSeparableFilter2D( GLenum target,
\ 	GLenum internalformat, GLsizei width, GLsizei height, GLenum format,
\ 	GLenum type, const GLvoid *row, const GLvoid *column );
\ 
\ GLAPI void GLAPIENTRY glGetSeparableFilter( GLenum target, GLenum format,
\ 	GLenum type, GLvoid *row, GLvoid *column, GLvoid *span );
\ 
\ 
\ 
\ 
\ /*
\  * OpenGL 1.3
\  */
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
\ GLAPI void GLAPIENTRY glActiveTexture( GLenum texture );
\ 
\ GLAPI void GLAPIENTRY glClientActiveTexture( GLenum texture );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexImage1D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexImage2D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexImage3D( GLenum target, GLint level, GLenum internalformat, GLsizei width, GLsizei height, GLsizei depth, GLint border, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexSubImage1D( GLenum target, GLint level, GLint xoffset, GLsizei width, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexSubImage2D( GLenum target, GLint level, GLint xoffset, GLint yoffset, GLsizei width, GLsizei height, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glCompressedTexSubImage3D( GLenum target, GLint level, GLint xoffset, GLint yoffset, GLint zoffset, GLsizei width, GLsizei height, GLsizei depth, GLenum format, GLsizei imageSize, const GLvoid *data );
\ 
\ GLAPI void GLAPIENTRY glGetCompressedTexImage( GLenum target, GLint lod, GLvoid *img );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1d( GLenum target, GLdouble s );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1dv( GLenum target, const GLdouble *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1f( GLenum target, GLfloat s );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1fv( GLenum target, const GLfloat *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1i( GLenum target, GLint s );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1iv( GLenum target, const GLint *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1s( GLenum target, GLshort s );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord1sv( GLenum target, const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2d( GLenum target, GLdouble s, GLdouble t );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2dv( GLenum target, const GLdouble *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2f( GLenum target, GLfloat s, GLfloat t );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2fv( GLenum target, const GLfloat *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2i( GLenum target, GLint s, GLint t );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2iv( GLenum target, const GLint *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2s( GLenum target, GLshort s, GLshort t );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord2sv( GLenum target, const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3d( GLenum target, GLdouble s, GLdouble t, GLdouble r );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3dv( GLenum target, const GLdouble *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3f( GLenum target, GLfloat s, GLfloat t, GLfloat r );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3fv( GLenum target, const GLfloat *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3i( GLenum target, GLint s, GLint t, GLint r );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3iv( GLenum target, const GLint *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3s( GLenum target, GLshort s, GLshort t, GLshort r );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord3sv( GLenum target, const GLshort *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4d( GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4dv( GLenum target, const GLdouble *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4f( GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4fv( GLenum target, const GLfloat *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4i( GLenum target, GLint s, GLint t, GLint r, GLint q );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4iv( GLenum target, const GLint *v );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4s( GLenum target, GLshort s, GLshort t, GLshort r, GLshort q );
\ 
\ GLAPI void GLAPIENTRY glMultiTexCoord4sv( GLenum target, const GLshort *v );
\ 
\ 
\ GLAPI void GLAPIENTRY glLoadTransposeMatrixd( const GLdouble m[16] );
\ 
\ GLAPI void GLAPIENTRY glLoadTransposeMatrixf( const GLfloat m[16] );
\ 
\ GLAPI void GLAPIENTRY glMultTransposeMatrixd( const GLdouble m[16] );
\ 
\ GLAPI void GLAPIENTRY glMultTransposeMatrixf( const GLfloat m[16] );
\ 
\ GLAPI void GLAPIENTRY glSampleCoverage( GLclampf value, GLboolean invert );
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
\ /*
\  * GL_ARB_multitexture (ARB extension 1 and OpenGL 1.2.1)
\  */
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
\ GLAPI void GLAPIENTRY glActiveTextureARB(GLenum texture);
\ GLAPI void GLAPIENTRY glClientActiveTextureARB(GLenum texture);
\ GLAPI void GLAPIENTRY glMultiTexCoord1dARB(GLenum target, GLdouble s);
\ GLAPI void GLAPIENTRY glMultiTexCoord1dvARB(GLenum target, const GLdouble *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord1fARB(GLenum target, GLfloat s);
\ GLAPI void GLAPIENTRY glMultiTexCoord1fvARB(GLenum target, const GLfloat *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord1iARB(GLenum target, GLint s);
\ GLAPI void GLAPIENTRY glMultiTexCoord1ivARB(GLenum target, const GLint *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord1sARB(GLenum target, GLshort s);
\ GLAPI void GLAPIENTRY glMultiTexCoord1svARB(GLenum target, const GLshort *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord2dARB(GLenum target, GLdouble s, GLdouble t);
\ GLAPI void GLAPIENTRY glMultiTexCoord2dvARB(GLenum target, const GLdouble *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord2fARB(GLenum target, GLfloat s, GLfloat t);
\ GLAPI void GLAPIENTRY glMultiTexCoord2fvARB(GLenum target, const GLfloat *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord2iARB(GLenum target, GLint s, GLint t);
\ GLAPI void GLAPIENTRY glMultiTexCoord2ivARB(GLenum target, const GLint *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord2sARB(GLenum target, GLshort s, GLshort t);
\ GLAPI void GLAPIENTRY glMultiTexCoord2svARB(GLenum target, const GLshort *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord3dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r);
\ GLAPI void GLAPIENTRY glMultiTexCoord3dvARB(GLenum target, const GLdouble *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord3fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r);
\ GLAPI void GLAPIENTRY glMultiTexCoord3fvARB(GLenum target, const GLfloat *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord3iARB(GLenum target, GLint s, GLint t, GLint r);
\ GLAPI void GLAPIENTRY glMultiTexCoord3ivARB(GLenum target, const GLint *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord3sARB(GLenum target, GLshort s, GLshort t, GLshort r);
\ GLAPI void GLAPIENTRY glMultiTexCoord3svARB(GLenum target, const GLshort *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord4dARB(GLenum target, GLdouble s, GLdouble t, GLdouble r, GLdouble q);
\ GLAPI void GLAPIENTRY glMultiTexCoord4dvARB(GLenum target, const GLdouble *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord4fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
\ GLAPI void GLAPIENTRY glMultiTexCoord4fvARB(GLenum target, const GLfloat *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord4iARB(GLenum target, GLint s, GLint t, GLint r, GLint q);
\ GLAPI void GLAPIENTRY glMultiTexCoord4ivARB(GLenum target, const GLint *v);
\ GLAPI void GLAPIENTRY glMultiTexCoord4sARB(GLenum target, GLshort s, GLshort t, GLshort r, GLshort q);
\ GLAPI void GLAPIENTRY glMultiTexCoord4svARB(GLenum target, const GLshort *v);
\ 
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



END-C-LIBRARY
