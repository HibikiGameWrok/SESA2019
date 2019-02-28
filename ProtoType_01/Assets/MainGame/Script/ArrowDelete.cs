using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDelete : MonoBehaviour
{
    // メンバー変数
    [SerializeField]
    private GameObject m_pstar; // PStarオブジェクト // 

    private PStarControl m_pstarContorl;  // MoveScript //

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクト取得
        m_pstar = GameObject.Find("PStar");
        // オブジェクト内のscriptを取得
        m_pstarContorl = m_pstar.GetComponent<PStarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // 星が発射された時自身を消す
        if (m_pstarContorl.m_shotFlag == true)
        {
            Debug.Log("矢印モデルは消された");
            Destroy(this.gameObject);
        }

    }
}
