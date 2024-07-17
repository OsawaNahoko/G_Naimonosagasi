Shader "Custom/Germio_Color"
{
    //プロパティセクション
    //マテリアルの外部から調整可能なパラメータを定義します。
    Properties
    {
        //カスタムプロパティ”_Color”の宣言
        _Color ("Color", Color) = (1,1,1,1)

        //カスタムプロパティ　”_Strength”の宣言
        _Strength("Strength",Range(0,1)) = 0.4
    }

    //サブシェーダーセクション
    //此処にシェーダーの実際の描画ロジックを記述します。
    SubShader
    {
        //タグの設定：レンダリングキューを透明に設定
        Tags { "Opaque"="Transparent" }
        //ブレンドモードの設定：アルファブレンド
        Blend SrcAlpha OneminusSrcAlpha

        //シェーダーのパスを定義
        Pass
        {
            //パスの名前
            Name "COLOR"

            //プログラマブルなシェーダーの開始宣言
            CGPROGRAM

            //頂点シェーダーの指定
            #pragma vertex vert

            //フラグメントシェーダ―の指定
            #pragma fragment frag

            //頂点情報を格納する構造体の宣言
            struct appdata
            {
                //頂点の座標情報
                float4 vertex : POSITION;
            };

            //頂点シェーダーからフラグメントシェーダ―にデータを渡す構造体の宣言
            struct v2f
            {
                //頂点のスクリーン座標
                float4 pos : SV_POSITION;
            };

            //頂点シェーダー関数の宣言
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);//頂点位置をクリップ座標に変換
                return o;
            }
            
            //プロパティで定義されたカラー情報を格納する変数
            float4 _Color;

            //フラグメントシェーダ―関数の宣言
            fixed4 frag(v2f i) : SV_Target
            {
                float4 final_color = _Color;//シェーダ―の最終出力カラーを定義
                final_color.a = _Color.a;//アルファ値をカスタムプロパティのアルファ値に設定
                return final_color;//最終出力カラーを返す
            }
            //プログラマブルなシェーダーの終了宣言
            ENDCG
        }
    }

    //フォールバック
    //このシェーダーが使用できない場合
    //デフォルトの”Diffuse”シェーダーを使用します。
    FallBack "Diffuse"
}
