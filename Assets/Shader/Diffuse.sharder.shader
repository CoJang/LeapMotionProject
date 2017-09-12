// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

  Shader "Example/Diffuse Bump" 
  {
    Properties
    {
        _Density ("Density", Range(2,50)) = 30
		
		_ColorA ("Color A", Color) = (1,1,1,1)
        _ColorB ("Color B", Color) = (0,0,0,0)
		
		_ResX ("X Resolution", Float) = 100
        _ResY ("Y Resolution", Float) = 200
		
		_ScaleWithZoom("Scale With Cam Distance", Range(0,1)) = 1.0
    }
	
    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma target 3.0
			
			#include "UnityCG.cginc"
			
			float rand(float2 co)
			{
					return frac((sin( dot(co.xy, float2(12.345 * _Time.w, 67.890 * _Time.w) ))
								* 12345.67890 + _Time.w));
			}
			
			fixed4 _ColorA;
			fixed4 _ColorB;
			
			float _ResX;
			float _ResY;
			float _ScaleWithZoom;
			
			struct vertexInput
			{
				float4 vertex : POSITION;
				float4 texcoord0 : TEXCOORD0;
				float4 texcoord1 : TEXCOORD2;
			};
			
			struct fragmentInput
			{
				float4 position : SV_POSITION;
				float4 texcoord0 : TEXCOORD0;
				float4 camDist : TEXCOORD2;
			};
			
			fragmentInput vert(vertexInput i)
			{
				fragmentInput o;
				o.position = UnityObjectToClipPos (i.vertex);
				o.texcoord0 = i.texcoord0;
				
				float4 modelOrigin = mul(unity_ObjectToWorld, float4(0.0, 0.0, 0.0, 1.0));
				o.camDist.x = distance(_WorldSpaceCameraPos.xyz, modelOrigin.xyz);
				o.camDist = lerp(1.0, o.camDist.x, _ScaleWithZoom);
				
				return o;
			}

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Density;

            v2f vert (float4 pos : POSITION, float2 uv : TEXCOORD0)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(pos);
                o.uv = uv * _Density;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 c = i.uv;
                c = floor(c) / 2;
                float checker = frac(c.x + c.y) * 2;
                return checker;
            }
            ENDCG
        }
    }
}