﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameObject player;
    //移動する範囲を制限するための宣言
    float posiX;
    float x;
    //動かすための変数宣言
    private Animator anim = null;
    private Rigidbody2D rb2d = null;
    //インスペクタ―で設定する
    public float speed;
    void Start()
    {　//プレイヤーを移動させるためのコンポーネントを取得させる
        rb2d = GetComponent<Rigidbody2D>();
        //プレイヤーのアニメーションを取得させる
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
            anim.SetBool("Walk", true);
            
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-0.18f, 0.18f, 0.18f);
            anim.SetBool("Walk", true);
           
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);
       
        Clamp();
    }
    void Clamp()
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
        
    }

    void OnCollisionEnter2D(Collision2D colision)
    {

        //ボムに衝突した場合
        if (colision.collider.tag ==  "BomTag")
        {
            anim.SetBool("Over", true);
            
            Destroy(colision.gameObject);
            Debug.Log("当たった");


            Invoke("offAnime", 1f);

        }
        
    }
    void offAnime()
    {
        Debug.Log("アニメーション無効");
        anim.SetBool("Over", false);
    }
}
