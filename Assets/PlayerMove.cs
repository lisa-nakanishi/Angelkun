using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
    }
}
