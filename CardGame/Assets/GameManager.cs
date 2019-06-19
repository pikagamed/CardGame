using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Cards cardPlayer, cardEnemy;
    //public Sprite Image0, Image1, Image2, Image3, Image4,
    //                    Image5, Image6, Image7, Image8, Image9;

    public Sprite[] images;

    public TextMesh resultText; //宣告文字元件
    public TextMesh resetText; //宣告文字元件

    void Start()
    {
        int rPlayer, rEnemy;

        rPlayer = Random.Range(0, 10);
        rEnemy = Random.Range(0, 10);

        cardPlayer = new Cards(rPlayer, -5, images[rPlayer]);
        cardEnemy = new Cards(rEnemy, 5, images[rEnemy]);

        //判斷式 IF
        //一行判斷式  ? :

        resultText.fontSize = 84;
        if (cardPlayer.number > cardEnemy.number)
        {
            resultText.text = "WIN";
            resultText.color = Color.red;
        }
        else if (cardPlayer.number < cardEnemy.number)
        {
            resultText.text = "LOSE...";
            resultText.color = Color.blue;
        }
        else
        {
            resultText.text = "DRAW";
            resultText.color = Color.green;
        }

        StartCoroutine(WaitSecond(2));
        resetText.characterSize = 0.1f;
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
            SceneManager.LoadScene("CardGame");
        }
    }

    IEnumerator WaitSecond(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
