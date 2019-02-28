using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStarControl : MonoBehaviour
{
    // メンバ定数
    private static float MAX_ANGLE = 90.0f; // 最大角度 //

    // メンバ変数
    private float m_angle = 0;  // 角度 //
    private float m_rotVel;  // 回転速度 //

    public float m_addRotate = 100; // 角度力を加える // 
    private float m_startRotation;//最初のグローバルY座標//

    public bool m_shotFlag = false; // 星を投げたかどうか //

    public float m_tmpAngle; // 角度の値を一時的に保管 //

    // Start is called before the first frame update
    void Start()
    {
        // 最初のグローバルのY座標を代入
        m_startRotation = this.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move_LR();  /* 回転操作 */
        Shot();
    }

    // 飛ばす方向を回転
    private void Move_LR()
    {
        // 左回転
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // オブジェクトの角度を更新
            this.transform.Rotate(new Vector3(0, 0, m_addRotate) * Time.deltaTime);
            // 角度変数に力と時間を加算
            m_angle += (m_addRotate * Time.deltaTime);
            // 制限角度の最大値よりも大きいなら90度にする
            if (m_angle >= MAX_ANGLE)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, m_startRotation + MAX_ANGLE);
                m_angle = MAX_ANGLE;
            }
            m_tmpAngle = this.transform.rotation.z;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // オブジェクトの角度を更新
            this.transform.Rotate(new Vector3(0, 0, -m_addRotate) * Time.deltaTime);
            // 角度変数に力と時間を加算
            m_angle -= (m_addRotate * Time.deltaTime);
            // 制限角度の-最大値よりも小さいなら-90度にする
            if (m_angle <= MAX_ANGLE * -1)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, m_startRotation - MAX_ANGLE);
                m_angle = MAX_ANGLE * -1;
            }
            m_tmpAngle = this.transform.rotation.z;
        }
    }


    // 投げる処理
    private void Shot()
    {
        // 星を飛ばすフラグを立てる
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_shotFlag = true;
            Debug.Log("スペースキーが押された");
        }
        else
        {
            m_shotFlag = false;
        }
    }
}
