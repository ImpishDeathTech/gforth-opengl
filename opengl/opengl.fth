\ opengl.fth

\ This file is not a part of gforth or an official implementation of the Mesa 3_D graphics lib


\ BSD 3_Clause License
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

C_LIBRARY OpenGL
s" GL"   ADD_LIB

\c #if defined(__unix__) 

\c #if defined(__linux__) || defined(__FreeBSD__) || defined(__FreeBSD_kernel__)
\c #include <GL/gl.h>
\c #endif

\c #elif defined(__APPLE__) && defined(__MACH__)
\c #include <OpenGL/gl.h>

\c #endif

\ 
\   glConstants 
\

\ boolean values
0 CONSTANT glTrue 
1 CONSTANT glFalse 

true   CONSTANT __gl_fs_
glTrue CONSTANT __gl_h_

HEX
\ data sizes
4  CONSTANT GLenum 
1  CONSTANT GLbyte
1  CONSTANT GLboolean 
4  CONSTANT GLbitfield
2  CONSTANT GLshort
4  CONSTANT GLint
1  CONSTANT GLubyte
2  CONSTANT GLushort
4  CONSTANT GLuint
4  CONSTANT GLsizei 
8  CONSTANT GLfloat
16 CONSTANT GLdouble 
8  CONSTANT GLclampf 
16 CONSTANT GLclampd

\ data types

1400 CONSTANT GL_BYTE
1401 CONSTANT GL_UBYTE
1402 CONSTANT GL_SHORT
1403 CONSTANT GL_USHORT  
1404 CONSTANT GL_INT
1405 CONSTANT GL_UINT
1406 CONSTANT GL_FLOAT 
1407 CONSTANT GL_2BYTES
1408 CONSTANT GL_3BYTES
1409 CONSTANT GL_4BYTES
140A CONSTANT GL_DOUBLE

\ primitives
0000 CONSTANT GL_POINTS
0001 CONSTANT GL_LINES  
0002 CONSTANT GL_LINE_LOOP
0003 CONSTANT GL_LINE_STRIP 
0004 CONSTANT GL_TRIANGLES 
0005 CONSTANT GL_TRIANGLE_STRIP 
0006 CONSTANT GL_TRIANGLE_FAN 
0007 CONSTANT GL_QUADS 
0008 CONSTANT GL_QUAD_STRIP  
0009 CONSTANT GL_POLYGON

\ vertex arrays
8074 CONSTANT GL_VERTEX_ARRAY 
8075 CONSTANT GL_NORMAL_ARRAY
8076 CONSTANT GL_COLOR_ARRAY
8077 CONSTANT GL_INDEX_ARRAY 
8078 CONSTANT GL_TEXTEURE_COORD_ARRAY 
8079 CONSTANT GL_EDGE_FLAG_ARRAY 
807A CONSTANT GL_VERTEX_ARRAY_SIZE 
807B CONSTANT GL_VERTEX_ARRAY_TYPE 
807C CONSTANT GL_VERTEX_ARRAY_STRIDE
807E CONSTANT GL_NORMAL_ARRAY_TYPE 
807F CONSTANT GL_NORMAL_ARRAY_STRIDE
8081 CONSTANT GL_COLOR_ARRAY_SIZE 
8082 CONSTANT GL_COLOR_ARRAY_TYPE
8083 CONSTANT GL_COLOR_ARRAY_STRIDE 
8085 CONSTANT GL_INDEX_ARRAY_TYPE
8086 CONSTANT GL_INDEX_ARRAY_STRIDE 
8088 CONSTANT GL_TEXTURE_COORD_ARRAY_SIZE 
8089 CONSTANT GL_TEXTURE_COORD_ARRAY_TYPE 
808A CONSTANT GL_TEXTURE_COORD_ARRAY_STRIDE
808C CONSTANT GL_EDGE_FLAG_ARRAY_STRIDE 
808E CONSTANT GL_VERTEX_ARRAY_POINTER 
808F CONSTANT GL_NORMAL_ARRAY_POINTER 
8090 CONSTANT GL_COLOR_ARRAY_POINTER 
8091 CONSTANT GL_INDEX_ARRAY_POINTER 
8092 CONSTANT GL_TEXTURE_COORD_ARRAY_POINTER 
8093 CONSTANT GL_EDGE_FLAG_ARRAY_POINTER
2A20 CONSTANT GL_V2F 
2A21 CONSTANT GL_V3F
2A22 CONSTANT GL_C4UB_V2F 
2A23 CONSTANT GL_C4UB_V3F
2A24 CONSTANT GL_C3F_V3F
2A25 CONSTANT GL_N3F_V3F 
2A26 CONSTANT GL_C4F_N3F_V3F
2A27 CONSTANT GL_T2F_V3F 
2A28 CONSTANT GL_T4F_V3F
2A29 CONSTANT GL_T2F_C4UB_V3F 
2A2A CONSTANT GL_T2F_C3F_V3F 
2A2B CONSTANT GL_T2F_N3F_V3F
2A2C CONSTANT GL_T2F_C4F_N3F_V3F 
2A2D CONSTANT GL_T3F_C4F_N3F_V4F

\ matrix mode 
0BA0 CONSTANT GL_MATRIX_MODE
1700 CONSTANT GL_MODELVIEW
1701 CONSTANT GL_PROJECTION
1702 CONSTANT GL_TEXTURE

\ points
0B10 CONSTANT GL_POINT_SMOOTH
0B11 CONSTANT GL_POINT_SIZE 
0B13 CONSTANT GL_POINT_SIZE_GRANULARITY
0B12 CONSTANT GL_POINT_SIZE_RANGE

\ lines
0B20 CONSTANT GL_LINE_SMOOTH 
0B24 CONSTANT GL_LINE_STIPPLE
0B25 CONSTANT GL_LINE_STIPPLE_PATTERN 
0B26 CONSTANT GL_LINE_STIPPLE_REPEAT
0B21 CONSTANT GL_LINE_WIDTH
0B23 CONSTANT GL_LINE_WIDTH_GRANULARITY 
0B22 CONSTANT GL_LINE_WIDTH_RANGE

\ polygons
1B00 CONSTANT GL_POINT 
1B01 CONSTANT GL_LINE
1B02 CONSTANT GL_FILL 
0900 CONSTANT GL_CW
0901 CONSTANT GL_CCW
0404 CONSTANT GL_FRONT
0405 CONSTANT GL_BACK
0B40 CONSTANT GL_POLYGON_MODE 
0B41 CONSTANT GL_POLYGON_SMOOTH 
0B42 CONSTANT GL_POLYGON_STIPPLE
0B43 CONSTANT GL_EDGE_FLAG 
0B44 CONSTANT GL_CULL_FACE
0B45 CONSTANT GL_CULL_FACE_MODE 
0B46 CONSTANT GL_FRONT_FACE 
8038 CONSTANT GL_POLYGON_OFFSET_FACTOR
2A00 CONSTANT GL_POLYGON_OFFSET_UNITS
2A01 CONSTANT GL_POLYGON_OFFSET_POINT 
2A02 CONSTANT GL_POLYGON_OFFSET_LINE 
8037 CONSTANT GL_POLYGON_OFFSET_FILL

\ display lists
1300 CONSTANT GL_COMPILE				
1301 CONSTANT GL_COMPILE_AND_EXECUTE	
0B32 CONSTANT GL_LIST_BASE			
0B33 CONSTANT GL_LIST_INDEX			
0B30 CONSTANT GL_LIST_MODE

\ depth buffer
0200 CONSTANT GL_NEVER			
0201 CONSTANT GL_LESS				
0202 CONSTANT GL_EQUAL			
0203 CONSTANT GL_LEQUAL			
0204 CONSTANT GL_GREATER			
0205 CONSTANT GL_NOTEQUAL			
0206 CONSTANT GL_GEQUAL			
0207 CONSTANT GL_ALWAYS			
0B71 CONSTANT GL_DEPTH_TEST		
0D56 CONSTANT GL_DEPTH_BITS		
0B73 CONSTANT GL_DEPTH_CLEAR_VALUE
0B74 CONSTANT GL_DEPTH_FUNC		
0B70 CONSTANT GL_DEPTH_RANGE		
0B72 CONSTANT GL_DEPTH_WRITEMASK	
1902 CONSTANT GL_DEPTH_COMPONENT

\ lighting
0B50 CONSTANT GL_LIGHTING				      
4000 CONSTANT GL_LIGHT0				      
4001 CONSTANT GL_LIGHT1				      
4002 CONSTANT GL_LIGHT2				      
4003 CONSTANT GL_LIGHT3				      
4004 CONSTANT GL_LIGHT4				      
4005 CONSTANT GL_LIGHT5				      
4006 CONSTANT GL_LIGHT6				      
4007 CONSTANT GL_LIGHT7				      
1205 CONSTANT GL_SPOT_EXPONENT		      
1206 CONSTANT GL_SPOT_CUTOFF			      
12   CONSTANT GL_CONSTANT_ATTENUATION	      
12   CONSTANT GL_LINEAR_ATTENUATION	      
12   CONSTANT GL_QUADRATIC_ATTENUATION      
1200 CONSTANT GL_AMBIENT				      
1201 CONSTANT GL_DIFFUSE				      
1202 CONSTANT GL_SPECULAR				      
1601 CONSTANT GL_SHININESS			      
1600 CONSTANT GL_EMISSION				      
1203 CONSTANT GL_POSITION				      
1204 CONSTANT GL_SPOT_DIRECTION		      
16   CONSTANT GL_AMBIENT_AND_DIFFUSE	      
1603 CONSTANT GL_COLOR_INDEXES		      
0B   CONSTANT GL_LIGHT_MODEL_TWO_SIDE	
0B   CONSTANT GL_LIGHT_MODEL_LOCAL_VIEWER
0B   CONSTANT GL_LIGHT_MODEL_AMBIENT	
0408 CONSTANT GL_FRONT_AND_BACK			  
0B54 CONSTANT GL_SHADE_MODEL				  
1D00 CONSTANT GL_FLAT					      
1D01 CONSTANT GL_SMOOTH				      
0B57 CONSTANT GL_COLOR_MATERIAL			  
0B   CONSTANT GL_COLOR_MATERIAL_FACE	
0B   CONSTANT GL_COLOR_MATERIAL_PARAMETER
0BA1 CONSTANT GL_NORMALIZE				  

\ user clipping panes
3000 CONSTANT GL_CLIP_PLANE0
3001 CONSTANT GL_CLIP_PLANE1
3002 CONSTANT GL_CLIP_PLANE2
3003 CONSTANT GL_CLIP_PLANE3
3004 CONSTANT GL_CLIP_PLANE4
3005 CONSTANT GL_CLIP_PLANE5

\ accumulation buffer
0D58 CONSTANT GL_ACCUM_RED_BITS		 
0D59 CONSTANT GL_ACCUM_GREEN_BITS		 
0D5A CONSTANT GL_ACCUM_BLUE_BITS		 
0D5B CONSTANT GL_ACCUM_ALPHA_BITS		 
0B80 CONSTANT GL_ACCUM_CLEAR_VALUE	 
0100 CONSTANT GL_ACCUM				 
0104 CONSTANT GL_ADD					 
0101 CONSTANT GL_LOAD					 
0103 CONSTANT GL_MULT					 
0102 CONSTANT GL_RETURN				 

\ alpha testing
0BC0 CONSTANT GL_ALPHA_TEST
0BC2 CONSTANT GL_ALPHA_TEST_REF
0BC1 CONSTANT GL_ALPHA_TEST_FUNC

\ blending
0BE2 CONSTANT GL_BLEND				
0BE1 CONSTANT GL_BLEND_SRC			
0BE0 CONSTANT GL_BLEND_DST			
0000 CONSTANT GL_ZERO					
0001 CONSTANT GL_ONE					
0300 CONSTANT GL_SRC_COLOR			
0301 CONSTANT GL_ONE_MINUS_SRC_COLOR	
0302 CONSTANT GL_SRC_ALPHA			
0303 CONSTANT GL_ONE_MINUS_SRC_ALPHA	
0304 CONSTANT GL_DST_ALPHA			
0305 CONSTANT GL_ONE_MINUS_DST_ALPHA	
0306 CONSTANT GL_DST_COLOR			
0307 CONSTANT GL_ONE_MINUS_DST_COLOR	
0308 CONSTANT GL_SRC_ALPHA_SATURATE	

\ render mode
1C01 CONSTANT GL_FEEDBACK	
1C00 CONSTANT GL_RENDER	
1C02 CONSTANT GL_SELECT	

\ feedback
0600 CONSTANT GL_2D					    
0601 CONSTANT GL_3D					    
0602 CONSTANT GL_3D_COLOR				    
0603 CONSTANT GL_3D_COLOR_TEXTURE			
0604 CONSTANT GL_4D_COLOR_TEXTURE			
0701 CONSTANT GL_POINT_TOKEN				
0702 CONSTANT GL_LINE_TOKEN				
0707 CONSTANT GL_LINE_RESET_TOKEN			
0703 CONSTANT GL_POLYGON_TOKEN			
0704 CONSTANT GL_BITMAP_TOKEN				
0705 CONSTANT GL_DRAW_PIXEL_TOKEN			
0706 CONSTANT GL_COPY_PIXEL_TOKEN			
0700 CONSTANT GL_PASS_THROUGH_TOKEN		
0DF0 CONSTANT GL_FEEDBACK_BUFFER_POINTER	
0DF1 CONSTANT GL_FEEDBACK_BUFFER_SIZE		
0DF2 CONSTANT GL_FEEDBACK_BUFFER_TYPE		

\ selection 
0DF3 CONSTANT GL_SELECTION_BUFFER_POINTER	
0DF4 CONSTANT GL_SELECTION_BUFFER_SIZE	

\ fog
0B60 CONSTANT GL_FOG			
0B65 CONSTANT GL_FOG_MODE		
0B62 CONSTANT GL_FOG_DENSITY	
0B66 CONSTANT GL_FOG_COLOR	
0B61 CONSTANT GL_FOG_INDEX	
0B63 CONSTANT GL_FOG_START	
0B64 CONSTANT GL_FOG_END		
2601 CONSTANT GL_LINEAR		
0800 CONSTANT GL_EXP			
0801 CONSTANT GL_EXP2

\ logic ops
0BF1 CONSTANT GL_LOGIC_OP		
0BF1 CONSTANT GL_INDEX_LOGIC_OP
0BF2 CONSTANT GL_COLOR_LOGIC_OP
0BF0 CONSTANT GL_LOGIC_OP_MODE
1500 CONSTANT GL_CLEAR		
150F CONSTANT GL_SET			
1503 CONSTANT GL_COPY			
150C CONSTANT GL_COPY_INVERTED
1505 CONSTANT GL_NOOP			
150A CONSTANT GL_INVERT		
1501 CONSTANT GL_AND			
150E CONSTANT GL_NAND			
1507 CONSTANT GL_OR			
1508 CONSTANT GL_NOR			
1506 CONSTANT GL_XOR			
1509 CONSTANT GL_EQUIV		
1502 CONSTANT GL_AND_REVERSE	
1504 CONSTANT GL_AND_INVERTED	
150B CONSTANT GL_OR_REVERSE	
150D CONSTANT GL_OR_INVERTED	

0D57 CONSTANT GL_STENCIL_BITS				
0B90 CONSTANT GL_STENCIL_TEST				
0B91 CONSTANT GL_STENCIL_CLEAR_VALUE		
0B92 CONSTANT GL_STENCIL_FUNC				
0B93 CONSTANT GL_STENCIL_VALUE_MASK		
0B94 CONSTANT GL_STENCIL_FAIL				
0B95 CONSTANT GL_STENCIL_PASS_DEPTH_FAIL	
0B96 CONSTANT GL_STENCIL_PASS_DEPTH_PASS	
0B97 CONSTANT GL_STENCIL_REF				
0B98 CONSTANT GL_STENCIL_WRITEMASK		
1901 CONSTANT GL_STENCIL_INDEX			
1E00 CONSTANT GL_KEEP					    
1E01 CONSTANT GL_REPLACE				    
1E02 CONSTANT GL_INCR					    
1E03 CONSTANT GL_DECR					    

\ buffers, pixel drawing/reading 
0000 CONSTANT GL_NONE					
0406 CONSTANT GL_LEFT					
0407 CONSTANT GL_RIGHT
0400 CONSTANT GL_FRONT_LEFT	
0401 CONSTANT GL_FRONT_RIGHT	
0402 CONSTANT GL_BACK_LEFT	
0403 CONSTANT GL_BACK_RIGHT	
0409 CONSTANT GL_AUX0			
040A CONSTANT GL_AUX1			
040B CONSTANT GL_AUX2			
040C CONSTANT GL_AUX3			
1900 CONSTANT GL_COLOR_INDEX	
1903 CONSTANT GL_RED			
1904 CONSTANT GL_GREEN		
1905 CONSTANT GL_BLUE			
1906 CONSTANT GL_ALPHA		
1909 CONSTANT GL_LUMINANCE	
190A CONSTANT GL_LUMINANCE_ALPHA
0D55 CONSTANT GL_ALPHA_BITS	
0D52 CONSTANT GL_RED_BITS		
0D53 CONSTANT GL_GREEN_BITS	
0D54 CONSTANT GL_BLUE_BITS	
0D51 CONSTANT GL_INDEX_BITS	
0D50 CONSTANT GL_SUBPIXEL_BITS
0C00 CONSTANT GL_AUX_BUFFERS	
0C02 CONSTANT GL_READ_BUFFER	
0C01 CONSTANT GL_DRAW_BUFFER	
0C32 CONSTANT GL_DOUBLEBUFFER	
0C33 CONSTANT GL_STEREO		
1A00 CONSTANT GL_BITMAP		
1800 CONSTANT GL_COLOR		
1801 CONSTANT GL_DEPTH		
1802 CONSTANT GL_STENCIL		
0BD0 CONSTANT GL_DITHER		
1907 CONSTANT GL_RGB			
1908 CONSTANT GL_RGBA			

\ implementation limits
0B31 CONSTANT GL_MAX_LIST_NESTING			    
0D30 CONSTANT GL_MAX_EVAL_ORDER			    
0D31 CONSTANT GL_MAX_LIGHTS				    
0D32 CONSTANT GL_MAX_CLIP_PLANES			    
0D33 CONSTANT GL_MAX_TEXTURE_SIZE			    
0D34 CONSTANT GL_MAX_PIXEL_MAP_TABLE			
0D35 CONSTANT GL_MAX_ATTRIB_STACK_DEPTH		
0D36 CONSTANT GL_MAX_MODELVIEW_STACK_DEPTH    
0D37 CONSTANT GL_MAX_NAME_STACK_DEPTH			
0D38 CONSTANT GL_MAX_PROJECTION_STACK_DEPTH	
0D39 CONSTANT GL_MAX_TEXTURE_STACK_DEPTH		
0D3A CONSTANT GL_MAX_VIEWPORT_DIMS			
0D3B CONSTANT GL_MAX_CLIENT_ATTRIB_STACK_DEPTH

\ gets
0BB0 CONSTANT GL_ATTRIB_STACK_DEPTH			 
0BB1 CONSTANT GL_CLIENT_ATTRIB_STACK_DEPTH	 
0C22 CONSTANT GL_COLOR_CLEAR_VALUE			 
0C23 CONSTANT GL_COLOR_WRITEMASK			     
0B01 CONSTANT GL_CURRENT_INDEX			     
0B00 CONSTANT GL_CURRENT_COLOR			     
0B02 CONSTANT GL_CURRENT_NORMAL			     
0B04 CONSTANT GL_CURRENT_RASTER_COLOR			 
0B09 CONSTANT GL_CURRENT_RASTER_DISTANCE		 
0B05 CONSTANT GL_CURRENT_RASTER_INDEX			 
0B07 CONSTANT GL_CURRENT_RASTER_POSITION		 
0B06 CONSTANT GL_CURRENT_RASTER_TEXTURE_COORDS 
0B08 CONSTANT GL_CURRENT_RASTER_POSITION_VALID 
0B03 CONSTANT GL_CURRENT_TEXTURE_COORDS		 
0C20 CONSTANT GL_INDEX_CLEAR_VALUE			 
0C30 CONSTANT GL_INDEX_MODE				     
0C21 CONSTANT GL_INDEX_WRITEMASK			     
0BA6 CONSTANT GL_MODELVIEW_MATRIX			     
0BA3 CONSTANT GL_MODELVIEW_STACK_DEPTH		 
0D70 CONSTANT GL_NAME_STACK_DEPTH			     
0BA7 CONSTANT GL_PROJECTION_MATRIX			 
0BA4 CONSTANT GL_PROJECTION_STACK_DEPTH		 
0C40 CONSTANT GL_RENDER_MODE				     
0C31 CONSTANT GL_RGBA_MODE				     
0BA8 CONSTANT GL_TEXTURE_MATRIX			     
0BA5 CONSTANT GL_TEXTURE_STACK_DEPTH			 
0BA2 CONSTANT GL_VIEWPORT

\hints
0C50 CONSTANT GL_PERSPECTIVE_CORRECTION_HINT
0C51 CONSTANT GL_POINT_SMOOTH_HINT
0C52 CONSTANT GL_LINE_SMOOTH_HINT	
0C53 CONSTANT GL_POLYGON_SMOOTH_HINT
0C54 CONSTANT GL_FOG_HINT			
1100 CONSTANT GL_DONT_CARE		
1101 CONSTANT GL_FASTEST			
1102 CONSTANT GL_NICEST			

\ scissor box
0C10 CONSTANT GL_SCISSOR_BOX
0C11 CONSTANT GL_SCISSOR_TEST

\ pixel mode / transfer
0D10 CONSTANT GL_MAP_COLOR				
0D11 CONSTANT GL_MAP_STENCIL				
0D12 CONSTANT GL_INDEX_SHIFT				
0D13 CONSTANT GL_INDEX_OFFSET				
0D14 CONSTANT GL_RED_SCALE				
0D15 CONSTANT GL_RED_BIAS				    
0D18 CONSTANT GL_GREEN_SCALE				
0D19 CONSTANT GL_GREEN_BIAS				
0D1A CONSTANT GL_BLUE_SCALE				
0D1B CONSTANT GL_BLUE_BIAS				
0D1C CONSTANT GL_ALPHA_SCALE				
0D1D CONSTANT GL_ALPHA_BIAS				
0D1E CONSTANT GL_DEPTH_SCALE				
0D1F CONSTANT GL_DEPTH_BIAS				
0CB1 CONSTANT GL_PIXEL_MAP_S_TO_S_SIZE	
0CB0 CONSTANT GL_PIXEL_MAP_I_TO_I_SIZE	
0CB2 CONSTANT GL_PIXEL_MAP_I_TO_R_SIZE	
0CB3 CONSTANT GL_PIXEL_MAP_I_TO_G_SIZE	
0CB4 CONSTANT GL_PIXEL_MAP_I_TO_B_SIZE	
0CB5 CONSTANT GL_PIXEL_MAP_I_TO_A_SIZE	
0CB6 CONSTANT GL_PIXEL_MAP_R_TO_R_SIZE	
0CB7 CONSTANT GL_PIXEL_MAP_G_TO_G_SIZE	
0CB8 CONSTANT GL_PIXEL_MAP_B_TO_B_SIZE	
0CB9 CONSTANT GL_PIXEL_MAP_A_TO_A_SIZE	
0C71 CONSTANT GL_PIXEL_MAP_S_TO_S			
0C70 CONSTANT GL_PIXEL_MAP_I_TO_I			
0C72 CONSTANT GL_PIXEL_MAP_I_TO_R			
0C73 CONSTANT GL_PIXEL_MAP_I_TO_G			
0C74 CONSTANT GL_PIXEL_MAP_I_TO_B			
0C75 CONSTANT GL_PIXEL_MAP_I_TO_A			
0C76 CONSTANT GL_PIXEL_MAP_R_TO_R			
0C77 CONSTANT GL_PIXEL_MAP_G_TO_G			
0C78 CONSTANT GL_PIXEL_MAP_B_TO_B			
0C79 CONSTANT GL_PIXEL_MAP_A_TO_A			
0D05 CONSTANT GL_PACK_ALIGNMENT			
0D01 CONSTANT GL_PACK_LSB_FIRST			
0D02 CONSTANT GL_PACK_ROW_LENGTH			
0D04 CONSTANT GL_PACK_SKIP_PIXELS			
0D03 CONSTANT GL_PACK_SKIP_ROWS			
0D00 CONSTANT GL_PACK_SWAP_BYTES			
0CF5 CONSTANT GL_UNPACK_ALIGNMENT			
0CF1 CONSTANT GL_UNPACK_LSB_FIRST			
0CF2 CONSTANT GL_UNPACK_ROW_LENGTH		
0CF4 CONSTANT GL_UNPACK_SKIP_PIXELS		
0CF3 CONSTANT GL_UNPACK_SKIP_ROWS			
0CF0 CONSTANT GL_UNPACK_SWAP_BYTES		
0D16 CONSTANT GL_ZOOM_X				    
0D17 CONSTANT GL_ZOOM_Y				    

2300 CONSTANT GL_TEXTURE_ENV			
2200 CONSTANT GL_TEXTURE_ENV_MODE		
0DE0 CONSTANT GL_TEXTURE_1D			
0DE1 CONSTANT GL_TEXTURE_2D			
2802 CONSTANT GL_TEXTURE_WRAP_S		
2803 CONSTANT GL_TEXTURE_WRAP_T		
2800 CONSTANT GL_TEXTURE_MAG_FILTER	
2801 CONSTANT GL_TEXTURE_MIN_FILTER	
2201 CONSTANT GL_TEXTURE_ENV_COLOR	
0C60 CONSTANT GL_TEXTURE_GEN_S		
0C61 CONSTANT GL_TEXTURE_GEN_T		
0C62 CONSTANT GL_TEXTURE_GEN_R		
0C63 CONSTANT GL_TEXTURE_GEN_Q		
2500 CONSTANT GL_TEXTURE_GEN_MODE		
1004 CONSTANT GL_TEXTURE_BORDER_COLOR	
1000 CONSTANT GL_TEXTURE_WIDTH		
1001 CONSTANT GL_TEXTURE_HEIGHT		
1005 CONSTANT GL_TEXTURE_BORDER		
1003 CONSTANT GL_TEXTURE_COMPONENTS	
805C CONSTANT GL_TEXTURE_RED_SIZE		
805D CONSTANT GL_TEXTURE_GREEN_SIZE	
805E CONSTANT GL_TEXTURE_BLUE_SIZE	
805F CONSTANT GL_TEXTURE_ALPHA_SIZE	
8060 CONSTANT GL_TEXTURE_LUMINANCE_SIZE
8061 CONSTANT GL_TEXTURE_INTENSITY_SIZE
2700 CONSTANT GL_NEAREST_MIPMAP_NEAREST
2702 CONSTANT GL_NEAREST_MIPMAP_LINEAR
2701 CONSTANT GL_LINEAR_MIPMAP_NEAREST
2703 CONSTANT GL_LINEAR_MIPMAP_LINEAR	
2401 CONSTANT GL_OBJECT_LINEAR		
2501 CONSTANT GL_OBJECT_PLANE			
2400 CONSTANT GL_EYE_LINEAR			
2502 CONSTANT GL_EYE_PLANE			
2402 CONSTANT GL_SPHERE_MAP			
2101 CONSTANT GL_DECAL				   
2100 CONSTANT GL_MODULATE				   
2600 CONSTANT GL_NEAREST				   
2901 CONSTANT GL_REPEAT				   
2900 CONSTANT GL_CLAMP				   
2000 CONSTANT GL_S					   
2001 CONSTANT GL_T					   
2002 CONSTANT GL_R					   
2003 CONSTANT GL_Q 

\
\   Utility
\
1F00 CONSTANT GL_VENDOR				
1F01 CONSTANT GL_RENDERER				
1F02 CONSTANT GL_VERSION				
1F03 CONSTANT GL_EXTENSIONS		    

\ 
\   Errors
\
0000 CONSTANT GL_NO_ERROR 		
0500 CONSTANT GL_INVALID_ENUM		
0501 CONSTANT GL_INVALID_VALUE	
0502 CONSTANT GL_INVALID_OPERATION 
0503 CONSTANT GL_STACK_OVERFLOW	
0504 CONSTANT GL_STACK_UNDERFLOW	
0505 CONSTANT GL_OUT_OF_MEMORY	

\
\   glPush/PopAttrib bits
\

00000001 CONSTANT GL_CURRENT_BIT				
00000002 CONSTANT GL_POINT_BIT				
00000004 CONSTANT GL_LINE_BIT				    
00000008 CONSTANT GL_POLYGON_BIT				
00000010 CONSTANT GL_POLYGON_STIPPLE_BIT		
00000020 CONSTANT GL_PIXEL_MODE_BIT			
00000040 CONSTANT GL_LIGHTING_BIT				
00000080 CONSTANT GL_FOG_BIT				    
00000100 CONSTANT GL_DEPTH_BUFFER_BIT			
00000200 CONSTANT GL_ACCUM_BUFFER_BIT			
00000400 CONSTANT GL_STENCIL_BUFFER_BIT		
00000800 CONSTANT GL_VIEWPORT_BIT				
00001000 CONSTANT GL_TRANSFORM_BIT			
00002000 CONSTANT GL_ENABLE_BIT				
00004000 CONSTANT GL_COLOR_BUFFER_BIT			
00008000 CONSTANT GL_HINT_BIT				    
00010000 CONSTANT GL_EVAL_BIT				    
00020000 CONSTANT GL_LIST_BIT				    
00040000 CONSTANT GL_TEXTURE_BIT				
00080000 CONSTANT GL_SCISSOR_BIT				
FFFFFFFF CONSTANT GL_ALL_ATTRIB_BITS

\ 
\   OpenGL 1.1
\

8063 CONSTANT GL_PROXY_TEXTURE_1D			
8064 CONSTANT GL_PROXY_TEXTURE_2D			
8066 CONSTANT GL_TEXTURE_PRIORITY			
8067 CONSTANT GL_TEXTURE_RESIDENT			
8068 CONSTANT GL_TEXTURE_BINDING_1D		
8069 CONSTANT GL_TEXTURE_BINDING_2D		
1003 CONSTANT GL_TEXTURE_INTERNAL_FORMAT	
803B CONSTANT GL_ALPHA4				    
803C CONSTANT GL_ALPHA8				    
803D CONSTANT GL_ALPHA12				    
803E CONSTANT GL_ALPHA16				    
803F CONSTANT GL_LUMINANCE4				
8040 CONSTANT GL_LUMINANCE8				
8041 CONSTANT GL_LUMINANCE12				
8042 CONSTANT GL_LUMINANCE16				
8043 CONSTANT GL_LUMINANCE4_ALPHA4		
8044 CONSTANT GL_LUMINANCE6_ALPHA2		
8045 CONSTANT GL_LUMINANCE8_ALPHA8		
8046 CONSTANT GL_LUMINANCE12_ALPHA4		
8047 CONSTANT GL_LUMINANCE12_ALPHA12		
8048 CONSTANT GL_LUMINANCE16_ALPHA16		
8049 CONSTANT GL_INTENSITY				
804A CONSTANT GL_INTENSITY4				
804B CONSTANT GL_INTENSITY8				
804C CONSTANT GL_INTENSITY12				
804D CONSTANT GL_INTENSITY16				
2A10 CONSTANT GL_R3_G3_B2				    
804F CONSTANT GL_RGB4					    
8050 CONSTANT GL_RGB5					    
8051 CONSTANT GL_RGB8					    
8052 CONSTANT GL_RGB10				    
8053 CONSTANT GL_RGB12				    
8054 CONSTANT GL_RGB16				    
8055 CONSTANT GL_RGBA2				    
8056 CONSTANT GL_RGBA4				    
8057 CONSTANT GL_RGB5_A1				    
8058 CONSTANT GL_RGBA8				    
8059 CONSTANT GL_RGB10_A2				    
805A CONSTANT GL_RGBA12				    
805B CONSTANT GL_RGBA16

00000001 CONSTANT GL_CLIENT_PIXEL_STORE_BIT
00000002 CONSTANT GL_CLIENT_VERTEX_ARRAY_BIT
FFFFFFFF CONSTANT GL_ALL_CLIENT_ATTRIB_BITS 
FFFFFFFF CONSTANT GL_CLIENT_ALL_ATTRIB_BITS

DECIMAL

\ 
\   Miscellaneous 
\

C-FUNCTION glClear              glClear              n       -- void

( red green blue alpha -- )
C-FUNCTION glClearAccum         glClearAccum         r r r r -- void

( red green blue alpha -- )
C-FUNCTION glClearColor         glClearColor         r r r r -- void

( GLuint mask );
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


\ 
\   Depth Buffer 
\

\ void glClearDepth( GLclampd depth );
C-FUNCTION glClearDepth         glClearDepth        r         -- void

\ void glDepthFunc( GLenum func );
C-FUNCTION glDepthFunc          glDepthFunc         n         -- void

\ void glDepthMask( GLboolean flag );
C-FUNCTION glDepthMask          glDepthMask         n         -- void

\ void glDepthRange( GLclampd near_val, GLclampd far_val );
C-FUNCTION glDepthRange         glDepthRange        r r       -- void

\ 
\   Accumulation Buffer 
\

\ void glClearAccum( GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha );
C-FUNCTION glClearAccum         glClearAccum        r r r r   -- void

\ void glAccum( GLenum op, GLfloat value );
C-FUNCTION glAccum              glAccum             n r       -- void

\
\   Transformation
\

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

\ void glLoadMatrixf( const GLfloat *m );
C-FUNCTION glLoadMatrixf       glLoadMatrix       a           -- void

\ void glMultMatrixf( const GLfloat *m );
C-FUNCTION glMultMatrixf       glMultMatrix       a           -- void

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

\
\   Display Lists
\

( list -- )
C-FUNCTION glIsList            glIsLIst           n           -- n

( list range -- )
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

( base )
C-FUNCTION glListBase          glListBase         n           -- void

\
\   Drawing Functions
\

( mode )
C-FUNCTION glBegin             glBegin           n            -- void
C-FUNCTION glEnd               glEnd                          -- void

\ 
\   glVertex
\

( x y )
C-FUNCTION glVertex2f          glVertex2f        r r          -- void
C-FUNCTION glVertex2i          glVertex2i        n n          -- void

( x y z )
C-FUNCTION glVertex3f          glVertex3f        r r r        -- void
C-FUNCTION glVertex3i          glVertex3i        n n n        -- void

( x y z w )
C-FUNCTION glVertex4f          glVertex4f        r r r r      -- void
C-FUNCTION glVertex4i          glVertex4i        n n n n      -- void

( v )
C-FUNCTION glVertex2fv          glVertex2fv      a            -- void
C-FUNCTION glVertex2iv          glVertex2iv      a            -- void    
C-FUNCTION glVertex3fv          glVertex3fv      a            -- void         
C-FUNCTION glVertex3iv          glVertex3iv      a            -- void
C-FUNCTION glVertex4fv          glVertex4dv      a            -- void
C-FUNCTION glVertex4iv          glVertex4dv      a            -- void

\ 
\   glNormal 
\

( nx ny nz )
C-FUNCTION glNormal3b           glNormal3b       n n n        -- void
C-FUNCTION glNormal3f           glNormal3f       r r r        -- void
C-FUNCTION glNormal3i           glNormal3i       n n n        -- void


( v )
C-FUNCTION glNormal3bv          glNormal3bv      a            -- void
C-FUNCTION glNormal3fv          glNormal3fv      a            -- void
C-FUNCTION glNormal3iv          glNormal3iv      a            -- void


( c )
C-FUNCTION glIndexf             glIndexf         r            -- void
C-FUNCTION glIndexi             glIndexi         n            -- void
C-FUNCTION glIndexub            glIndexub        n            -- void
C-FUNCTION glIndexbv            glIndexubv       a            -- void
C-FUNCTION glIndexfv            glIndexufv       a            -- void
C-FUNCTION glIndexiv            glIndexuiv       a            -- void

\ 
\   glColor 
\

\ void glColor3b( GLbyte red, GLbyte green, GLbyte blue );
C-FUNCTION glColor3b            glColor3         n n n        -- void
C-FUNCTION glColor3ub           glColor3u        n n n        -- void

C-FUNCTION glColor4b            glColor4         n n n n      -- void
C-FUNCTION glColo4ub            glColor4u        n n n n      -- void
C-FUNCTION glColor3bv           glColor3v       a            -- void

\ void glColor3ubv( const GLubyte *v );
C-FUNCTION glColor3ubv          glColor3uv       a            -- void

\ void glColor4bv( const GLbyte *v );
C-FUNCTION glColor4bv           glColor4v        a            -- void

\ void glColor4ubv( const GLubyte *v );
C-FUNCTION glColor4ubv          glColor4uv       a            -- void

\ 
\   glTexCoord 
\

( s )
C_FUCTION  glTexCoord1f         glTexCoord1f     r            -- void
C-FUNCTION glTexCoodr1i         glTexCoord1i     n            -- void

( s t )
C-FUNCTION glTexCoord2f         glTexCoord2f     r r          -- void
C-FUNCTION glTexCoord2i         glTexCoord2i     n n          -- void

( s t r );
C-FUNCTION glTexCoord3f         glTexCoord3f     r r r        -- void 
C-FUNCTION glTexCoord3i         glTexCoord3i     n n n        -- void 

( s t r q )
C-FUNCTION glTexCoord4f         glTexCoord4f     r r r r      -- void
C-FUNCTION glTexCoord4i         glTexCoord4i     n n n n      -- void 

( v )
C-FUNCTION glTexCoord1fv        glTexCoord1fv    a            -- void
C-FUNCTION glTexCoord1iv        glTexCoord1iv    a            -- void
C-FUNCTION glTexCoord2fv        glTexCoord2fv    a            -- void
C-FUNCTION glTexCoordiv         glTexCoord2iv    a            -- void
C-FUNCTION glTexCoord3fv        glTexCoord3fv    a            -- void
C-FUNCTION glTexCoord3iv        glTexCoord3iv    a            -- void
C-FUNCTION glTexCoord4fv        glTexCoord4fv    a            -- void
C-FUNCTION glTexCoord4iv        glTexCoord4iv    a            -- void


\ 
\   glRaster 
\

( x y )
C-FUNCTION glRasterPos2i        glRasterPos2i    n n          -- void
C-FUNCTION glRasterPos2f        glRasterPos2f    r r          -- voi

( x y z )
C-FUNCTION glRasterPos3f        glRasterPos3f    r r r        -- void
C-FUNCTION glRasterPos3i        glRasterPos3i    n n n        -- void

( x y z w )
C-FUNCTION glRasterPos4f        glRasterPos4f    r r r r      -- void     
C-FUNCTION glRasterPos4i        glRasterPos3i    n n n n      -- void

( v )
C-FUNCTION glRasterPos2fv       glRasterPos2fv   a            -- void 
C-FUNCTION glRasterPos2iv       glRasterPos2iv   a            -- void
C-FUNCTION glRasterPos3fv       glRasterPos3fv   a            -- void
C-FUNCTION glRasterPos3iv       glRasterPos3iv   a            -- void
C-FUNCTION glRasterPos4fv       glRasterPos4fv   a            -- void 
C-FUNCTION glRasterPos4iv       glRasterPos4fv   a            -- void

\ 
\   glRect 
\

( x1 y1 x2 y2 )
C-FUNCTION glRectf              glRectf          r r r r      -- void
C-FUNCTION glRecti              glRecti          n n n n      -- void

( v1 v2 )
C-FUNCTION glRectfv             glRectfv         a a          -- void
C-FUNCTION glRectiv             glRectiv         a a          -- void

\
\   Vertex Arrays (1.1) 
\

( size type stride ptr )
C-FUNCTION glVertexPointer      glVertexPointer   n n n a      -- void
C-FUNCTION glColorPointer       glColorPointer    n n n a      -- void 
C-FUNCTION glCoordPointer       glCoordPointer    n n n a      -- void

( type stride ptr )
C-FUNCTION glNormalPointer      glNormalPointer   n n a        -- void
C-FUNCTION glIndexPointer       glIndexPointer    n n a        -- void

( stride ptr )
C-FUNCTION glEdgeFlagPointer    glEdgeFlagPointer n a          -- void

( pname, params )
C-FUNCTION glGetPointerv        glGetPointerv     n a          -- void 

( i )
C-FUNCTION glArrayElement       glArrayElement    n            -- void

( mode first count )
C-FUNCTION glDrawArrays         glDrawArrays      n n n        -- void

( mode count type indices )
C-FUNCTION glDrawElements       glDrawElements    n n n a      -- void

( format stride pointer )
C-FUNCTION glInterleavedArrays  glInterleavedArrays n n a      -- void

\
\   Lighting
\
 
( mode )
C-FUNCTION glShadeModel         glShadeModel       n           -- void

\ 
\   glLight 
\

( light pname param )
C-FUNCTION glLightf             glLightf           n n r       -- void
C-FUNCTION glLighti             glLighti           n n n       -- void

( light pname params )
C-FUNCTION glLightfv            glLightfv          n n a       -- void 
C-FUNCTION glLightiv            glLightiv          n n a       -- void
C-FUNCTION glGetLightfv         glGetLightfv       n n a       -- void
C-FUNCTION glGetLightiv         glGetLightiv       n n a       -- void 

( pname param )
C-FUNCTION glLightModelf        glLightModelf      n n r       -- void
C-FUNCTION glLightModeli        glLightModeli      n n n       -- void

( pname params )
C-FUNCTION glLightModelfv       glLightModelfv     n a         -- void
C-FUNCTION glLightModeliv       glLightModeliv     n a         -- void

\ 
\   glMateral 
\

( face pname param )
C-FUNCTION glMaterialf          glMaterialf        n n r       -- void
C-FUNCTION glMateriali          glMateriali        n n n       -- void       

( face pname params )
C-FUNCTION glMaterialfv         glMaterialfv       n n a       -- void
C-FUNCTION glMaterialiv         glMaterialiv       n n a       -- void
C-FUNCTION glGetMaterialfv      glGetMaterialfv    n n a       -- void
C-FUNCTION glGETMaterialiv      glGetMaterialiv    n n a       -- void
 
\
\   glRaster Functions
\
 
( xfactor yfactor )
C-FUNCTION glPixelZoom      glPixelZoom      r r             -- void

( pname param )
C-FUNCTION glPixelStoref    glPixelStoref    n r             -- void 
C-FUNCTION glPixelStorei    glPixelStorei    n n             -- void
C-FUNCTION glPixelTransferf glPixelTransferf n r             -- void
C-FUNCTION glPixelTransferi glPixelTransferi n n             -- void

( map mapsize values )
C-FUNCTION glPixelMapfv     glPixelMapfv     n n a           -- void
C-FUNCTION glPixelMapiv     glPixelMapiv     n n a           -- void

( map values )
C-FUNCTION glGetPixelMapfv  glGetPixelMapfv  n a             -- void
C-FUNCTION glGetPixelMapiv  glGetPixelMapiv  n a             -- void

( width height xorig yorig xmove ymove bitmap )
C-FUNCTION glBitmap         glBitmap         n n r r r r n a -- void

( x y width height format type pixels )
C-FUNCTION glReadPixels     glReadPixels     n n n n n n a   -- void

\ void glDrawPixels( GLsizei width, GLsizei height, GLenum format, GLenum type,const GLvoid *pixels );
C-FUNCTION glDrawPixels     glDrawPixels     n n n n a       -- void

\ void glCopyPixels( GLint x, GLint y, GLsizei width, GLsizei height, GLenum type );
C-FUNCTION glCopyPixels     glCopyPixels     n n n n n       -- void

\
\   Stenciling
\

C-FUNCTION glStencilFunc  ( func ref mask )     glStencilFunc  n n n -- void
C-FUNCTION glStencilMask  ( mask )              glStencilMask  n     -- void
C-FUNCTION glStencilOp    ( fail zfail zpass )  glStencilOp    n n n -- void
C-FUNCTION glClearStencil ( s )                 glClearStencil n     -- void
 
\
\   Texture mapping
\
 
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


( target level pname params )
C-FUNCTION glGetTexLevelParameterfv   glGetTexLevelParameterfv

( target level pname params )
C-FUNCTION glGetTexLevelParameteriv   glGetTexLevelParameteriv n n n a           -- void

( target level internalFormat width border format type pixels )
C-FUNCTION glTexImage1D               glTexImage1D             n n n n n n n a   -- void

( target level internalFormat width height border format type pixels )
C-FUNCTION glTexImage2D               glTexImage2D             n n n n n n n n a -- void

( target level format type pixels )
C-FUNCTION glGetTexImage              glGetTexImage            n n n n a         -- void

\ 
\   1.1 Functions
\

( n textures )
C-FUNCTION glGenTexturesbv            glGenTextures        n a           -- void
C-FUNCTION glBindTextures             glIndexubv           n n           -- void

( n textures priorities ) 
C-FUNCTION glPrioritizeTextures       glPrioritizeTextures n a a         -- void

( n textures residences -- GLboolean );
C-FUNCTION glAreTexturesResident      glAreTexturesResident n a a         -- n

( texture -- GLboolean )
C-FUNCTION glIsTexture                glIsTexture           n             -- n

( target level xoffset width format type pixels ) 
C-FUNCTION glTexSubImage1D     glTexSubImage1D     n n n n n n a     -- void

( target level xoffset yoffset width height format type pixels -- )
C-FUNCTION glTexSubImage2D     glTexSubImage2D     n n n n n n n n a -- void

( target level internalformat x y width border -- )
 C-FUNCTION glCopyTexImage1D   glCopyTexImage1D    n n n n n n n    -- void
 
( target level internalformat x y width height border -- )
C-FUNCTION glCopyTexImage2D    glCopyTexImage2D    n n n n n n n n  -- void

( target level xoffset x y width -- )
C-FUNCTION glCopyTexSubImage1D glCopyTexSubImage1D n n n n n n      -- void

( target level xoffset yoffset x y width height -- )
C-FUNCTION glCopyTexSubImage2D glCopyTexSubImage2d n n n n n n n n  -- void

\
\   glEvaluators
\

( target u1 u2 stride order points -- )
C-FUNCTION glMap1f             glMap1f          n r r n n a         -- void

( target u1 u2 ustride uorder v1 v2 vstride vorder points -- )
C-FUNCTION glMap2f             glMap2f          n r r n n r r n n a -- void

( target query v -- )
C-FUNCTION glGetMapfv          glGetMapfv        n n a              -- void
C-FUNCTION glGetMapiv          glGetMapiv        n n a              -- void
    
( u -- )       
C-FUNCTION glEvalCoord1f       glEvalCoord1f     r                  -- void
    
( u -- )       
C-FUNCTION glEvalCoord1fv      glEvalCoord1fv    a                  -- void
    
( u v -- )       
C-FUNCTION glEvalCoord2f       glEvalCoord2f     r r                -- void
    
( u -- )       
C-FUNCTION glEvalCoord2fv      glEvalCoord2fv    a                  -- void
    
( un u1 u2 -- )       
C-FUNCTION glMapGrid1f         glMapGrid1f       n r r              -- void 
    
( un u1 u2 vn v1 v2 -- )       
 C-FUNCTION glMapGrid2f        glMapGrid2f       n r r n r r        -- void
    
( i -- )       
C-FUNCTION glEvalPoint1        glEvalPoint1      n                  -- void
    
( i j -- );       
C-FUNCTION glEvalPoint2        glEvalPoint2      n n       
    
( mode i1 i2 -- )       
C-FUNCTION glEvalMesh1         glEvalMesh1       n n n              -- void
    
( mode i1 i2 j1 j2 -- )       
C-FUNCTION glEvalMesh2         glEvalMesh2       n n n n n          -- void
    
\       
\   glFog       
\       
    
( pname param -- )       
C-FUNCTION glFogf               glFogf           n r                -- void
C-FUNCTION glFogi               glFogi           n n                -- void
    
( pname params -- )       
C-FUNCTION glFogfv              glFogfv          n a                -- void
C-FUNCTION glFogiv              glFogiv          n a                -- void


\
\   Selection and Feedback
\

( size type buffer -- )
C-FUNCTION glFeedbackBuffer     glFeedbackBuffer n n a              -- void
      
( token -- )      
C-FUNCTION glPassThrough        glPassThrough    r                  -- void
      
( size buffer -- )      
C-FUNCTION glSelectBuffer       glSelectBuffer   n a                -- void
      
C-FUNCTION glInitNames          glInitNames                         -- void
C-FUNCTION glPopName            glPopName                           -- void
      
( name -- )      
C-FUNCTION glLoadName           glLoadName       n                  -- void
C-FUNCTION glPushName           glPushName       n                  -- void

\
\   OpenGL (1.2)
\

HEX

803A CONSTANT GL_RESCALE_NORMAL			       
812F CONSTANT GL_CLAMP_TO_EDGE			       
80E8 CONSTANT GL_MAX_ELEMENTS_VERTICES		   
80E9 CONSTANT GL_MAX_ELEMENTS_INDICES			   
80E0 CONSTANT GL_BGR					           
80E1 CONSTANT GL_BGRA					           
8032 CONSTANT GL_UNSIGNED_BYTE_3_3_2			   
8362 CONSTANT GL_UNSIGNED_BYTE_2_3_3_REV		   
8363 CONSTANT GL_UNSIGNED_SHORT_5_6_5			   
8364 CONSTANT GL_UNSIGNED_SHORT_5_6_5_REV		   
8033 CONSTANT GL_UNSIGNED_SHORT_4_4_4_4		   
8365 CONSTANT GL_UNSIGNED_SHORT_4_4_4_4_REV	   
8034 CONSTANT GL_UNSIGNED_SHORT_5_5_5_1		   
8366 CONSTANT GL_UNSIGNED_SHORT_1_5_5_5_REV	   
8035 CONSTANT GL_UNSIGNED_INT_8_8_8_8			   
8367 CONSTANT GL_UNSIGNED_INT_8_8_8_8_REV		   
8036 CONSTANT GL_UNSIGNED_INT_10_10_10_2		   
8368 CONSTANT GL_UNSIGNED_INT_2_10_10_10_REV	   
81F8 CONSTANT GL_LIGHT_MODEL_COLOR_CONTROL	   
81F9 CONSTANT GL_SINGLE_COLOR				       
81FA CONSTANT GL_SEPARATE_SPECULAR_COLOR		   
813A CONSTANT GL_TEXTURE_MIN_LOD			       
813B CONSTANT GL_TEXTURE_MAX_LOD			       
813C CONSTANT GL_TEXTURE_BASE_LEVEL		       
813D CONSTANT GL_TEXTURE_MAX_LEVEL			   
0B12 CONSTANT GL_SMOOTH_POINT_SIZE_RANGE		   
0B13 CONSTANT GL_SMOOTH_POINT_SIZE_GRANULARITY   
0B22 CONSTANT GL_SMOOTH_LINE_WIDTH_RANGE		   
0B23 CONSTANT GL_SMOOTH_LINE_WIDTH_GRANULARITY   
846D CONSTANT GL_ALIASED_POINT_SIZE_RANGE		   
846E CONSTANT GL_ALIASED_LINE_WIDTH_RANGE		   
806B CONSTANT GL_PACK_SKIP_IMAGES			       
806C CONSTANT GL_PACK_IMAGE_HEIGHT			   
806D CONSTANT GL_UNPACK_SKIP_IMAGES			   
806E CONSTANT GL_UNPACK_IMAGE_HEIGHT			   
806F CONSTANT GL_TEXTURE_3D				       
8070 CONSTANT GL_PROXY_TEXTURE_3D			       
8071 CONSTANT GL_TEXTURE_DEPTH			       
8072 CONSTANT GL_TEXTURE_WRAP_R			       
8073 CONSTANT GL_MAX_3D_TEXTURE_SIZE			   
806A CONSTANT GL_TEXTURE_BINDING_3D	

DECIMAL

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
\ 
\ GL_ARB_imaging
\ 

8001 CONSTANT GL_CONSTANT_COLOR			           
8002 CONSTANT GL_ONE_MINUS_CONSTANT_COLOR	           
8003 CONSTANT GL_CONSTANT_ALPHA			           
8004 CONSTANT GL_ONE_MINUS_CONSTANT_ALPHA	           
80D0 CONSTANT GL_COLOR_TABLE				           
80D1 CONSTANT GL_POST_CONVOLUTION_COLOR_TABLE		   
80D2 CONSTANT GL_POST_COLOR_MATRIX_COLOR_TABLE	   
80D3 CONSTANT GL_PROXY_COLOR_TABLE			       
80D4 CONSTANT GL_PROXY_POST_CONVOLUTION_COLOR_TABLE
80D5 CONSTANT GL_PROXY_POST_COLOR_MATRIX_COLOR_TABLE
80D6 CONSTANT GL_COLOR_TABLE_SCALE		           
80D7 CONSTANT GL_COLOR_TABLE_BIAS			           
80D8 CONSTANT GL_COLOR_TABLE_FORMAT		           
80D9 CONSTANT GL_COLOR_TABLE_WIDTH		           
80DA CONSTANT GL_COLOR_TABLE_RED_SIZE		           
80DB CONSTANT GL_COLOR_TABLE_GREEN_SIZE	           
80DC CONSTANT GL_COLOR_TABLE_BLUE_SIZE	           
80DD CONSTANT GL_COLOR_TABLE_ALPHA_SIZE	           
80DE CONSTANT GL_COLOR_TABLE_LUMINANCE_SIZE	       
80DF CONSTANT GL_COLOR_TABLE_INTENSITY_SIZE	       
8010 CONSTANT GL_CONVOLUTION_1D			           
8011 CONSTANT GL_CONVOLUTION_2D			           
8012 CONSTANT GL_SEPARABLE_2D				           
8013 CONSTANT GL_CONVOLUTION_BORDER_MODE		       
8014 CONSTANT GL_CONVOLUTION_FILTER_SCALE		       
8015 CONSTANT GL_CONVOLUTION_FILTER_BIAS		       
8016 CONSTANT GL_REDUCE				                          
8017 CONSTANT GL_CONVOLUTION_FORMAT			       
8018 CONSTANT GL_CONVOLUTION_WIDTH			       
8019 CONSTANT GL_CONVOLUTION_HEIGHT			       
801A CONSTANT GL_MAX_CONVOLUTION_WIDTH		       
801B CONSTANT GL_MAX_CONVOLUTION_HEIGHT		       
801C CONSTANT GL_POST_CONVOLUTION_RED_SCALE	       
801D CONSTANT GL_POST_CONVOLUTION_GREEN_SCALE	       
801E CONSTANT GL_POST_CONVOLUTION_BLUE_SCALE	       
801F CONSTANT GL_POST_CONVOLUTION_ALPHA_SCALE	       
8020 CONSTANT GL_POST_CONVOLUTION_RED_BIAS	       
8021 CONSTANT GL_POST_CONVOLUTION_GREEN_BIAS	       
8022 CONSTANT GL_POST_CONVOLUTION_BLUE_BIAS	       
8023 CONSTANT GL_POST_CONVOLUTION_ALPHA_BIAS	       
8151 CONSTANT GL_CONSTANT_BORDER			           
8153 CONSTANT GL_REPLICATE_BORDER			           
8154 CONSTANT GL_CONVOLUTION_BORDER_COLOR	           
80B1 CONSTANT GL_COLOR_MATRIX				           
80B2 CONSTANT GL_COLOR_MATRIX_STACK_DEPTH		       
80B3 CONSTANT GL_MAX_COLOR_MATRIX_STACK_DEPTH		   
80B4 CONSTANT GL_POST_COLOR_MATRIX_RED_SCALE		   
80B5 CONSTANT GL_POST_COLOR_MATRIX_GREEN_SCALE	   
80B6 CONSTANT GL_POST_COLOR_MATRIX_BLUE_SCALE		   
80B7 CONSTANT GL_POST_COLOR_MATRIX_ALPHA_SCALE	   
80B8 CONSTANT GL_POST_COLOR_MATRIX_RED_BIAS		   
80B9 CONSTANT GL_POST_COLOR_MATRIX_GREEN_BIAS		   
80BA CONSTANT GL_POST_COLOR_MATRIX_BLUE_BIAS		   
80BB CONSTANT GL_POST_COLOR_MATRIX_ALPHA_BIAS		   
8024 CONSTANT GL_HISTOGRAM				           
8025 CONSTANT GL_PROXY_HISTOGRAM			           
8026 CONSTANT GL_HISTOGRAM_WIDTH			           
8027 CONSTANT GL_HISTOGRAM_FORMAT			           
8028 CONSTANT GL_HISTOGRAM_RED_SIZE		           
8029 CONSTANT GL_HISTOGRAM_GREEN_SIZE		           
802A CONSTANT GL_HISTOGRAM_BLUE_SIZE		           
802B CONSTANT GL_HISTOGRAM_ALPHA_SIZE		           
802C CONSTANT GL_HISTOGRAM_LUMINANCE_SIZE	           
802D CONSTANT GL_HISTOGRAM_SINK			           
802E CONSTANT GL_MINMAX				               
802F CONSTANT GL_MINMAX_FORMAT		               
8030 CONSTANT GL_MINMAX_SINK			               
8031 CONSTANT GL_TABLE_TOO_LARGE		               
8009 CONSTANT GL_BLEND_EQUATION		               
8007 CONSTANT GL_MIN					               
8008 CONSTANT GL_MAX					               
8006 CONSTANT GL_FUNC_ADD				               
800A CONSTANT GL_FUNC_SUBTRACT			           
800B CONSTANT GL_FUNC_REVERSE_SUBTRACT	           
8005 CONSTANT GL_BLEND_COLOR				           
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

HEX 
\ 
\ /* multitexture */
84C0 CONSTANT GL_TEXTURE0				
84C1 CONSTANT GL_TEXTURE1				
84C2 CONSTANT GL_TEXTURE2				
84C3 CONSTANT GL_TEXTURE3				
84C4 CONSTANT GL_TEXTURE4				
84C5 CONSTANT GL_TEXTURE5				
84C6 CONSTANT GL_TEXTURE6				
84C7 CONSTANT GL_TEXTURE7				
84C8 CONSTANT GL_TEXTURE8				
84C9 CONSTANT GL_TEXTURE9				
84CA CONSTANT GL_TEXTURE10				
84CB CONSTANT GL_TEXTURE11				
84CC CONSTANT GL_TEXTURE12				
84CD CONSTANT GL_TEXTURE13				
84CE CONSTANT GL_TEXTURE14				
84CF CONSTANT GL_TEXTURE15				
84D0 CONSTANT GL_TEXTURE16				
84D1 CONSTANT GL_TEXTURE17				
84D2 CONSTANT GL_TEXTURE18				
84D3 CONSTANT GL_TEXTURE19				
84D4 CONSTANT GL_TEXTURE20				
84D5 CONSTANT GL_TEXTURE21				
84D6 CONSTANT GL_TEXTURE22				
84D7 CONSTANT GL_TEXTURE23				
84D8 CONSTANT GL_TEXTURE24				
84D9 CONSTANT GL_TEXTURE25				
84DA CONSTANT GL_TEXTURE26				
84DB CONSTANT GL_TEXTURE27				
84DC CONSTANT GL_TEXTURE28				
84DD CONSTANT GL_TEXTURE29				
84DE CONSTANT GL_TEXTURE30				
84DF CONSTANT GL_TEXTURE31				
84E0 CONSTANT GL_ACTIVE_TEXTURE			
84E1 CONSTANT GL_CLIENT_ACTIVE_TEXTURE
84E2 CONSTANT GL_MAX_TEXTURE_UNITS
\ /* texture_cube_map */
8511 CONSTANT GL_NORMAL_MAP				      
8512 CONSTANT GL_REFLECTION_MAP			      
8513 CONSTANT GL_TEXTURE_CUBE_MAP			      
8514 CONSTANT GL_TEXTURE_BINDING_CUBE_MAP	   
8515 CONSTANT GL_TEXTURE_CUBE_MAP_POSITIVE_X
8516 CONSTANT GL_TEXTURE_CUBE_MAP_NEGATIVE_X
8517 CONSTANT GL_TEXTURE_CUBE_MAP_POSITIVE_Y
8518 CONSTANT GL_TEXTURE_CUBE_MAP_NEGATIVE_Y
8519 CONSTANT GL_TEXTURE_CUBE_MAP_POSITIVE_Z
851A CONSTANT GL_TEXTURE_CUBE_MAP_NEGATIVE_Z
851B CONSTANT GL_PROXY_TEXTURE_CUBE_MAP		  
851C CONSTANT GL_MAX_CUBE_MAP_TEXTURE_SIZE		  
\ /* texture_compression */
84E9 CONSTANT GL_COMPRESSED_ALPHA			    
84EA CONSTANT GL_COMPRESSED_LUMINANCE			
84EB CONSTANT GL_COMPRESSED_LUMINANCE_ALPHA		
84EC CONSTANT GL_COMPRESSED_INTENSITY			
84ED CONSTANT GL_COMPRESSED_RGB			        
84EE CONSTANT GL_COMPRESSED_RGBA			        
84EF CONSTANT GL_TEXTURE_COMPRESSION_HINT		
86A0 CONSTANT GL_TEXTURE_COMPRESSED_IMAGE_SIZE	
86A1 CONSTANT GL_TEXTURE_COMPRESSED			    
86A2 CONSTANT GL_NUM_COMPRESSED_TEXTURE_FORMATS	
86A3 CONSTANT GL_COMPRESSED_TEXTURE_FORMATS		
\ /* multisample */
809D CONST GL_MULTISAMPLE				
809E CONST GL_SAMPLE_ALPHA_TO_COVERAGE	
809F CONST GL_SAMPLE_ALPHA_TO_ONE		
80A0 CONST GL_SAMPLE_COVERAGE			
80A8 CONST GL_SAMPLE_BUFFERS			    
80A9 CONST GL_SAMPLES			    	
80AA CONST GL_SAMPLE_COVERAGE_VALUE		
80AB CONST GL_SAMPLE_COVERAGE_INVERT		
20000000 CONST GL_MULTISAMPLE_BIT			
\ /* transpose_matrix */
84E3 CONSTANT GL_TRANSPOSE_MODELVIEW_MATRIX
84E4 CONSTANT GL_TRANSPOSE_PROJECTION_MATRIX
84E5 CONSTANT GL_TRANSPOSE_TEXTURE_MATRIX
84E6 CONSTANT GL_TRANSPOSE_COLOR_MATRIX	  	  
\ /* texture_env_combine */
8570 CONSTANT  GL_COMBINE				  
8571 CONSTANT  GL_COMBINE_RGB		
8572 CONSTANT  GL_COMBINE_ALPHA	
8580 CONSTANT  GL_SOURCE0_RGB		
8581 CONSTANT  GL_SOURCE1_RGB		
8582 CONSTANT  GL_SOURCE2_RGB		
8588 CONSTANT  GL_SOURCE0_ALPHA	
8589 CONSTANT  GL_SOURCE1_ALPHA	
858A CONSTANT  GL_SOURCE2_ALPHA	
8590 CONSTANT  GL_OPERAND0_RGB	
8591 CONSTANT  GL_OPERAND1_RGB	
8592 CONSTANT  GL_OPERAND2_RGB	
8598 CONSTANT  GL_OPERAND0_ALPHA	
8599 CONSTANT  GL_OPERAND1_ALPHA	
859A CONSTANT  GL_OPERAND2_ALPHA	
8573 CONSTANT  GL_RGB_SCALE		
8574 CONSTANT  GL_ADD_SIGNED		
8575 CONSTANT  GL_INTERPOLATE		
84E7 CONSTANT  GL_SUBTRACT		
8576 CONSTANT  GL_CONSTANT		
8577 CONSTANT  GL_PRIMARY_COLOR	
8578 CONSTANT  GL_PREVIOUS
\ /* texture_env_dot3 */
863E CONSTANT GL_DOT3_RGB				
86AF CONSTANT GL_DOT3_RGBA				
\ /* texture_border_clamp */
812D CONSTANT GL_CLAMP_TO_BORDER

DECIMAL
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
 
\ void glMultiTexCoord1f( GLenum target, GLfloat s );
\ 
\ void glMultiTexCoord1fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord1i( GLenum target, GLint s );
\ 
\ void glMultiTexCoord1iv( GLenum target, const GLint *v );
\ 

\ void glMultiTexCoord2f( GLenum target, GLfloat s, GLfloat t );
\ 
\ void glMultiTexCoord2fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord2i( GLenum target, GLint s, GLint t );
\ 
\ void glMultiTexCoord2iv( GLenum target, const GLint *v );

\ void glMultiTexCoord3f( GLenum target, GLfloat s, GLfloat t, GLfloat r );
\ 
\ void glMultiTexCoord3fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord3i( GLenum target, GLint s, GLint t, GLint r );
\ 
\ void glMultiTexCoord3iv( GLenum target, const GLint *v );

\ void glMultiTexCoord4f( GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q );
\ 
\ void glMultiTexCoord4fv( GLenum target, const GLfloat *v );
\ 
\ void glMultiTexCoord4i( GLenum target, GLint s, GLint t, GLint r, GLint q );
\ 
\ void glMultiTexCoord4iv( GLenum target, const GLint *v );

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
\   GL_ARB_multitexture (ARB extension 1 and OpenGL 1.2.1)
\

HEX

84C0 CONSTANT GL_TEXTURE0_ARB			
84C1 CONSTANT GL_TEXTURE1_ARB			
84C2 CONSTANT GL_TEXTURE2_ARB			
84C3 CONSTANT GL_TEXTURE3_ARB			
84C4 CONSTANT GL_TEXTURE4_ARB			
84C5 CONSTANT GL_TEXTURE5_ARB			
84C6 CONSTANT GL_TEXTURE6_ARB			
84C7 CONSTANT GL_TEXTURE7_ARB			
84C8 CONSTANT GL_TEXTURE8_ARB			
84C9 CONSTANT GL_TEXTURE9_ARB			
84CA CONSTANT GL_TEXTURE10_ARB			   
84CB CONSTANT GL_TEXTURE11_ARB			   
84CC CONSTANT GL_TEXTURE12_ARB			   
84CD CONSTANT GL_TEXTURE13_ARB			   
84CE CONSTANT GL_TEXTURE14_ARB			   
84CF CONSTANT GL_TEXTURE15_ARB			   
84D0 CONSTANT GL_TEXTURE16_ARB			   
84D1 CONSTANT GL_TEXTURE17_ARB			   
84D2 CONSTANT GL_TEXTURE18_ARB			   
84D3 CONSTANT GL_TEXTURE19_ARB			   
84D4 CONSTANT GL_TEXTURE20_ARB			   
84D5 CONSTANT GL_TEXTURE21_ARB			   
84D6 CONSTANT GL_TEXTURE22_ARB			   
84D7 CONSTANT GL_TEXTURE23_ARB			   
84D8 CONSTANT GL_TEXTURE24_ARB			   
84D9 CONSTANT GL_TEXTURE25_ARB			   
84DA CONSTANT GL_TEXTURE26_ARB			   
84DB CONSTANT GL_TEXTURE27_ARB			   
84DC CONSTANT GL_TEXTURE28_ARB			   
84DD CONSTANT GL_TEXTURE29_ARB			   
84DE CONSTANT GL_TEXTURE30_ARB			   
84DF CONSTANT GL_TEXTURE31_ARB			   
84E0 CONSTANT GL_ACTIVE_TEXTURE_ARB		
84E1 CONSTANT GL_CLIENT_ACTIVE_TEXTURE_ARB
84E2 CONSTANT GL_MAX_TEXTURE_UNITS_ARB	

DECIMAL
\ void glActiveTextureARB(GLenum texture);
C-FUNCTION glActiveTextureARB       n -- void

\ void glClientActiveTextureARB(GLenum texture);
C-FUNCTION glClientActiveTextureARB n -- void


\ void glMultiTexCoord1fARB(GLenum target, GLfloat s);
\ void glMultiTexCoord1fvARB(GLenum target, const GLfloat *v);

\ void glMultiTexCoord1iARB(GLenum target, GLint s);
\ void glMultiTexCoord1ivARB(GLenum target, const GLint *v);

\ void glMultiTexCoord2fARB(GLenum target, GLfloat s, GLfloat t);
\ void glMultiTexCoord2fvARB(GLenum target, const GLfloat *v);

\ void glMultiTexCoord2iARB(GLenum target, GLint s, GLint t);
\ void glMultiTexCoord2ivARB(GLenum target, const GLint *v);

\ void glMultiTexCoord3fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r);
\ void glMultiTexCoord3fvARB(GLenum target, const GLfloat *v);

\ void glMultiTexCoord3iARB(GLenum target, GLint s, GLint t, GLint r);
\ void glMultiTexCoord3ivARB(GLenum target, const GLint *v);

\ void glMultiTexCoord4fARB(GLenum target, GLfloat s, GLfloat t, GLfloat r, GLfloat q);
\ void glMultiTexCoord4fvARB(GLenum target, const GLfloat *v);

\ void glMultiTexCoord4iARB(GLenum target, GLint s, GLint t, GLint r, GLint q);
\ void glMultiTexCoord4ivARB(GLenum target, const GLint *v);


\ 
\ Define this token if you want "old_style" header file behaviour (extensions
\ defined in gl.h).  Otherwise, extensions will be included from glext.h.

false   CONSTANT __glext_fs_
glFalse CONSTANT __glext_h_

8750 CONSTANT GL_DEPTH_STENCIL_MESA			    
8751 CONSTANT GL_UNSIGNED_INT_24_8_MESA		    
8752 CONSTANT GL_UNSIGNED_INT_8_24_REV_MESA		
8753 CONSTANT GL_UNSIGNED_SHORT_15_1_MESA		    
8754 CONSTANT GL_UNSIGNED_SHORT_1_15_REV_MESA		

( modeRGB modeA )
C-FUNCTION glBlendEquationSeparateATI             n n -- void

( target image )
C-FUNCTION glEGLImageTargetTexture2DOES           n a -- void

\ GLAPI void APIENTRY glEGLImageTargetRenderbufferStorageOES (GLenum target, GLeglImageOES image);
C-FUNCTION glEGLImageTargetRenderbufferStorageOES n a -- void

\c #if defined(__linux__) || defined(__FreeBSD__) || defined(__FreeBSD_kernel__)
\c #include <GL/glu.h>
\c #endif

\c #elif defined(__APPLE__) && defined(__MACH__)
\c #include <OpenGL/glu.h>

\c #endif

( Extensions )
1 CONSTANT GLU_EXT_object_space_tess
1 CONSTANT GLU_EXT_nurbs_tessellator

( Boolean )
glFalse CONSTANT gluFalse
glTrue  CONSTANT gluTrue

true   CONSTANT __glu_fs_
glTrue CONSTANT __glu_h_

( Version )
gluTrue CONSTANT GLU_VERSION_1.1
gluTrue CONSTANT GLU_VERSION_1.2
gluTrue CONSTANT GLU_VERSION_1.3

( StringName )
100800 CONSTANT GLU_VERSION   
100801 CONSTANT GLU_EXTENSIONS

( ErrorCode )
100900 CONSTANT GLU_INVALID_ENUM           
100901 CONSTANT GLU_INVALID_VALUE          
100902 CONSTANT GLU_OUT_OF_MEMORY          
100903 CONSTANT GLU_INCOMPATIBLE_GL_VERSION
100904 CONSTANT GLU_INVALID_OPERATION      

( NurbsDisplay )
(        GLU_FILL )
100240 CONSTANT GLU_OUTLINE_POLYGON
100241 CONSTANT GLU_OUTLINE_PATCH  

( NurbsCallback )
100103 CONSTANT GLU_NURBS_ERROR             
100103 CONSTANT GLU_ERROR                   
100164 CONSTANT GLU_NURBS_BEGIN             
100164 CONSTANT GLU_NURBS_BEGIN_EXT         
100165 CONSTANT GLU_NURBS_VERTEX            
100165 CONSTANT GLU_NURBS_VERTEX_EXT        
100166 CONSTANT GLU_NURBS_NORMAL            
100166 CONSTANT GLU_NURBS_NORMAL_EXT        
100167 CONSTANT GLU_NURBS_COLOR             
100167 CONSTANT GLU_NURBS_COLOR_EXT         
100168 CONSTANT GLU_NURBS_TEXTURE_COORD     
100168 CONSTANT GLU_NURBS_TEX_COORD_EXT     
100169 CONSTANT GLU_NURBS_END               
100169 CONSTANT GLU_NURBS_END_EXT           
100170 CONSTANT GLU_NURBS_BEGIN_DATA        
100170 CONSTANT GLU_NURBS_BEGIN_DATA_EXT    
100171 CONSTANT GLU_NURBS_VERTEX_DATA       
100171 CONSTANT GLU_NURBS_VERTEX_DATA_EXT   
100172 CONSTANT GLU_NURBS_NORMAL_DATA       
100172 CONSTANT GLU_NURBS_NORMAL_DATA_EXT   
100173 CONSTANT GLU_NURBS_COLOR_DATA        
100173 CONSTANT GLU_NURBS_COLOR_DATA_EXT    
100174 CONSTANT GLU_NURBS_TEXTURE_COORD_DATA
100174 CONSTANT GLU_NURBS_TEX_COORD_DATA_EXT
100175 CONSTANT GLU_NURBS_END_DATA          
100175 CONSTANT GLU_NURBS_END_DATA_EXT      

( NurbsError )
100251 CONSTANT GLU_NURBS_ERROR1 
100252 CONSTANT GLU_NURBS_ERROR2 
100253 CONSTANT GLU_NURBS_ERROR3 
100254 CONSTANT GLU_NURBS_ERROR4 
100255 CONSTANT GLU_NURBS_ERROR5 
100256 CONSTANT GLU_NURBS_ERROR6 
100257 CONSTANT GLU_NURBS_ERROR7 
100258 CONSTANT GLU_NURBS_ERROR8 
100259 CONSTANT GLU_NURBS_ERROR9 
100260 CONSTANT GLU_NURBS_ERROR10
100261 CONSTANT GLU_NURBS_ERROR11
100262 CONSTANT GLU_NURBS_ERROR12
100263 CONSTANT GLU_NURBS_ERROR13
100264 CONSTANT GLU_NURBS_ERROR14
100265 CONSTANT GLU_NURBS_ERROR15
100266 CONSTANT GLU_NURBS_ERROR16
100267 CONSTANT GLU_NURBS_ERROR17
100268 CONSTANT GLU_NURBS_ERROR18
100269 CONSTANT GLU_NURBS_ERROR19
100270 CONSTANT GLU_NURBS_ERROR20
100271 CONSTANT GLU_NURBS_ERROR21
100272 CONSTANT GLU_NURBS_ERROR22
100273 CONSTANT GLU_NURBS_ERROR23
100274 CONSTANT GLU_NURBS_ERROR24
100275 CONSTANT GLU_NURBS_ERROR25
100276 CONSTANT GLU_NURBS_ERROR26
100277 CONSTANT GLU_NURBS_ERROR27
100278 CONSTANT GLU_NURBS_ERROR28
100279 CONSTANT GLU_NURBS_ERROR29
100280 CONSTANT GLU_NURBS_ERROR30
100281 CONSTANT GLU_NURBS_ERROR31
100282 CONSTANT GLU_NURBS_ERROR32
100283 CONSTANT GLU_NURBS_ERROR33
100284 CONSTANT GLU_NURBS_ERROR34
100285 CONSTANT GLU_NURBS_ERROR35
100286 CONSTANT GLU_NURBS_ERROR36
100287 CONSTANT GLU_NURBS_ERROR37

( NurbsProperty )
100200 GLU_AUTO_LOAD_MATRIX     
100201 GLU_CULLING              
100203 GLU_SAMPLING_TOLERANCE   
100204 GLU_DISPLAY_MODE         
100202 GLU_PARAMETRIC_TOLERANCE 
100205 GLU_SAMPLING_METHOD      
100206 GLU_U_STEP               
100207 GLU_V_STEP               
100160 GLU_NURBS_MODE           
100160 GLU_NURBS_MODE_EXT       
100161 GLU_NURBS_TESSELLATOR    
100161 GLU_NURBS_TESSELLATOR_EXT
100162 GLU_NURBS_RENDERER       
100162 GLU_NURBS_RENDERER_EXT   

( NurbsSampling )
100208 GLU_OBJECT_PARAMETRIC_ERROR    
100208 GLU_OBJECT_PARAMETRIC_ERROR_EXT
100209 GLU_OBJECT_PATH_LENGTH         
100209 GLU_OBJECT_PATH_LENGTH_EXT     
100215 GLU_PATH_LENGTH                
100216 GLU_PARAMETRIC_ERROR           
100217 GLU_DOMAIN_DISTANCE            

( NurbsTrim )
100210 CONSTANT GLU_MAP1_TRIM_2                    
100211 CONSTANT GLU_MAP1_TRIM_3                    

( QuadricDrawStyle )
100010 CONSTANT GLU_POINT     
100011 CONSTANT GLU_LINE      
100012 CONSTANT GLU_FILL      
100013 CONSTANT GLU_SILHOUETTE

( QuadricCallback )
(        GLU_ERROR )

( QuadricNormal )
100000 CONSTANT GLU_SMOOTH
100001 CONSTANT GLU_FLAT  
100002 CONSTANT GLU_NONE  

( QuadricOrientation )
100020 CONSTANT GLU_OUTSIDE      
100021 CONSTANT GLU_INSIDE       

( TessCallback )
100100 CONSTANT GLU_TESS_BEGIN         
100100 CONSTANT GLU_BEGIN              
100101 CONSTANT GLU_TESS_VERTEX        
100101 CONSTANT GLU_VERTEX             
100102 CONSTANT GLU_TESS_END           
100102 CONSTANT GLU_END                
100103 CONSTANT GLU_TESS_ERROR         
100104 CONSTANT GLU_TESS_EDGE_FLAG     
100104 CONSTANT GLU_EDGE_FLAG          
100105 CONSTANT GLU_TESS_COMBINE       
100106 CONSTANT GLU_TESS_BEGIN_DATA    
100107 CONSTANT GLU_TESS_VERTEX_DATA   
100108 CONSTANT GLU_TESS_END_DATA      
100109 CONSTANT GLU_TESS_ERROR_DATA    
100110 CONSTANT GLU_TESS_EDGE_FLAG_DATA
100111 CONSTANT GLU_TESS_COMBINE_DATA  

( TessContour )
100120 CONSTANT GLU_CW      
100121 CONSTANT GLU_CCW     
100122 CONSTANT GLU_INTERIOR
100123 CONSTANT GLU_EXTERIOR
100124 CONSTANT GLU_UNKNOWN 

( TessProperty )
100140 CONSTANT GLU_TESS_WINDING_RULE 
100141 CONSTANT GLU_TESS_BOUNDARY_ONLY
100142 CONSTANT GLU_TESS_TOLERANCE    

( TessError )
100151 CONSTANT GLU_TESS_ERROR1               
100152 CONSTANT GLU_TESS_ERROR2               
100153 CONSTANT GLU_TESS_ERROR3               
100154 CONSTANT GLU_TESS_ERROR4               
100155 CONSTANT GLU_TESS_ERROR5               
100156 CONSTANT GLU_TESS_ERROR6               
100157 CONSTANT GLU_TESS_ERROR7               
100158 CONSTANT GLU_TESS_ERROR8               
100151 CONSTANT GLU_TESS_MISSING_BEGIN_POLYGON
100152 CONSTANT GLU_TESS_MISSING_BEGIN_CONTOUR
100153 CONSTANT GLU_TESS_MISSING_END_POLYGON  
100154 CONSTANT GLU_TESS_MISSING_END_CONTOUR  
100155 CONSTANT GLU_TESS_COORD_TOO_LARGE      
100156 CONSTANT GLU_TESS_NEED_COMBINE_CALLBACK

( TessWinding )
100130  CONSTANT  GLU_TESS_WINDING_ODD        
100131  CONSTANT  GLU_TESS_WINDING_NONZERO    
100132  CONSTANT  GLU_TESS_WINDING_POSITIVE   
100133  CONSTANT  GLU_TESS_WINDING_NEGATIVE   
100134  CONSTANT  GLU_TESS_WINDING_ABS_GEQ_TWO
1.0e150 FCONSTANT GLU_TESS_MAX_COORD

\ void gluBeginCurve (GLUnurbs* nurb);
C-FUNCTION gluBeginCurve            gluBeginCurve           a                         -- void

\ void gluBeginPolygon (GLUtesselator* tess);
C-FUNCTION gluBeginPolygon          gluBeginPolygon         a                         -- void

\ void gluBeginSurface (GLUnurbs* nurb);
C-FUNCTION gluBeginSurface          gluBeginSurface         a                         -- void

\ void gluBeginTrim (GLUnurbs* nurb);
C-FUNCTION gluBeginTrim             gluBeginTrim            a                         -- void

\ GLboolean gluCheckExtension (const GLubyte *extName, const GLubyte *extString);
C-FUNCTION c_gluCheckExtension      gluCheckExtension       a a                       -- n

\ void gluCylinder (GLUquadric* quad, GLdouble base, GLdouble top, GLdouble height, GLint slices, GLint stacks);
C-FUNCTION c_gluCylinder            gluCylinder             a n n n n n               -- void

\ void gluDeleteNurbsRenderer (GLUnurbs* nurb);
C-FUNCTION gluDeleteNurbsRenderer   gluDeleteNurbsRenderer  a                         -- void  

\ void gluDeleteQuadric (GLUquadric* quad);
C-FUNCTION gluDeleteQuadric         gluDeleteQuadric        a                         -- void 

\ void gluDeleteTess (GLUtesselator* tess);
C-FUNCTION gluDeleteTess            gluDeleteTess           a                         -- void 

\ void gluDisk (GLUquadric* quad, GLdouble inner, GLdouble outer, GLint slices, GLint loops);
C-FUNCTION c_gluDisk                gluDisk                 a r r n n                 -- void

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

: GLbytes     ( n -- n )
    GLbyte * ;

: GLenum     ( n -- n )
    GLenum * ;

: GLints      ( n -- n )
    GLint * ;

: GLubytes      ( n -- n )
    GLubytes * ;

: GLbooleans  ( n -- n )
    GLboolean * ;

: GLbitfields ( n -- n )
    GLbitfield * ;

: GLsizes     ( n -- n )
    GLsizei * ;

: GLfloats    ( n -- n )
    GLfloat * ;

: GLclampfs   ( n -- n )
    GLclampf * ;

: GLUnurbs
    gluNewNurbsRenderer CONSTANT ;

: GLUquadric   
    gluNewQuadric CONSTANT ;

: GLUtesselator 
    gluNewTess CONSTANT ;

: glTrue?  
    glTrue = ;

: gluTrue? 
    gluTrue  = ;
    .
