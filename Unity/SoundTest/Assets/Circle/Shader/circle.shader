Shader "Unlit/circle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Thickness ("Thickness", Range(0.0, 0.5)) = 0.0
        _BaseCircle ("BaseCircle", Range(0.0, 0.5)) = 0.05
        _Radius ("Radius", Range(0.0, 0.5)) = 0.0

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
            
            float _Thickness;
            float _BaseCircle;
            float _Radius;

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

                if (d <= _BaseCircle)
                {
                    return _Color;
                }
                else if (d <= _Radius && d >= _Radius - _Thickness)
                {
                    return _Color;
                }
                else
                {
                    return 0.0;
                }
            }

            ENDCG
        }
    }
}
