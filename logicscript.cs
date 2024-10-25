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
    gameOverScreen.SetActive(true); // This should activate your game over panel
    Time.timeScale = 0; // Optionally pause the game
}
}