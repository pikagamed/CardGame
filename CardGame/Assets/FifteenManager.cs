using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifteenManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Cards[] cardPlayer = new Cards[2];
    public Cards[] cardEnemy = new Cards[2];

    //public Cards cardPlayer0, cardPlayer1;
    //public Cards cardEnemy0, cardEnemy1;

    //public Sprite Image0, Image1, Image2, Image3, Image4,
    //                    Image5, Image6, Image7, Image8, Image9;

    public Sprite[] images;

    public TextMesh resultText; //宣告文字元件
    public TextMesh resetText; //宣告文字元件

    bool resetKey = false;

    public TextMesh playerCount; //宣告文字元件
    public TextMesh enemyCount; //宣告文字元件

    void Start()
    {
        int rPlayer, rEnemy;
        rPlayer = Random.Range(0, 10);
        rEnemy = Random.Range(0, 10);
        cardPlayer[0] = new Cards(rPlayer, -7, images[rPlayer], "PlayerCard0");
        cardEnemy[0]= new Cards(rEnemy, 7, images[rEnemy], "EnemyCard0");
        playerCount.text = (cardPlayer[0].number).ToString();
        enemyCount.text = (cardEnemy[0].number).ToString();
    }

    //更新事件：每幀執行一次(60Hz)
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if(!resetKey && Input.GetKeyDown(KeyCode.Space))
            {
                //空白鍵加牌

                //不允許玩家再做其他操作
                resetKey = true;
                resetText.text = "Press R Key to restart";

                //加牌
                int rPlayer, rEnemy;

                rPlayer = Random.Range(0, 10);
                rEnemy = Random.Range(0, 10);

                cardPlayer[1] = new Cards(rPlayer, -3, images[rPlayer], "PlayerCard1");
                cardEnemy[1] = new Cards(rEnemy, 3, images[rEnemy], "EnemyCard1");

                int playerTotal = cardPlayer[0].number + cardPlayer[1].number;
                int enemyTotal = cardEnemy[0].number + cardEnemy[1].number;

                playerCount.text = playerTotal.ToString();
                enemyCount.text = enemyTotal.ToString();

                if (playerTotal > 15)
                    playerCount.color = Color.red;
                if (enemyTotal > 15)
                    enemyCount.color = Color.red;

                //勝負判定
                if (playerTotal > 15 && enemyTotal > 15)
                {
                    //兩家都爆
                    resultText.text = "DRAW";
                    resultText.color = Color.green;
                }
                else if (playerTotal > 15)
                {
                    //玩家爆
                    resultText.text = "LOSE...";
                    resultText.color = Color.blue;
                }
                else if (enemyTotal > 15)
                {
                    //電腦爆
                    resultText.text = "WIN";
                    resultText.color = Color.red;
                }
                else
                {
                    if (playerTotal > enemyTotal)
                    {
                        resultText.text = "WIN";
                        resultText.color = Color.red;
                    }
                    else if (playerTotal < enemyTotal)
                    {
                        resultText.text = "LOSE...";
                        resultText.color = Color.blue;
                    }
                    else
                    {
                        resultText.text = "DRAW";
                        resultText.color = Color.green;
                    }
                }
            }
            else if (resetKey && Input.GetKeyDown(KeyCode.R))
            {
                //R鍵重新
                UnityEngine.SceneManagement.SceneManager.LoadScene("FifteenPoint");
            }
            //UnityEngine.SceneManagement.SceneManager.LoadScene("CardGame");
        }
    }

}
