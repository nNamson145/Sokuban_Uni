Shader "Unlit/PerfectCenteredGrid"
{
    Properties
    {
        _GridSize ("Grid Size", Float) = 10
        _LineThickness ("Line Thickness", Range(0.001, 0.1)) = 0.02
        _LineColor ("Line Color", Color) = (0, 0, 0, 1) // Màu đường kẻ
        _BackgroundColor ("Background Color", Color) = (1, 1, 1, 1) // Màu nền

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _GridSize;
            float _LineThickness;
            float4 _LineColor;
            float4 _BackgroundColor;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv * 2.0 - 1.0; // Căn giữa tọa độ UV từ (0,1) thành (-1,1)
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 gridPos = abs(frac(i.uv * _GridSize - 0.5) - 0.5);
                float gridLine = min(gridPos.x, gridPos.y) < _LineThickness ? 1.0 : 0.0;

                // Dùng lerp để blend giữa màu nền và màu đường kẻ
                return lerp(_BackgroundColor, _LineColor, gridLine);
            }
            ENDCG
        }
    }
}