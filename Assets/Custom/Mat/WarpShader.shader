Shader "Custom/WarpShader"
{
    Properties
    {
        _HeightMin ("Height Min", Float) = 0
        _HeightMax ("Height Max", Float) = 1
        _ColorMin ("Tint Color At Min", Color) = (1,1,1,1)
        _ColorMax ("Tint Color At Max", Color) = (1,1,1,0)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
			    float4 worldPos: TEXCOORD1;
            };

            fixed4 _ColorMin;
            fixed4 _ColorMax;
            float _HeightMin;
            float _HeightMax;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
               float h = clamp((_HeightMax-i.worldPos.y) / (_HeightMax-_HeightMin), 0, 1);
               fixed4 tintColor = lerp(_ColorMax.rgba, _ColorMin.rgba, h);
               return tintColor;
            }
            ENDCG
        }
    }
}
