using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLR : MonoBehaviour
{
   
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {　
        //元の位置を宣言
        initialPosition = transform.position;
    }

    // 自動で左右往復させる
    void Update()
    {
        //元の位置から左右移動の計算
        transform.position = new Vector3(Mathf.Sin(Time.time) * 2.0f + initialPosition.x, initialPosition.y, initialPosition.z);

    }
}


    

