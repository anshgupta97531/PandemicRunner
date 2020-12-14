
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject GameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberofCoins;
    public Text CoinsText; 
  
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberofCoins = 0;
       

    }

   
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);

        }
        CoinsText.text = "Coins:" + numberofCoins;

        if(SwipeManager.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
