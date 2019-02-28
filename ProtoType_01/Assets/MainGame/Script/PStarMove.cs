using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStarMove : MonoBehaviour
{
    // メンバー変数
    public bool m_moveFlag = false; // 移動フラグ //
    [SerializeField] 
    private float m_moveSpeed;    // 移動速度 //

    private Vector3 m_direction; // 向き //

    private Rigidbody2D m_rb2D;  // 2D重力コンポーネント //
    private PStarControl m_pstarContorl; // MoveScript //

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        m_rb2D = gameObject.AddComponent<Rigidbody2D>();
        // 動作しないフラグを立てる
        m_rb2D.isKinematic = true;

        // scriptを取得
        m_pstarContorl = GetComponent<PStarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // 発射フラグが立ったら
        if (m_pstarContorl.m_shotFlag == true)
        {
            m_moveFlag = m_pstarContorl.m_shotFlag;
        }

        if (m_moveFlag == true)
        {
            // オブジェクトの(0,1)の向きを保管
            m_direction = this.transform.up;
            // 重力コンポーネントをdynamicに
            m_rb2D.isKinematic = false;
            
            // 自身の向きに移動
            m_rb2D.velocity = m_direction * (m_moveSpeed * Time.deltaTime);

            // 動きを止める
            m_moveFlag = false;
        }
    }
}
