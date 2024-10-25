using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boundaryscript : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Aeroplane")) // Check if collided with the airplane
        {
            GameOver(collision.gameObject); // Call GameOver and pass the airplane
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(GameObject aeroplane)
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; // Pause the game

        // Make the airplane stick to the boundary
        aeroplane.GetComponent<Rigidbody2D>().isKinematic = true; // Stop physics movement
        aeroplane.transform.SetParent(transform); // Stick to the boundary
        aeroplane.transform.localPosition = Vector3.zero; // Center it at the boundary
    }
}