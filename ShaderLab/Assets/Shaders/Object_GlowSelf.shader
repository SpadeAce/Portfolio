Shader "SpadeShader/Object_GlowSelf"
{
	Properties 
	{
		_MainTex ("Diffuse (RGB) Alpha (A)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,1)
		_GlowColor ("Glow Color", Color) = (0,0,0,1)
		_Glow ("Glow width", Range (0, 0.2)) = .005
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
			fixed4 _SpecularColor, _AmbientColor, _Color, _GlowColor;
			
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
						(s.Albedo * _Color * _AmbientColor)) * (atten)) * ((_GlowColor * _GlowColor.a)+1.0);
				c.a = s.Alpha;
				
				return c;
			}
		ENDCG

		Pass 
	    {
	        // Pass drawing outline
	        Cull Front
			//Cull Back
			ZWrite Off
	        //Blend SrcAlpha OneMinusSrcAlpha
	        Blend SrcAlpha One
			//Blend OneMinusSrcAlpha One
			CGPROGRAM
	        #include "UnityCG.cginc"
	        #pragma vertex vert
	        #pragma fragment frag
			
	        uniform float _Glow;
	        uniform float4 _GlowColor;
	        uniform float4 _MainTex_ST;
	        uniform sampler2D _MainTex; 
			
	        struct v2f 
	        {
	            float4 pos : POSITION;
	            float4 color : COLOR;
	        };
			
	        v2f vert(appdata_base v)
	        {
				v2f o;
	            o.pos = mul (UNITY_MATRIX_MVP, v.vertex);	
	            float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
	            float2 offset = TransformViewToProjection(norm.xy);

	            o.pos.xy += offset  * _Glow;
	            o.color = _GlowColor;

				o.color.a = _GlowColor.a * -norm.z;//-pos.z;//-v.normal;
	            return o;
	        }
			
	        half4 frag(v2f i) :COLOR 
	        {
	            return i.color;
	        }
	        
			ENDCG
	    }

	}

	FallBack "Transparent/Cutout/VertexLit"
}