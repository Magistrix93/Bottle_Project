// Specular, Normal Maps with Main Texture
// Fragment based
Shader "AndroidPointLight"
{
	Properties
	{
		_Shininess("Shininess", Range(0, 1.5)) = 0.078125
		_Color("Main Color", Color) = (1,1,1,1)
		_SpecColor("Specular Color", Color) = (0, 0, 0, 0)
		_MainTex("Texture", 2D) = "white" {}
		_BumpMap("Bump Map", 2D) = "bump" {}
		_NormalStrength("Normal Strength", Range(0, 1.5)) = 1
	} // eo Properties
		SubShader
	{
		// pass for 4 vertex lights, ambient light & first pixel light
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf MobileBlinnPhong

		fixed4 LightingMobileBlinnPhong(SurfaceOutput s, fixed3 lightDir, fixed3 halfDir, fixed atten)
	{
		fixed diff = saturate(dot(s.Normal, lightDir));
		fixed nh = saturate(dot(s.Normal, halfDir)); //Instead of injecting the normalized light+view, we just inject view, which is provided as halfasview in the initial surface shader CG parameters

		fixed spec = pow(nh, s.Specular * 128) * s.Gloss;

		fixed4 c;
		c.rgb = (s.Albedo * _LightColor0.rgb * diff + _SpecColor.rgb * spec) * (atten * 2);
		c.a = 0.0;
		return c;
	}

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
	};

	// User-specified properties
	uniform sampler2D _MainTex;
	uniform sampler2D _BumpMap;
	uniform float _Shininess;
	uniform float _NormalStrength;
	uniform fixed4 _Color;

	float3 expand(float3 v) { return (v - 0.5) * 2; } // eo expand 

	void surf(Input IN, inout SurfaceOutput o) {
		half4 tex = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = tex.rgb;
		o.Gloss = tex.a;
		o.Alpha = tex.a;
		o.Specular = _Shininess;

		// fetch and expand range-compressed normal
		float3 normalTex = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		float3 normal = normalTex * _NormalStrength;
		o.Normal = normal;
	} // eo surf

	ENDCG
	}
		//Fallback "Specular"
} // eo Shader
