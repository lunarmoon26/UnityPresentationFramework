Shader "Custom/MaskedTexture" {
   Properties
   {
   	  _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
      _MainTex ("Base (RGB)", 2D) = "white" {}
      _Mask ("Culling Mask", 2D) = "white" {}
      _Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
	  _OutlineColor ("Outline Color", Color) = (0,0,0,1)
	  _Outline ("Outline width", Range (.002, 0.03)) = .005
   }
   SubShader
   {
      Tags {"Queue"="Transparent"}
      Lighting Off
      ZWrite Off
      Blend SrcAlpha OneMinusSrcAlpha
      AlphaTest GEqual [_Cutoff]
      UsePass "Toon/Basic Outline/OUTLINE"
      Pass
      {
         SetTexture [_Mask] {combine texture}
         SetTexture [_MainTex] {combine texture, previous}
      }
   }
}
