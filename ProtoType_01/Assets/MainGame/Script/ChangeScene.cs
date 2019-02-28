using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //[System.NonSerialized]
    //public int m_changeCount; // 赤い星が削除された数

    //private GameObject m_star;
    //private int m_changeScene;

    // Inspector上で次のシーン名を設定
    public string m_nextSceneName;

    // 切り替えフラグ
    public bool m_changeFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //m_star = GameObject.Find ("StarRed");
    }

    // シーン切り替え
    void changeNext()
    {
        // シーン事の切り替え条件が達成された時
        if (m_changeFlag == true)
        {
            // 5.0f経ったらシーン切り替え
            if (Time.timeSinceLevelLoad > 5.0f)
            {
                // inspectorで設定されたシーンへ切り替える
                SceneManager.LoadScene(m_nextSceneName, LoadSceneMode.Single);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Title_ChangeAction();

        // 次のシーンへ切り替える関数を更新
        changeNext();

        //if (m_star.GetComponent<StarHitAction>().m_deleteCount == 1)
        //{
        //    m_changeScene += m_star.GetComponent<StarHitAction>().m_deleteCount;
        //}
        //if (m_changeCount >= 2)
        //{
        //    SceneManager.LoadScene("ResultScene");
        //}
    }

    // タイトルシーンで行うシーン切り替えするアクション
    void Title_ChangeAction()
    {
        // スペースキーを押されたら
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // シーン切り替えフラグをtrueに
            m_changeFlag = true;
        }
    }
}
