using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject objects;
    //スコアを表示するテキスト
    private GameObject scoreText;
    //スコアを初期化
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");
    }
    void OnCollisionEnter(Collision collision)
    {
        string Tag = collision.gameObject.tag;
        if (Tag == "BinTag")
        {
            score += 10;
        }
        if (score > 0)
        {
            SceneManager.LoadScene("GameOverScenes");
            Destroy(objects);

        }
    }
    // Update is called once per frame
    void Update()
    {
        //scoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
       
    }
}
