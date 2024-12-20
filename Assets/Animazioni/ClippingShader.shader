Shader "Custom/ClippingShader"
{
   Properties
   {
       _MainTex ("Texture", 2D) = "white" {}
       _ClipPlane ("Clip Plane", Vector) = (0, 1, 0, 0) // Definisce un piano iniziale
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
           sampler2D _MainTex;
           float4 _ClipPlane; // Il piano di taglio
           struct appdata
           {
               float4 vertex : POSITION;
               float2 uv : TEXCOORD0;
           };
           struct v2f
           {
               float2 uv : TEXCOORD0;
               float4 pos : SV_POSITION;
               float4 worldPos : TEXCOORD1;
           };
           v2f vert (appdata v)
           {
               v2f o;
               o.pos = UnityObjectToClipPos(v.vertex);
               o.uv = v.uv;
               o.worldPos = mul(unity_ObjectToWorld, v.vertex);
               return o;
           }
           fixed4 frag (v2f i) : SV_Target
           {
               // Applica il piano di taglio
               if (dot(i.worldPos, _ClipPlane) < 0)
               {
                   discard; // Elimina i pixel che sono dietro al piano
               }
               fixed4 col = tex2D(_MainTex, i.uv);
               return col;
           }
           ENDCG
       }
   }
}
