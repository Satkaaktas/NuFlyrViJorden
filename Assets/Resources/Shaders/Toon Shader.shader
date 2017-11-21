Shader "TheWorldEndsWithUs/CelShader"
 {
     Properties
     {
         _Color("Main Color", Color) = (1, 1, 1, 1)
         _MainTex("Albedo (RGB)", 2D) = "white" {}
		 _RimColor ("Rim Color", Color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(0, 10)) = 1
     }

         SubShader
         {
             Tags
             {
                 "RenderType" = "Opaque"
             }
         LOD 200

         CGPROGRAM
         #pragma surface surf CelShadingForward fullforwardshadows
         #pragma    target 3.0
         #include "AutoLight.cginc"
         #define UnityStandardBRDFCustom.cginc

         half4 LightingCelShadingForward(SurfaceOutput s, half3 lightDir, half atten)
     {
         half NdotL = dot(s.Normal, lightDir);
         if (NdotL <= 0.0) NdotL = 0.14f;
         else if (NdotL > 0.0f && NdotL <= 0.1f) NdotL = 0.15f;	
         else NdotL = 1;

         NdotL = smoothstep(0, 0.625f, NdotL);
         NdotL /= 2.5f;


         half4 c;
         c.rgb = s.Albedo * _LightColor0.rgb * (NdotL * atten  * 2); // THe *2 makes it brighter
         c.a = s.Alpha;
         return c;
     }



     sampler2D _MainTex;
     fixed4 _Color;
	 float4 _RimColor;
     float _RimPower;

     struct Input
     {
         fixed2 uv_MainTex;

     };

     void surf(Input IN, inout SurfaceOutput o) {
         // Albedo comes from a texture tinted by color
         fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
         o.Albedo = c.rgb;
         o.Alpha = c.a;
     }
     ENDCG
     } // End of Subshader
         FallBack "Diffuse"

 }