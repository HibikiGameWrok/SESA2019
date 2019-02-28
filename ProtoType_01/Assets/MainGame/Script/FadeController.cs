using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public ChangeScene m_changeScene;　// シーン切り替えスクリプト // 

    private float m_fadeSpeed = 0.02f;              // 透明度が変わるスピードを管理 //
    private float m_red, m_green, m_blue, m_alfa;   // パネルの色、不透明度を管理 //

    public bool m_isFadeOut = false;   // フェードアウト処理の開始、完了を管理するフラグ //
    public bool m_isFadeIn = false;    // フェードイン処理の開始、完了を管理するフラグ //

    private Image m_fadeImage;         // 透明度を変更するパネルのイメージ //

    // Start is called before the first frame update
    void Start()
    {
        /* 初期化 */
        m_fadeImage = GetComponent<Image>(); // コンポーネントを取得
        m_red = m_fadeImage.color.r;         // 赤の値
        m_green = m_fadeImage.color.g;       // 緑の値
        m_blue = m_fadeImage.color.b;        // 青の値
        m_alfa = m_fadeImage.color.a;        // 透明度
    }

    // Update is called once per frame
    void Update()
    {
        // シーンが切り替わる時
        if(m_changeScene.m_changeFlag == true)
        {
            m_isFadeOut = true;
        }

        // フェードインフラグがtrueの時
        if (m_isFadeIn)
        {
            StartFadeIn(); // フェードインを開始する
        }

        // フェードアウトフラグがtrueの時
        if (m_isFadeOut)
        {
            StartFadeOut(); // フェードアウトを開始する
        }
    }

    // フェードインを開始する
    void StartFadeIn()
    {
        m_alfa -= m_fadeSpeed;           //1)不透明度を徐々に下げる
        SetAlpha();                  //2)変更した不透明度パネルに反映する
        if (m_alfa <= 0)
        {              //3)完全に透明になったら処理を抜ける
            m_isFadeIn = false;
            m_fadeImage.enabled = false;    //4)パネルの表示をオフにする
        }
    }

    // フェードアウトを開始する
    void StartFadeOut()
    {
        m_fadeImage.enabled = true;  // 1)パネルの表示をオンにする
        m_alfa += m_fadeSpeed;       // 2)不透明度を徐々にあげる
        SetAlpha();                  // 3)変更した透明度をパネルに反映する
        if (m_alfa >= 1)
        {            // 4)完全に不透明になったら処理を抜ける
            m_isFadeOut = false;
        }
    }

    // アルファ値を設定
    void SetAlpha()
    {
        // フェードする為の画像の色を設定
        m_fadeImage.color = new Color(m_red, m_green, m_blue, m_alfa);
    }
}
