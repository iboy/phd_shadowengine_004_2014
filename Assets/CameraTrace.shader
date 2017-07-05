Shader "Custom/CameraTrace" {
    Properties {
 
        _Color ("Main Color", Color) = (0.5, 0.5, 0.5, 0.5)
 
        _MainTex ("Texture", 2D) = "white" {}
 
    }
 
    SubShader {
 
        Tags { "Queue"="Background-1000" "IgnoreProjector"="True" "RenderType"="Transparent" }
 
        ZWrite Off
 
        ColorMask RGB
 
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass {
 
            SetTexture [_MainTex] {
 
                constantColor [_Color]
 
                combine constant * texture DOUBLE
 
            }
 
        }
 
    }
 
}