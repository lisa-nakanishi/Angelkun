using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MoveLR
{
    public GameObject binPrefab;
    public GameObject bomPrefab;
    float span = 1.0f;
    float delta = 0;

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
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            //瓶のアイテムを生成
            GameObject binitem = Instantiate(binPrefab, this.transform.position, Quaternion.identity);
            binitem.transform.parent = angel.transform;
        }
       
        
    }    
}
