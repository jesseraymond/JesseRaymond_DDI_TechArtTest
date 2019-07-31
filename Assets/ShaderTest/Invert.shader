Shader "Unlit/Invert"
{
	Properties
	{
		// TODO For this part of the test you will need to add a slider value for what is inverting the color
		// You will also need to add a color tint field that is applied to your final color
		// (Intermediate) Insure that this shader supports Vertex Color as used by UI and Sprites
		// (Intermediate) Insure that combining material tint and vertex tint is done in the most efficient way
		// (Advanced) Insure that this shader supports Unity UI masking
		// ((Optional) Advanced Math) Invert color but not luminosity (I'm sure this can be done, but tricky!)
		// ((Optional) Extended) Put Color and Luminosity on seperate sliders.
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100

		Pass
		{

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			// TODO If you are unfamiliar with shaders replicate your properties here to be able to use them
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				// TODO Problem soving, figure out how to blend between normal and inverted color efficiently
				col.rgb = 1-col.rgb;
				return col;
			}
			ENDCG
		}
	}
}
