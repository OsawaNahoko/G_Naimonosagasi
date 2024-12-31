Shader "Custom/sen_Shade"
{

    //プロパティセクション
    Properties
    {
        //カスタムプロパティ”_Color”の宣言 "_Color"プロパティはシェーダーのカラーを指定します。
        _Color ("Color", Color) = (1,1,1,1)

        //カスタムプロパティ”_Strength”の宣言"_Strength"プロパティはシェーダーの強度を指定します。範囲は０から１です。
        _Strength("Strength", Range(0,1)) = 0.4

        //カスタムプロパティ"_Outlinewidth"の宣言
        _Outlinewidth("Outline widh" , Range(0.0001,0.03)) = 0.0005

        //カスタムプロパティ"_OutlieColor"の宣言
        _OutlineColor("Outline Color", Color) = (0,0,0,1)

        //カスタムプロパティ”_UseVertexExpansion"の宣言
        [Toggle(USE_VERTEX_EXPANSION)] _UseVertexExpansion("Use vertex for Outline", int) = 0
    }
    SubShader
    {  
        //"Germio/ColorShade/CLKLR_SHADE"パスを使用
        UsePass "Germio/ColorShade/COLOR_SHADE"

        //タグの設定：レンダーキューを透明に設定　レンダリングキューを透明に設定し、描画の順序を制御します。
        Tags { "Queue"="Transparent" }

        //ブレンドモードの設定：アルファブレンド　アルファブレンドを使用して透明なオブジェクトをレンダリングします。
        Blend SrcAlpha OneminusSrcAlpha

        //シェーダーのパスを定義
        Pass
        {
            //パスの名前
            Name "COLOR_SHADE"

            //カリングをフロントに設定
            Cull Front

            //プログラマブルなシェーダーの開始宣言
            CGPROGRAM

            // //頂点シェーダーの指定
            #pragma vertex vert

            // //フラグメントシェーダ―の指定
            #pragma fragment frag

            //"USE_VERTEX_EXPANSION"シェーダーフィーチャーを有効化
            #pragma shader_feature USE_VERTEX_EXPANSION

            //UnityCG.cgin ライラブリをインクルード
            #include "UnityCG.cginc"


            //プロパティで定義されたアウトラインの幅を定義する変数
            float _Outlinewidth;

            //プロパティで定義されたアウトラインのカラーを定義する変数
            float4 _OutlineColor;


            //頂点情報を格納する構造体の宣言
            struct appdata
            {
                float4 vertex : POSITION;//頂点の座標情報
                float3 normal : NORMAL;  //頂点の法線情報
            };

            //頂点シェーダーからフラグメントシェーダーにデータを渡す構造体の宣言
            struct v2f
            {
                float4 pos : SV_POSITION; //頂点のスクリーン座標
            };

            //頂点シェーダー関数の宣言
            v2f vert(appdata v)
            {
               v2f o;
               o.pos = UnityObjectToClipPos(v.vertex); //頂点位置をクリップ座標に変換
               float3 n = 0;                           //法線ベクトル初期化

               //USE_VERTEX_EXPANSION フィーチャーが有効な場合、頂点を拡張法線を使用して計算
               #ifdef USE_VERTEX_EXPANSION

               //頂点の位置から方向ベクトルを計算
               float3 dir = normalize(v.vertex.xyz);

               //拡張法線をワールド空間に変換
               n = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, dir));

               //USE_VERTEX_EXPANSION　フィーチャーが無効な場合、通常の法線を使用して計算
               #else

               //法線ベクトルをワールド空間に変換
               n = normalize(mul((float3x3)UNITY_MATRIX_IT_MV,v.normal));

               #endif

               //法線情報とビューからプロジェクション座標に変換
               float2 offset = TransformViewToProjection(n.xy);

               //座標にアウトラインのオフセットを追加
               o.pos.xy += offsest * _Outlinewidth;

                return o;
            }

            //プロパティで定義されたカラー情報を格納する変数
            float4 _Color;

            //フラグメントシェーダー関数の宣言
            fixed4 frag(v2f i) : SV_Target
            {
                //最終的なカラーをアウトラインカラーで初期化
                float4 final_color = _OutlineColor;

                //アルファ値をカスタムプロパティのアルファ値に設定
                final_color.a = _Color.a;

                //最終出力カラーを返す
                return final_color;
            }

            //プログラマブルなシェーダーの終了宣言
            ENDCG
        }
      
    }
    
    //フォールバック
    FallBack "Standard"
}
