Shader "Custom/Color_Shade"
{
    //プロパティセクション
    Properties
    {
        //カスタムプロパティ”_Color”の宣言 "_Color"プロパティはシェーダーのカラーを指定します。
        _Color ("Color", Color) = (1,1,1,1)
        //カスタムプロパティ”_Strength”の宣言"_Strength"プロパティはシェーダーの強度を指定します。範囲は０から１です。
        _Strength("Strength", Range(0,1)) = 0.4

        // _MainTex ("Albedo (RGB)", 2D) = "white" {}
        // _Glossiness ("Smoothness", Range(0,1)) = 0.5
        // _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {  
        //タグの設定：レンダーキューを透明に設定　レンダリングキューを透明に設定し、描画の順序を制御します。
        Tags { "Queue"="Transparent" }

        //ブレンドモードの設定：アルファブレンド　アルファブレンドを使用して透明なオブジェクトをレンダリングします。
        Blend SrcAlpha OneminusSrcAlpha

        //シェーダーのパスを定義
        Pass
        {
            //パスの名前
            Name "COLOR_SHADE"

            //プログラマブルなシェーダーの開始宣言
            CGPROGRAM

            // //頂点シェーダーの指定
            #pragma vertex vert

            // //フラグメントシェーダ―の指定
            #pragma fragment frag

            //UnityCG.cgin ライラブリをインクルード
            #include "UnityCG.cginc"

            //プロパティで定義されたシェーダーの強度を定義する変数
            float _Strength;

            //頂点情報を格納する構造体の宣言
            struct appdata
            {
                float4 vertex : POSITION;//頂点の座標情報
                float3 normal : NORMAL;  //頂点の法線情報
            };

            //頂点シェーダーからフラグメントシェーダーにデータを渡す構造体の宣言
            struct v2f
            {
                float4 pos : SV_POSITION;      //頂点のスクリーン座標
                float3 worldNormal : TEXCOORD0;//ワールド空間の法線情報
            };

            //頂点シェーダー関数の宣言
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);            //頂点位置をクリップ座標に変換
                o.worldNormal = UnityObjectToWorldNormal(v.normal);//法線情報をワールド空間に変換
                return o;
            }

            //プロパティで定義されたカラー情報を格納する変数
            float4 _Color;

            //フラグメントシェーダー関数の宣言
            fixed4 frag(v2f i) : SV_Target
            {
                float3 l = normalize(_WorldSpaceLightPos0.xyz);//ライトの方向ベクトルを計算
                float3 n = normalize(i.worldNormal);           //法線ベクトルを計算
                float interpolation = step(dot(n, 1), 0);      //ライトと法線ベクトルの内積を取得し、補間値を計算
                float4 final_Color = lerp(_Color,(1 - _Strength) * _Color, interpolation);//最終的なカラーを計算
                final_Color.a = _Color.a; //アルファ値をカスタムプロパティのアルファ値に設定
                return final_Color; //最終出力カラーを返す
            }

            //プログラマブルなシェーダーの終了宣言
            ENDCG
        }
      
    }
    
    FallBack "Standard"
}
