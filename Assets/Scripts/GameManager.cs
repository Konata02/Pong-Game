using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // No script do GameManager
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;
    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;
    public int winPoints;
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;


    void Start()
    {
        ResetGame();
    }

    void Update(){
        
        if (Input.GetKeyDown(KeyCode.W)){
            ResetGame();
        }
    }

    public void ResetGame()
    {
        // Define as posições iniciais das raquetes
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;
        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();


     }

      public void ScorePlayer()
      {
          playerScore++;
          textPointsPlayer.text = playerScore.ToString();
          SaveController.Instance.SavePoints(playerScore.ToString());
          CheckWin();
      }
         
      public void ScoreEnemy()
      {
         enemyScore++;
         textPointsEnemy.text = enemyScore.ToString();
         SaveController.Instance.SavePoints(enemyScore.ToString());
         CheckWin();
      }


     public void CheckWin()
     {
         if(enemyScore >= winPoints || playerScore >= winPoints)
         {
           ballController.DestroyBall();
            EndGame();
            ResetGame();
         }
     }

      public void EndGame(){
            screenEndGame.SetActive(true);
            string winner = SaveController.Instance.GetName(playerScore > enemyScore);
            textEndGame.text = "Vitória "+winner;
            SaveController.Instance.SaveWinner(winner);
            Invoke("LoadMenu", 2f);
      }

        
     private void LoadMenu()
     {
         SceneManager.LoadScene("Menu");
     }

    


}
