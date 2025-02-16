using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScore : MonoBehaviour
{

    public static GameOverScore GOS;
    public Text highScoreTXT;
    public Text Score;
    public Text Coins;
    int highScore;
    int ab;
  //  int coin;
   
    private void Start()
    {
        
        highScore = PlayerPrefs.GetInt("highScore", 0);
       // ab = 0;
        
    }
    public void Setup()
    {
       
       gameObject.SetActive(true);
        Score=GetComponent<Text>();
      //  Coins = GetComponent<Text>();
        highScoreTXT = GetComponent<Text>();

    }
    public void Update()
    { 
        if (highScore < ab)
        {
            PlayerPrefs.SetInt("highScore", ab);
        }
        ab = ScoreCounter.ScoreVal;
       // coin = CoinManager.coinNum;
      //  Coins.text = "Coins  " + coin;
        Score.text = "Score  " + ab;
        highScoreTXT.text = "HIGHSCORE  " + highScore;
        

    }
   
     public void Restart()
    {
        // SceneManager.LoadScene("1");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
      //  ab = 0;
       // Score.text = "Score" + ab;
       // SceneManager.GetActiveScene();
    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    

}

