using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHitAction : MonoBehaviour
{
    //[SerializeField]
    //private int m_size; // サイズ //
    //[SerializeField]
    //private int m_incStar; // 生成する数の星 //

    private Vector3 m_pos; // 座標 //

    public GameObject m_particle;   // エフェクトを取得 // 

    public int m_deleteCount = 0; // 削除された数 // 

    // Start is called before the first frame update
    void Start()
    {
        //m_size = (int)this.gameObject.transform.localScale.x;
        m_pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        // 当たったのがプレイヤーの場合
        if (other.gameObject.tag == "Player")
        {
            // パーティクルを出す
            // Starプレハブを元に、インスタンスを生成、
            Instantiate(m_particle, new Vector3(m_pos.x, m_pos.y, m_pos.z), Quaternion.identity);

            // StarプレハブをGameObject型で取得
            GameObject obj = (GameObject)Resources.Load("Object/prefab/Star1");
            // Starプレハブを元に、インスタンスを生成、
            Instantiate(obj, new Vector3(m_pos.x, m_pos.y, m_pos.z), Quaternion.identity);

            // 自身を消す
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Collision")
        {
            m_deleteCount = 1;
            // 自身を消す
            Destroy(this.gameObject);
        }
    }
}
