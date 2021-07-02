using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MoveLR
{
   
    public GameObject bomPrefab;
    [SerializeField] GameObject angel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void AnimeInstant()
    {
       
        //生成する爆弾数をランダムに決める
       
        GameObject item = Instantiate(bomPrefab,this.transform.position, Quaternion.identity);
        item.transform.parent = angel.transform;

        if (transform.position.y <= -5f)
        {
            Destroy(gameObject);
            
        }
        Debug.Log("削除");
    }
    // Update is called once per frame
    void Update()
    {
        
    }    
}
