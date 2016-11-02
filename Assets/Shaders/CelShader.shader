Shader "Custom/CelShader" {
	Properties {
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Mask ("Culling Mask", 2D) = "white" {}
        _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
	    _OutlineColor ("Outline Color", Color) = (0,0,0,1)
	    _Outline ("Outline width", Range (.002, 0.03)) = .005
	}
	SubShader {
		Tags {
			"Queue" = "Transparent"
			"RenderType" = "Opaque"
		}
		LOD 200

		Lighting Off
      ZWrite Off
      Blend SrcAlpha OneMinusSrcAlpha
      AlphaTest GEqual [_Cutoff]
      UsePass "Toon/Basic Outline/OUTLINE"
      Pass
      {
         SetTexture [_Mask] {combine texture}
      }


		CGPROGRAM
		#pragma surface surf CelShadingForward
		#pragma target 3.0

		half4 LightingCelShadingForward(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			NdotL = smoothstep(0, 0.025f, NdotL);
			half4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten * 2);
			c.a = s.Alpha;
			return c;
		}

		sampler2D _MainTex;
		fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG

	}
	FallBack "Diffuse"
}
