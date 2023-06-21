Shader "Unlit/circle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PlayTime ("PlayTime", float) = 0.0

        _Volume ("Volume", Range(0.0, 1.0)) = 0.5
        _VolumeThickness("VolumeThickness", Range(0.0, 0.5)) = 0.05

        _InnerCircle ("BaseCircle", Range(0.0, 0.5)) = 0.05

        _Outer1Circle ("Outer1Circle", Range(0.0, 0.5)) = 0.0
        _Outer1Thickness ("Outer1Thickness", Range(0.0, 0.5)) = 0.05
        _Outer2Circle ("Outer2Circle", Range(0.0, 0.5)) = 0.0
        _Outer2Thickness ("Outer2Thickness", Range(0.0, 0.5)) = 0.05
        _Outer3Circle ("Outer3Circle", Range(0.0, 0.5)) = 0.0
        _Outer3Thickness ("Outer3Thickness", Range(0.0, 0.5)) = 0.05
        _Outer4Circle ("Outer4Circle", Range(0.0, 0.5)) = 0.0
        _Outer4Thickness ("Outer4Thickness", Range(0.0, 0.5)) = 0.05

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

            float _InnerCircle;

            float _Outer1Circle;
            float _Outer1Thickness;
            float _Outer2Circle;
            float _Outer2Thickness;
            float _Outer3Circle;
            float _Outer3Thickness;
            float _Outer4Circle;
            float _Outer4Thickness;

            float _R;
            float _G;
            float _B;
            float4 _Color;

            float4 PlayTime1(float d, float r)
            {
                if(d <= _Outer1Circle && d >= _Outer1Circle - _Outer1Thickness)
                {
                    if (r >= 0.2 && r <= 0.3 || r >= 0.7 && r <= 0.8)
                    {
                        return _Color;
                    }
                }
                
                if (d <= _Outer2Circle && d >= _Outer2Circle - _Outer2Thickness)
                {
                    if (r >= 0.1 && r <= 0.4 || r >= 0.6 && r <= 0.9)
                    {
                        return _Color;
                    }
                }
                
                if (d <= _Outer4Circle && d >= _Outer4Circle - _Outer4Thickness)
                {
                    if (r >= 0.05 && r <= 0.45 || r >= 0.55 && r <= 0.95)
                    {
                        return _Color;
                    }
                }

                return float4(0.0, 0.0, 0.0, 0.0);
            }

            float4 PlayTime2(float d, float r)
            {
                if (d <= _Outer2Circle && d >= _Outer2Circle - _Outer2Thickness)
                {
                    if (r >= 0.1 && r <= 0.4 || r >= 0.6 && r <= 0.9)
                    {
                        return _Color;
                    }
                }
                
                if (d <= _Outer4Circle && d >= _Outer4Circle - _Outer4Thickness)
                {
                    if (r >= 0.05 && r <= 0.45 || r >= 0.55 && r <= 0.95)
                    {
                        return _Color;
                    }
                }

                return float4(0.0, 0.0, 0.0, 0.0);
            }

            float4 PlayTime3(float d, float r)
            {
                if (d <= _Outer2Circle && d >= _Outer2Circle - _Outer2Thickness)
                {
                    if (r >= 0.15 && r <= 0.35 || r >= 0.65 && r <= 0.85)
                    {
                        return _Color;
                    }
                }

                if (d <= _Outer3Circle && d >= _Outer3Circle - _Outer3Thickness)
                {
                    if (r >= 0.0 && r <= 0.05 || r >= 0.45 && r <= 0.55 || r >= 0.95 && r <= 1)
                    {
                        return _Color;
                    }
                }
                
                if (d <= _Outer4Circle && d >= _Outer4Circle - _Outer4Thickness)
                {
                    if (r >= 0.05 && r <= 0.45 || r >= 0.55 && r <= 0.95)
                    {
                        return _Color;
                    }
                }

                return float4(0.0, 0.0, 0.0, 0.0);
            }

            float4 PlayTime4(float d, float r)
            {
                if (d <= _Outer4Circle && d >= _Outer4Circle - _Outer4Thickness)
                {
                    if (r >= 0.05 && r <= 0.45 || r >= 0.55 && r <= 0.95)
                    {
                        return _Color;
                    }
                }

                return float4(0.0, 0.0, 0.0, 0.0);
            }

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

                if(_PlayTime == 1)
                {
                    return PlayTime1(d, r);
                }
                else if(_PlayTime == 2)
                {
                    return PlayTime2(d, r);
                }
                else if(_PlayTime == 3)
                {
                    return PlayTime3(d, r);
                }
                else if(_PlayTime == 4)
                {
                    return PlayTime4(d, r);
                }
                
                return float4(0.0, 0.0, 0.0, 0.0);
            }

            ENDCG
        }
    }
}
