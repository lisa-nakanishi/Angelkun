using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D colision)
    {

        //ボムが地面に衝突した場合
        if (colision.collider.tag == "BomTag")
        {
            Destroy(colision.gameObject);
            Debug.Log("ボム削除");

        }
        else if(colision.collider.tag == "BinTag")
        {
            Destroy(colision.gameObject);
            Debug.Log("瓶削除");
        }
    }
}
