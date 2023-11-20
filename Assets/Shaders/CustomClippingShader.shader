Shader "Custom/CustomClippingShader"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" { }
        _MaskTex("Mask (A)", 2D) = "white" { }
    }

        SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
        }

        Pass
        {
            Stencil
            {
                Ref 1
                Comp always
                Pass replace
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            SetTexture[_MaskTex]
            {
                combine primary
            }
        }

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        sampler2D _MaskTex;

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Lấy giá trị alpha từ texture
            half4 c = tex2D(_MainTex, IN.uv_MainTex);

            // Lấy giá trị alpha từ mask texture
            half maskAlpha = tex2D(_MaskTex, IN.uv_MainTex).a;

            // Nếu giá trị alpha của mask texture là 0, làm cho alpha trở thành 0
            c.a *= maskAlpha;

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Overlay"
        }

        Pass
        {
            Stencil
            {
                Ref 1
                Comp equal
                Pass keep
            }
            SetTexture[_MainTex]
            {
                combine previous
            }
        }

        CGPROGRAM
        #pragma vertex vert
        #pragma exclude_renderers gles xbox360 ps3
        ENDCG

        SetTexture[_MaskTex]:
        {
            combine primary
        }
    }

            Fallback "Diffuse"
}
