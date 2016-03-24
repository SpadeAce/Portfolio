Shader "SpadeShader/Object"
{
	Properties 
	{
		_MainTex ("Diffuse (RGB) Alpha (A)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)
		_AmbientColor ("Ambient Color", Color) = (0.1, 0.1, 0.1, 0.1)	
		_LightingRamp ("Lighting Ramp (RGB)", 2D) = "white" {}
	}

	SubShader
	{	
		Tags {"Queue"="Geometry" "IgnoreProjector"="True" "RenderType"="Opaque"}
		LOD 200

		
		CGPROGRAM
		#pragma surface surf Aniso exclude_path:prepass nolightmap noforwardadd halfasview noambient keepalpha
		#pragma target 2.0
			
			struct SurfaceOutputAniso 
			{
				fixed3 Albedo;
				fixed3 Normal;
				fixed3 Emission;
				half Specular;
				fixed Gloss;
				fixed Alpha;
				fixed AnisoMask;
			};
					
			struct Input
			{
				float2 uv_MainTex;
			};

			sampler2D _MainTex, _LightingRamp;
			fixed4 _SpecularColor, _AmbientColor, _Color;
			
			void surf (Input IN, inout SurfaceOutputAniso o)
			{
				fixed4 albedo = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = lerp(albedo.rgb,albedo.rgb*_Color.rgb,0.5);
			}

			inline fixed4 LightingAniso (SurfaceOutputAniso s, fixed3 lightDir, fixed3 viewDir, fixed atten)
			{
				fixed3 h = normalize(normalize(lightDir) + normalize(viewDir));
				float NdotL = saturate(dot(s.Normal, lightDir));
				half3 diff = tex2D (_LightingRamp, float2(NdotL * 0.5 + 0.5,0.5));
				
				fixed HdotA = dot(s.Normal, h);
				float aniso = max(0, sin(radians(HdotA * 180)));
				
				float spec = saturate(dot(s.Normal, h));
				
				fixed4 c;
				c.rgb = (((s.Albedo * _LightColor0.rgb * diff * _Color) +
					(_LightColor0.rgb * spec * _SpecularColor * NdotL) +
					(s.Albedo * _Color * _AmbientColor)) * (atten));
				c.a = s.Alpha;
				
				return c;
			}
		ENDCG
	}

	FallBack "Transparent/Cutout/VertexLit"
}