using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEditor.Rendering.Toon
{ 
    internal class UTS2ShaderInfo 
    {
    // Start is called before the first frame update

        static internal readonly UTS2INFO[] stdShaders =
        {
            new UTS2INFO(  "9baf30ce95c751649b14d96da3a4b4d5", "Toon_DoubleShadeWithFeather", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None, UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "96d4d9f975e6c8849bd1a5c06acfae84", "ToonColor_DoubleShadeWithFeather", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None, UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "ccd13b7f8710b264ea8bd3bc4f51f9e4", "ToonColor_DoubleShadeWithFeather_Clipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "9c3978743d5db18448a8b945c723a6eb", "ToonColor_DoubleShadeWithFeather_Clipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:false, RenderQueue.AlphaTestMinus1, UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "d7da29588857e774bb0650f1fae494c6", "ToonColor_DoubleShadeWithFeather_Clipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:false, RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "315897103223dab42a0746aa65ec251a", "ToonColor_DoubleShadeWithFeather_StencilMask",UTS2INFO.OPAQUE, transparency:false, RenderQueue.AlphaTestMinus1, UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "2e5cc2da6af713844956264245e092e4", "ToonColor_DoubleShadeWithFeather_StencilOut",UTS2INFO.OPAQUE, transparency:false, RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "369d674ae1ba36249bb00e2f73b0cd10", "ToonColor_DoubleShadeWithFeather_TransClipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:true, RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "8600b2bec3ae31145afa80084df20c61", "ToonColor_DoubleShadeWithFeather_TransClipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true, RenderQueue.AlphaTestMinus1, UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "43d0eeb4c46f52841b0941e99ac9b16b", "ToonColor_DoubleShadeWithFeather_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true, RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "97b7edb5fc0f5744c9b264c2224a0b1e", "ToonColor_DoubleShadeWithFeather_Transparent",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "3b20fc0febd34f94baf0304bf47841d8", "ToonColor_DoubleShadeWithFeather_Transparent_StencilOut",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "af8454e09b3a41448a4140e792059446", "ToonColor_ShadingGradeMap", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "295fec4a7029edd4eb9522bef07f41ce", "ToonColor_ShadingGradeMap_AngelRing", UTS2INFO.OPAQUE, transparency:false,RenderQueue.None, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "e32270aa38f4b664b90f04cc475fdb81", "ToonColor_ShadingGradeMap_AngelRing_StencilOut", UTS2INFO.OPAQUE, transparency:false, RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "29a860a3f3c4cec43ab821338e28eac8", "ToonColor_ShadingGradeMap_AngelRing_TransClipping",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "d5d9c1f4718235248ad37448b0c74c68", "ToonColor_ShadingGradeMap_AngelRing_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "6439813c08a1f8947bb0ca6599499dd7", "ToonColor_ShadingGradeMap_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1, UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "b39692f1382224b4cbe21c12ae51c639", "ToonColor_ShadingGradeMap_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "cd7e85b59edbb7740841003baeb510b5", "ToonColor_ShadingGradeMap_TransClipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "6b4b6d07944415f44b1fc2f0fc24535f", "ToonColor_ShadingGradeMap_TransClipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "31c75b34739dfc64fb57bf49005e942d", "ToonColor_ShadingGradeMap_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "7737ca8c4e3939f4086a6e08f93c2ebd", "ToonColor_ShadingGradeMap_Transparent",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "be27d4be45de7dd4ab2e69c992876edb", "ToonColor_ShadingGradeMap_Transparent_StencilOut",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "345def18d0906d544b7d12b050937392", "Toon_DoubleShadeWithFeather_Clipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "7a735f9b121d96349b6da0a077299424", "Toon_DoubleShadeWithFeather_Clipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "ed7fba947f3bccb4cbc78f55d7a56a70", "Toon_DoubleShadeWithFeather_Clipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.On),
//            new UTS2GUID(  "1d10c7840eb6ba74c889a27f14ba6081", "Toon_DoubleShadeWithFeather_Mobile"),
//            new UTS2GUID(  "88791c14394118d42a5e176b433af322", "Toon_DoubleShadeWithFeather_Mobile_Clipping"),
//            new UTS2GUID(  "41f4ee183cb66ad40bc74a9f8f944974", "Toon_DoubleShadeWithFeather_Mobile_Clipping_StencilMask"),
//            new UTS2GUID(  "dec01cbdbc5b8da4ca8671815cda1557", "Toon_DoubleShadeWithFeather_Mobile_StencilMask"),
//            new UTS2GUID(  "55e8b9eeaaff205469365133fe7bc744", "Toon_DoubleShadeWithFeather_Mobile_StencilOut"),
//            new UTS2GUID(  "d4c592285a93c3844aafdaafffc07ec7", "Toon_DoubleShadeWithFeather_Mobile_TransClipping"),
//            new UTS2GUID(  "100d373b596f44d49ac9bb944d671d32", "Toon_DoubleShadeWithFeather_Mobile_TransClipping_StencilMask"),
            new UTS2INFO(  "036bc90bfe3475b4c9fadb85d0520621", "Toon_DoubleShadeWithFeather_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "0a1e4c9dcc0e9ea4db38ae9cb5059608", "Toon_DoubleShadeWithFeather_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "e8e7d781c3155254b9ea8956c5bd1218", "Toon_DoubleShadeWithFeather_TransClipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "79add09e32e5c4541980118f6c4045b6", "Toon_DoubleShadeWithFeather_TransClipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "fb47be5a840097b45bac228446468ef3", "Toon_DoubleShadeWithFeather_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
//            new UTS2INFO(  "42a47eda2ed77084c9136507eadb8641", "Toon_OutlineObject", UTS2INFO.OPAQUE, transparency:false),
//            new UTS2INFO(  "2e2edd12fbf6bcb4ea1f34c17ee42df5", "Toon_OutlineObject_StencilOut", UTS2INFO.OPAQUE, transparency:false),
            new UTS2INFO(  "ca035891872022e4f80c952b3916e450", "Toon_ShadingGradeMap", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "9aadc53d7cdc63f4898ea042aa9d853b", "Toon_ShadingGradeMap_AngelRing", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.Off),
//            new UTSINFO(  "23e399973d807464fb195291a44a614c", "Toon_ShadingGradeMap_AngelRing_Mobile"),
//            new UTSINFO(  "8d33e4e4084e5af449f3e762fecce3c9", "Toon_ShadingGradeMap_AngelRing_Mobile_StencilOut"),
            new UTS2INFO(  "415f07ab6fd766048ac6f8c2f2b406a9", "Toon_ShadingGradeMap_AngelRing_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "b2a70923168ea0c40a3051a013c93a8a", "Toon_ShadingGradeMap_AngelRing_TransClipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "d1e11a558d143f14c864edf263332764", "Toon_ShadingGradeMap_AngelRing_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.On),
//            new UTSINFO(  "f90e11a40dcf4f745ae6b21b857943fa", "Toon_ShadingGradeMap_Mobile"),
//            new UTSINFO(  "206c554c8b0c60041a9d242385f543d3", "Toon_ShadingGradeMap_Mobile_StencilMask"),
//            new UTSINFO(  "cfc201757f2519c4bb6ef9265a046582", "Toon_ShadingGradeMap_Mobile_StencilOut"),
//            new UTSINFO(  "cce1da34c52aff745adf0222f56a356c", "Toon_ShadingGradeMap_Mobile_TransClipping"),
//            new UTSINFO(  "e88039bab21b7894e918126e8fce5d1b", "Toon_ShadingGradeMap_Mobile_TransClipping_StencilMask"),
            new UTS2INFO(  "aa2e05ed58ca15441bd0989f008da78b", "Toon_ShadingGradeMap_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1, UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "923058fda1b61544b93d91eeee772086", "Toon_ShadingGradeMap_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest, UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "aebd33b74ef849a4882b4a8d55f0f0c9", "Toon_ShadingGradeMap_TransClipping",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "0a05dd221bacbb448afac3d63e6bd833", "Toon_ShadingGradeMap_TransClipping_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "67212ac11ff43b04a833d3986b997a9f", "Toon_ShadingGradeMap_TransClipping_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.On),

        };
        static internal readonly UTS2INFO[] tessShaders =
        {
            new UTS2INFO(  "5b8a1502578ed764c9880a7be65c9672", "ToonColor_DoubleShadeWithFeather_Clipping_Tess",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "682e6e6cf60a51040ade19437a3f53e2", "ToonColor_DoubleShadeWithFeather_Clipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "148d1eca2cf299e4eb949d15c4cf95ee", "ToonColor_DoubleShadeWithFeather_Clipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "e987cf9cca0941042aa68d1dd51ee20f", "ToonColor_DoubleShadeWithFeather_Tess", UTS2INFO.OPAQUE, transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "97df86a7afe06ef41b2a2c242b10593e", "ToonColor_DoubleShadeWithFeather_Tess_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "b179fb8a87955a347b5f594a18b43475", "ToonColor_DoubleShadeWithFeather_Tess_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "60fe384b76fb67d40bc7e38411073dd6", "ToonColor_DoubleShadeWithFeather_TransClipping_Tess",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "4a20b66d106d3f5409f759b5193ecdc2", "ToonColor_DoubleShadeWithFeather_TransClipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "a7842aa9522c7584cae2169b8e1ddb86", "ToonColor_DoubleShadeWithFeather_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "0cb6c9e6216a91e4a9d38cd2acb4ccb6", "ToonColor_DoubleShadeWithFeather_Transparent_Tess",UTS2INFO.TRANSPARENT, transparency:true, RenderQueue.Transparent,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "f28bba8b2f259bb40b697d91849c8794", "ToonColor_DoubleShadeWithFeather_Transparent_Tess_StencilOut",UTS2INFO.TRANSPARENT, transparency:true, RenderQueue.Transparent,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "4876871966ca2344793e439d7391d7b0", "ToonColor_ShadingGradeMap_AngelRing_Tess", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "7c48bdc9fed28c14b8ad0748673b1369", "ToonColor_ShadingGradeMap_AngelRing_Tess_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "d3fb22770ec830b43bdb5ccb973e6f76", "ToonColor_ShadingGradeMap_AngelRing_Tess_TransClipping",UTS2INFO.TRANSPARENT, transparency:true,RenderQueue.Transparent,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "11e8f1e181e558a47a387492d3ecdb88", "ToonColor_ShadingGradeMap_AngelRing_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "01494e58d87212f44ab51d29caea84e4", "ToonColor_ShadingGradeMap_Tess", UTS2INFO.OPAQUE, transparency:false, RenderQueue.None,UTS3GUI.UTS_StencilMode.Off,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "24c20b8ed5be113499b40f4e3b6b03e6", "ToonColor_ShadingGradeMap_Tess_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "9cf7e8eb46e9128438d50adf7a841de6", "ToonColor_ShadingGradeMap_Tess_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "3c39a77fda28b5043a7a17c7877cf7b2", "ToonColor_ShadingGradeMap_TransClipping_Tess",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "bf840a439c33c8b4a99d52e6c3d8511f", "ToonColor_ShadingGradeMap_TransClipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "8eff803eae89c994fae3acf2f686fafa", "ToonColor_ShadingGradeMap_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "0959cb8822a344c4da890457e668fdc9", "ToonColor_ShadingGradeMap_Transparent_Tess",UTS2INFO.TRANSPARENT, transparency:true, RenderQueue.Transparent,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "6d115cf94d14d1842a56dfff76b57f42", "ToonColor_ShadingGradeMap_Transparent_Tess_StencilOut",UTS2INFO.TRANSPARENT, transparency:true, RenderQueue.Transparent,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "f0b2fc9b8a189134da9c7d24f361caf4", "Toon_DoubleShadeWithFeather_Clipping_Tess",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "8c94ee3046ef0574f87f6b658b4e4691", "Toon_DoubleShadeWithFeather_Clipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "c4aed8662ca0f194284f3ab649e66d23", "Toon_DoubleShadeWithFeather_Clipping_Tess_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_ClippingMode.On),
            new UTS2INFO(  "1f248db3b28fc5f44aabd7aca618bd1e", "Toon_DoubleShadeWithFeather_Tess", UTS2INFO.OPAQUE, transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "a3214384442742648aa664ef0039d397", "Toon_DoubleShadeWithFeather_Tess_Light", UTS2INFO.OPAQUE, transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "3073cd2564e4cde45a19c05e0012d22a", "Toon_DoubleShadeWithFeather_Tess_Light_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "7e7690a767a07da4f943439680e70db8", "Toon_DoubleShadeWithFeather_Tess_Light_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "08c65988dc25d9f44b791fcc18fb543a", "Toon_DoubleShadeWithFeather_Tess_StencilMask", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "f937ea4ce96dfbe448afc0fb671198e5", "Toon_DoubleShadeWithFeather_Tess_StencilOut", UTS2INFO.OPAQUE, transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_ClippingMode.Off),
            new UTS2INFO(  "3fb99ac3775edeb4aa9530db5a614c92", "Toon_DoubleShadeWithFeather_TransClipping_Tess",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "9855f226cd8152d4e99085272aceede6", "Toon_DoubleShadeWithFeather_TransClipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            new UTS2INFO(  "2a0d4af863770404faee6488b86fe3c9", "Toon_DoubleShadeWithFeather_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT, transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_ClippingMode.TransClippingMode),
            // new UTS2INFO(  "1847c44f729b68e49ba63610abdf9132", "Toon_OutlineObject_Tess", UTS2INFO.OPAQUE),
            // new UTS2INFO(  "06cae78b869a3234bab02eeb52197e1c", "Toon_OutlineObject_Tess_StencilOut", UTS2INFO.OPAQUE),
            new UTS2INFO(  "3a1af221400a61a4b94bae19aa79da2b", "Toon_ShadingGradeMap_AngelRing_Tess", UTS2INFO.OPAQUE,transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "a1449ab672051624ca3160737b630f5e", "Toon_ShadingGradeMap_AngelRing_Tess_Light", UTS2INFO.OPAQUE,transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "79d3dc54c32b69b42be17c48d33575f2", "Toon_ShadingGradeMap_AngelRing_Tess_Light_StencilOut", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut,(int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "18c9172cdf36a344f9aca9bbc0e7002d", "Toon_ShadingGradeMap_AngelRing_Tess_StencilOut", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "54a94f776a43a074c8c2d205bb934005", "Toon_ShadingGradeMap_AngelRing_TransClipping_Tess",UTS2INFO.TRANSPARENTCUTOUT,transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "d496a1c70c797ad43836d5bfff575b5f", "Toon_ShadingGradeMap_AngelRing_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT,transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "183ea557143786346b1bfc862ad22636", "Toon_ShadingGradeMap_Tess", UTS2INFO.OPAQUE,transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "356dd5af8f0d40e41b647d3d0a0555c1", "Toon_ShadingGradeMap_Tess_Light", UTS2INFO.OPAQUE,transparency:false,RenderQueue.None,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "ffadecfbd9e31f840ba4109fea0f0436", "Toon_ShadingGradeMap_Tess_Light_StencilMask", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "98ac5d198a471494da681b7b8d1e1727", "Toon_ShadingGradeMap_Tess_Light_StencilOut", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "0d799eb857c0e2c45bbdfb2c033d33e6", "Toon_ShadingGradeMap_Tess_StencilMask", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "e667137c8b6fd3d4390fc364b2e5c70b", "Toon_ShadingGradeMap_Tess_StencilOut", UTS2INFO.OPAQUE,transparency:false,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.Off),
            new UTS2INFO(  "feba437d8ff93f745a78828529e9a272", "Toon_ShadingGradeMap_TransClipping_Tess",UTS2INFO.TRANSPARENTCUTOUT,transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.Off, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "8d1395a9f4bfad44d8fddd0f2af19b1e", "Toon_ShadingGradeMap_TransClipping_Tess_StencilMask",UTS2INFO.TRANSPARENTCUTOUT,transparency:true,RenderQueue.AlphaTestMinus1,UTS3GUI.UTS_StencilMode.StencilOut, (int)UTS3GUI.UTS_TransClippingMode.On),
            new UTS2INFO(  "08c6bb334aed21c4198cf46b71ebca2d", "Toon_ShadingGradeMap_TransClipping_Tess_StencilOut",UTS2INFO.TRANSPARENTCUTOUT,transparency:true,RenderQueue.AlphaTest,UTS3GUI.UTS_StencilMode.StencilMask, (int)UTS3GUI.UTS_TransClippingMode.On),

        };
    }
}