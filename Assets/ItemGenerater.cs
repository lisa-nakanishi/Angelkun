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
       
        //天使の動きに合わせてボムを生成
       
        GameObject item = Instantiate(bomPrefab,this.transform.position, Quaternion.identity);
        item.transform.parent = angel.transform;

        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }    
}
