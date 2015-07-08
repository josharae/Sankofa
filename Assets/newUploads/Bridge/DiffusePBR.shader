// Shader created with Shader Forge v1.02 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.02;sub:START;pass:START;ps:flbk:Legacy Shaders/Diffuse Fast,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:1,culm:0,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1426,x:33368,y:32667,varname:node_1426,prsc:2|diff-110-OUT,spec-1084-OUT,gloss-9274-OUT,normal-5965-RGB,amdfl-9812-OUT,amspl-4090-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:8406,x:30370,y:32032,ptovrint:False,ptlb:DiffuseMap Gloss,ptin:_DiffuseMapGloss,varname:node_8406,tex:5cdbea938a53c8d48ae8270b07cc534e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:3868,x:30602,y:32012,varname:node_3868,prsc:2,tex:5cdbea938a53c8d48ae8270b07cc534e,ntxv:0,isnm:False|TEX-8406-TEX;n:type:ShaderForge.SFN_Multiply,id:3958,x:31166,y:32150,varname:node_3958,prsc:2|A-8212-OUT,B-2829-RGB;n:type:ShaderForge.SFN_Color,id:2829,x:30794,y:32425,ptovrint:False,ptlb:DiffuseColor,ptin:_DiffuseColor,varname:node_2829,prsc:2,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:1762,x:31014,y:32443,ptovrint:False,ptlb:Diffuse Fresnel,ptin:_DiffuseFresnel,varname:node_1762,prsc:2,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Fresnel,id:4687,x:31316,y:32320,varname:node_4687,prsc:2|EXP-1762-OUT;n:type:ShaderForge.SFN_Multiply,id:3251,x:31585,y:32229,varname:node_3251,prsc:2|A-3958-OUT,B-4687-OUT;n:type:ShaderForge.SFN_Multiply,id:9933,x:31829,y:32296,varname:node_9933,prsc:2|A-3251-OUT,B-7574-OUT;n:type:ShaderForge.SFN_Multiply,id:7574,x:31606,y:32432,varname:node_7574,prsc:2|A-4687-OUT,B-7061-OUT;n:type:ShaderForge.SFN_Vector1,id:7061,x:31378,y:32544,varname:node_7061,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:110,x:32037,y:32157,varname:node_110,prsc:2|A-3958-OUT,B-9933-OUT;n:type:ShaderForge.SFN_Color,id:4094,x:30356,y:32775,ptovrint:False,ptlb:Specular Gloss,ptin:_SpecularGloss,varname:node_4094,prsc:2,glob:False,c1:0.375,c2:0.375,c3:0.375,c4:1;n:type:ShaderForge.SFN_Multiply,id:4141,x:30890,y:32745,varname:node_4141,prsc:2|A-4094-RGB,B-4245-OUT;n:type:ShaderForge.SFN_Multiply,id:1084,x:31659,y:32682,varname:node_1084,prsc:2|A-4141-OUT,B-9190-OUT;n:type:ShaderForge.SFN_Multiply,id:3739,x:30928,y:33031,varname:node_3739,prsc:2|A-4094-RGB,B-4245-OUT;n:type:ShaderForge.SFN_Vector1,id:4245,x:30601,y:33117,varname:node_4245,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:7403,x:31068,y:32891,varname:node_7403,prsc:2|A-4094-A,B-605-OUT;n:type:ShaderForge.SFN_Vector1,id:605,x:30890,y:32957,varname:node_605,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:6355,x:31282,y:32872,varname:node_6355,prsc:2|A-3868-A,B-7403-OUT;n:type:ShaderForge.SFN_Multiply,id:7841,x:31282,y:33012,varname:node_7841,prsc:2|A-3868-A,B-4094-A;n:type:ShaderForge.SFN_Fresnel,id:9190,x:31437,y:32735,varname:node_9190,prsc:2|EXP-7148-OUT;n:type:ShaderForge.SFN_Slider,id:7148,x:31113,y:32793,ptovrint:False,ptlb:Specular Fresnel,ptin:_SpecularFresnel,varname:node_7148,prsc:2,min:-0.1,cur:0,max:3;n:type:ShaderForge.SFN_Multiply,id:9274,x:31672,y:32846,varname:node_9274,prsc:2|A-9190-OUT,B-6355-OUT;n:type:ShaderForge.SFN_Lerp,id:9812,x:32386,y:33323,varname:node_9812,prsc:2|A-7018-RGB,B-3670-OUT,T-4234-OUT;n:type:ShaderForge.SFN_AmbientLight,id:7018,x:32128,y:33207,varname:node_7018,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3670,x:32128,y:33372,varname:node_3670,prsc:2|A-7886-OUT,B-1749-OUT;n:type:ShaderForge.SFN_Slider,id:7886,x:31801,y:33356,ptovrint:False,ptlb:IBL Strength,ptin:_IBLStrength,varname:node_7886,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:4234,x:32012,y:33545,ptovrint:False,ptlb:Ambient VS IBL,ptin:_AmbientVSIBL,varname:node_7886,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Add,id:1749,x:31822,y:33478,varname:node_1749,prsc:2|A-6176-OUT,B-40-OUT;n:type:ShaderForge.SFN_Multiply,id:6176,x:31566,y:33383,varname:node_6176,prsc:2|A-7574-OUT,B-9858-OUT;n:type:ShaderForge.SFN_Multiply,id:9858,x:31325,y:33394,varname:node_9858,prsc:2|A-4687-OUT,B-40-OUT;n:type:ShaderForge.SFN_Multiply,id:40,x:31132,y:33529,varname:node_40,prsc:2|A-1649-RGB,B-3047-OUT;n:type:ShaderForge.SFN_Cubemap,id:1649,x:30720,y:33460,ptovrint:False,ptlb:DiffuseIBL,ptin:_DiffuseIBL,varname:node_1649,prsc:2|DIR-8768-OUT;n:type:ShaderForge.SFN_Multiply,id:3047,x:30912,y:33651,varname:node_3047,prsc:2|A-1649-A,B-6398-OUT;n:type:ShaderForge.SFN_Vector1,id:6398,x:30747,y:33744,varname:node_6398,prsc:2,v1:5;n:type:ShaderForge.SFN_NormalVector,id:8768,x:30451,y:33515,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:4090,x:32895,y:33642,varname:node_4090,prsc:2|A-9190-OUT,B-1848-OUT;n:type:ShaderForge.SFN_Multiply,id:1848,x:32667,y:33659,varname:node_1848,prsc:2|A-3739-OUT,B-7868-OUT;n:type:ShaderForge.SFN_Vector1,id:1510,x:31079,y:33895,varname:node_1510,prsc:2,v1:8;n:type:ShaderForge.SFN_Multiply,id:1669,x:31337,y:33804,varname:node_1669,prsc:2|A-7841-OUT,B-1510-OUT;n:type:ShaderForge.SFN_OneMinus,id:1092,x:31558,y:33804,varname:node_1092,prsc:2|IN-1669-OUT;n:type:ShaderForge.SFN_Multiply,id:8002,x:31778,y:33852,varname:node_8002,prsc:2|A-1092-OUT,B-1510-OUT;n:type:ShaderForge.SFN_Cubemap,id:7653,x:32012,y:33745,ptovrint:False,ptlb:SpecularIBL,ptin:_SpecularIBL,varname:node_7653,prsc:2|DIR-5306-OUT,MIP-8002-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:5306,x:31708,y:33696,varname:node_5306,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9582,x:32273,y:33819,varname:node_9582,prsc:2|A-7653-A,B-6812-OUT;n:type:ShaderForge.SFN_Vector1,id:6812,x:32031,y:33967,varname:node_6812,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:7868,x:32460,y:33769,varname:node_7868,prsc:2|A-7653-RGB,B-9582-OUT;n:type:ShaderForge.SFN_Lerp,id:403,x:30490,y:32291,varname:node_403,prsc:2|A-6753-OUT,B-3964-RGB,T-8859-OUT;n:type:ShaderForge.SFN_Slider,id:8859,x:30004,y:32387,ptovrint:False,ptlb:AO Intensity,ptin:_AOIntensity,varname:node_8859,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:8212,x:30938,y:32069,varname:node_8212,prsc:2|A-3868-RGB,B-403-OUT;n:type:ShaderForge.SFN_Vector3,id:6753,x:30122,y:32109,varname:node_6753,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Tex2d,id:3964,x:29925,y:32156,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_3964,prsc:2,tex:6135ca838faca1e4fb7b2bf8ad13565c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5965,x:32871,y:32531,ptovrint:False,ptlb:NormaMap,ptin:_NormaMap,varname:node_5965,prsc:2,tex:e66a6565d686f7a4eb05a0bcbf10f47b,ntxv:3,isnm:True;proporder:8406-2829-1762-4094-7148-7886-4234-1649-7653-8859-3964-5965;pass:END;sub:END;*/

Shader "Raja/DiffusePBR" {
    Properties {
        _DiffuseMapGloss ("DiffuseMap Gloss", 2D) = "white" {}
        _DiffuseColor ("DiffuseColor", Color) = (1,1,1,1)
        _DiffuseFresnel ("Diffuse Fresnel", Range(0, 5)) = 0
        _SpecularGloss ("Specular Gloss", Color) = (0.375,0.375,0.375,1)
        _SpecularFresnel ("Specular Fresnel", Range(-0.1, 3)) = 0
        _IBLStrength ("IBL Strength", Range(0, 1)) = 0
        _AmbientVSIBL ("Ambient VS IBL", Range(0, 1)) = 0
        _DiffuseIBL ("DiffuseIBL", Cube) = "_Skybox" {}
        _SpecularIBL ("SpecularIBL", Cube) = "_Skybox" {}
        _AOIntensity ("AO Intensity", Range(0, 1)) = 1
        _AO ("AO", 2D) = "white" {}
        _NormaMap ("NormaMap", 2D) = "bump" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _DiffuseMapGloss; uniform float4 _DiffuseMapGloss_ST;
            uniform float4 _DiffuseColor;
            uniform float _DiffuseFresnel;
            uniform float4 _SpecularGloss;
            uniform float _SpecularFresnel;
            uniform float _IBLStrength;
            uniform float _AmbientVSIBL;
            uniform samplerCUBE _DiffuseIBL;
            uniform samplerCUBE _SpecularIBL;
            uniform float _AOIntensity;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _NormaMap; uniform float4 _NormaMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormaMap_var = UnpackNormal(tex2D(_NormaMap,TRANSFORM_TEX(i.uv0, _NormaMap)));
                float3 normalLocal = _NormaMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_9190 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_SpecularFresnel);
                float4 node_3868 = tex2D(_DiffuseMapGloss,TRANSFORM_TEX(i.uv0, _DiffuseMapGloss));
                float gloss = (node_9190*(node_3868.a*(_SpecularGloss.a*1.5)));
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4245 = 0.5;
                float node_1510 = 8.0;
                float4 _SpecularIBL_var = texCUBElod(_SpecularIBL,float4(viewReflectDirection,((1.0 - ((node_3868.a*_SpecularGloss.a)*node_1510))*node_1510)));
                float3 specularColor = ((_SpecularGloss.rgb*node_4245)*node_9190);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 indirectSpecular = (0 + (node_9190*((_SpecularGloss.rgb*node_4245)*(_SpecularIBL_var.rgb*(_SpecularIBL_var.a*5.0)))));
                float3 specular = (directSpecular + indirectSpecular) * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_4687 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_DiffuseFresnel);
                float node_7574 = (node_4687*0.1);
                float4 _DiffuseIBL_var = texCUBE(_DiffuseIBL,normalDirection);
                float3 node_40 = (_DiffuseIBL_var.rgb*(_DiffuseIBL_var.a*5.0));
                indirectDiffuse += lerp(UNITY_LIGHTMODEL_AMBIENT.rgb,(_IBLStrength*((node_7574*(node_4687*node_40))+node_40)),_AmbientVSIBL); // Diffuse Ambient Light
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float3 node_3958 = ((node_3868.rgb*lerp(float3(1,1,1),_AO_var.rgb,_AOIntensity))*_DiffuseColor.rgb);
                float3 diffuse = (directDiffuse + indirectDiffuse) * (node_3958+((node_3958*node_4687)*node_7574));
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _LightColor0;
            uniform sampler2D _DiffuseMapGloss; uniform float4 _DiffuseMapGloss_ST;
            uniform float4 _DiffuseColor;
            uniform float _DiffuseFresnel;
            uniform float4 _SpecularGloss;
            uniform float _SpecularFresnel;
            uniform float _AOIntensity;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _NormaMap; uniform float4 _NormaMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(_Object2World, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormaMap_var = UnpackNormal(tex2D(_NormaMap,TRANSFORM_TEX(i.uv0, _NormaMap)));
                float3 normalLocal = _NormaMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_9190 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_SpecularFresnel);
                float4 node_3868 = tex2D(_DiffuseMapGloss,TRANSFORM_TEX(i.uv0, _DiffuseMapGloss));
                float gloss = (node_9190*(node_3868.a*(_SpecularGloss.a*1.5)));
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4245 = 0.5;
                float3 specularColor = ((_SpecularGloss.rgb*node_4245)*node_9190);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float3 node_3958 = ((node_3868.rgb*lerp(float3(1,1,1),_AO_var.rgb,_AOIntensity))*_DiffuseColor.rgb);
                float node_4687 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_DiffuseFresnel);
                float node_7574 = (node_4687*0.1);
                float3 diffuse = directDiffuse * (node_3958+((node_3958*node_4687)*node_7574));
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Legacy Shaders/Diffuse Fast"
    CustomEditor "ShaderForgeMaterialInspector"
}
