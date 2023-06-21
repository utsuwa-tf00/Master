Shader "Unlit/volume"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Volume ("Volume", Range(0.0, 0.5)) =  0.0
        _VolumeThickness("VolumeThickness",float) = 0.01
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
            
            float _Volume;
            float _VolumeThickness;

            float4 frag(v2f_img i) : SV_Target
            {
                float d = distance(float2(0.5, 0.5), i.uv);
                float vol = _Volume/2;
                float volT = _VolumeThickness/2;
                float col = 0.5+(0.5*_Volume);
                //_VolumeThickness = vol;
                if(d <= vol && d >= volT || d >= vol && d <= volT)
                {
                    return col;
                }
                return 0;
            }

            ENDCG
        }
    }
}
