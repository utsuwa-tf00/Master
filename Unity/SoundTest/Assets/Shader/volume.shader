Shader "Unlit/volume"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Volume ("VOLUME", float) =  0.0
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

            float4 frag(v2f_img i) : SV_Target
            {
                return 0;
            }

            ENDCG
        }
    }
}
