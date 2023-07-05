Shader "Unlit/circle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PlayTime ("PlayTime", float) = 0.0

        _Volume ("Volume", Range(0.0, 1.0)) = 0.5
        _VolumeThickness("VolumeThickness", Range(0.0, 0.5)) = 0.05

        _R("R", Range(0.0, 1.0)) = 1.0
        _G("G", Range(0.0, 1.0)) = 1.0
        _B("B", Range(0.0, 1.0)) = 1.0
        _Color("Color", Color) = (1,1,1,1)
    }

    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100
        
        Pass
        {
            CGPROGRAM

            #pragma vertex vert_img
            #pragma fragment frag

            #include "UnityCG.cginc"
            #define PI 3.1415926359
            
            float _PlayTime;

            float _Volume;
            float _VolumeThickness;
            
            float _R;
            float _G;
            float _B;
            float4 _Color;

            float4 frag(v2f_img i) : SV_Target
            {
                _Color.r = _R;
                _Color.g = _G;
                _Color.b = _B;
                
                float d = distance(float2(0.5, 0.5), i.uv);
                float2 st = 0.5 - i.uv;
                float a = atan2(st.y, st.x);
                float r = (a + PI) / (PI * 2);

                float vol = _Volume/2;
                _VolumeThickness = _PlayTime*0.005;
                if(d <= vol && d >= vol - _VolumeThickness)return _Color;
                
                return float4(0.0, 0.0, 0.0, 0.0);
            }

            ENDCG
        }
    }
}
