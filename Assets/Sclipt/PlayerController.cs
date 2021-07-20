using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //時間のテキスト
    public Text timeText;
    //スコアを表示するテキスト
    public GameObject scoreText;
    //スコアを初期化
    private int score = 0;
    GameObject player;

    //移動する範囲を制限するための宣言
    float posiX;
    float x;
    //動かすための変数宣言
    private Animator anim = null;
    private Rigidbody2D rb2d = null;
    //インスペクタ―で設定する
    private float speed = 2.0f;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;

    void Start()
    {　//プレイヤーを移動させるためのコンポーネントを取得させる
        rb2d = GetComponent<Rigidbody2D>();
        //プレイヤーのアニメーションを取得させる
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //速度を0に設定
        float xSpeed = 0.0f;
        float horizontalKey = Input.GetAxis("Horizontal");

        if ((horizontalKey > 0) || this.isRButtonDown)
        {
            transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
            anim.SetBool("Walk", true);

            xSpeed = speed;
        }
        else if ((horizontalKey) < 0 || this.isLButtonDown)
        {
            transform.localScale = new Vector3(-0.18f, 0.18f, 0.18f);
            anim.SetBool("Walk", true);

            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        //velocity（速さ）代入
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);


        // scoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();

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
    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLButtonDown()
    {
        this.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理（追加）
    public void GetMyLButtonUp()
    {
        this.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRButtonDown()
    {
        this.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyRButtonUp()
    {
        this.isRButtonDown = false;
    }
    void OnCollisionEnter2D(Collision2D colision)
    {
        string Tag = colision.gameObject.tag;
        
        //ボムに衝突した場合
        if (colision.collider.tag == "BomTag")
        {
            anim.SetBool("Over", true);

            Destroy(colision.gameObject);
            Debug.Log("当たった");

            speed = 0.0f;
            anim.SetBool("Walk", false);


            //ゲームオーバーの画像を表示し、オブジェクト等を削除
            SceneManager.LoadScene("GameOverScenes");

            
        }
        //瓶に衝突した場合
        else if (colision.collider.tag == "BinTag")
        {
            score += 10;
            Destroy(colision.gameObject);
            Debug.Log("哺乳瓶に当たった");
           
        }
        

    }
}
