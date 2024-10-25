using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logicscript : MonoBehaviour
{
   public int playerScore;
  public Text scoreText;
  public GameObject gameOverScreen;

  [ContextMenu("Increase Score")] 

  public void Update(){
    LoadNextLevel();
  }
  public void addScore(int scoreToAdd)
  {
    playerScore = playerScore + scoreToAdd;
    scoreText.text = playerScore.ToString();
  }
  public void restartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  
  public void GameOver()
{
    gameOverScreen.SetActive(true);
    Time.timeScale = 0; 
}

private void LoadNextLevel()
    {
        if(playerScore>=100){
            SceneManager.LoadScene("NextLevel");
        }
    }
}