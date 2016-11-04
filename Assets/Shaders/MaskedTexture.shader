Shader "Custom/MaskedTexture" {
   Properties
   {
   	  _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
      _MainTex ("Base (RGB)", 2D) = "white" {}
      _Mask ("Culling Mask", 2D) = "white" {}
      _CutOff ("Alpha Cutoff", Range (0,1)) = 0.1
      _AlphaKeep ("Alpha Keep", Range (0,1)) = 1 // Keep All
   }
   SubShader
   {
      Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
      Lighting Off
      ZWrite Off
      Blend SrcAlpha OneMinusSrcAlpha
      LOD 100
      Pass
      {
		CGPROGRAM

		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"


		fixed4 _Color; // low precision type is usually enough for colors
		sampler2D _MainTex;
		sampler2D _Mask;
		float _CutOff;
		fixed _AlphaKeep;

		struct fragmentInput {
			float4 pos : SV_POSITION;
			float2 uv : TEXTCOORD0;
		};

		fragmentInput vert (appdata_base v)
		{
			fragmentInput o;

			o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
			o.uv = v.texcoord.xy;

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
			fixed4 col = tex2D(_MainTex, i.uv);
			fixed4 msk = tex2D(_Mask, i.uv);

			col *= _Color;
			if(msk.a < _CutOff || (_AlphaKeep < 1 && (msk.r + 0.001 < _AlphaKeep || msk.r - 0.001 > _AlphaKeep))) discard;
			col.a *= msk.a;
			return col;
		}
		ENDCG
      }
   }
}
