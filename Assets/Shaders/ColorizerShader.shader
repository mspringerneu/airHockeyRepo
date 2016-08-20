Shader "Custom/ColorizerShader" {
	Properties 
	{
		_Color ("Tint Color", Color) = (1.0, 0.0, 0.0, 1.0)
	}

	SubShader 
	{
		Tags { "Queue"="Geometry" }

		Pass
		{
		
			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma exclude_renderers ps3 xbox360
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0

			uniform fixed4 _Color;

			struct vertexInput 
			{
				float4 vertex : POSITION; // position (in object coordinates)
			};
	
			struct fragmentInput
			{
				float4 pos : SV_POSITION;
				float4 color : COLOR0;
			};
	
			fragmentInput vert(vertexInput i)
			{
				fragmentInput o;
				o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
				o.color = _Color;
	
				return o;
			}
	
			half4 frag(fragmentInput i) : COLOR
			{
				return i.color;
				//return half4(1.0, 0.0, 0.0, 0.2);
			}
	
			ENDCG
		}
	}
	FallBack "Diffuse"
}
