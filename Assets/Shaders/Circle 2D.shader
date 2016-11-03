Shader "Custom/Circle 2D" {
      Properties {
          _Color ("Color", Color) = (1,0,0,0)
          _Thickness("Thickness", Range(0.0,0.5)) = 0.05
          _Radius("Radius", Range(0.0, 0.5)) = 0.4
          _Dropoff("Dropoff", Range(0.01, 4)) = 0.1
      }
      SubShader {


      		Tags {"Queue"="Transparent"}
      		Lighting Off
      		ZWrite Off
              Blend SrcAlpha OneMinusSrcAlpha // Alpha blending
              LOD 100
          Pass {

              CGPROGRAM
             
              #pragma vertex vert
              #pragma fragment frag
              #include "UnityCG.cginc"
             
             
              fixed4 _Color; // low precision type is usually enough for colors
             float _Thickness;
             float _Radius;
             float _Dropoff;
             
              struct fragmentInput {
                  float4 pos : SV_POSITION;
                  float2 uv : TEXTCOORD0;
              };
  
              fragmentInput vert (appdata_base v)
              {
                  fragmentInput o;
  
                  o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                  o.uv = v.texcoord.xy - fixed2(0.5,0.5);
  
                  return o;
              }
  
              // r = radius
              // d = distance
              // t = thickness
              // p = % thickness used for dropoff
              float antialias(float r, float d, float t, float p) {
                  if( d < (r - 0.5*t))
                     return - pow( d - r + 0.5*t,2)/ pow(p*t, 2) + 1.0;
                 else if ( d > (r + 0.5*t))
                     return - pow( d - r - 0.5*t,2)/ pow(p*t, 2) + 1.0; 
                 else
                     return 1.0;
              }
              
              fixed4 frag(fragmentInput i) : SV_Target {
                 float distance = sqrt(pow(i.uv.x, 2) + pow(i.uv.y,2));
                     
                 return fixed4(_Color.r, _Color.g, _Color.b, _Color.a*antialias(_Radius, distance, _Thickness, _Dropoff));
              }
              
              
              ENDCG



          }
      }
  }
