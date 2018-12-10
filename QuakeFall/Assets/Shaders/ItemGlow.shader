Shader "Custom/Glow"
{
	Properties
	{
		_Color ("Colour", Color) = (1,1,1,1)
		_MainTex ("Albedo", 2D) = "white" {}
		_BumpMap ("Normal Map", 2D) = "bump" {}
		_RimColour ("Rim Colour", Color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(0, 6)) = 3
	}
	SubShader
	{
		Tags
		{
		"RenderType"="Opaque"
		}

		CGPROGRAM
		#pragma surface surf Lambert
		
		struct Input
		{
		    float4 colour : Color;
		    float2 uv_MainTex;
		    float2 bump;
		    float3 viewDir;
		};
		
		float4 _Color;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColour;
		float _RimPower;
		
		void surf (Input IN, inout SurfaceOutput OUT)
		{
			IN.colour = _Color;
			OUT.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb * IN.colour;
			OUT.Normal = UnpackNormal (tex2D (_BumpMap, IN.bump));
			
			half rim = 1 - saturate (dot (normalize (IN.viewDir), OUT.Normal));
			OUT.Emission = _RimColour.rgb * pow(rim, _RimPower);
		}
		ENDCG
	}
}
