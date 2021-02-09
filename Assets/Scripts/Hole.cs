using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;

    void OnTriggerStay(Collider other)
    {
        //コライダに触れているオブジェクトのRigidBodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();

        //タグに応じてボールに力を与える
        if (other.gameObject.tag == targetTag)
        {
            //中心地点でボールを止めるため速度を減速させる
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
