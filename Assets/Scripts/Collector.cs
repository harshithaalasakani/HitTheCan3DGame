using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int cansCount;
    public GameObject[] balls;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find ScoreManager in the scene
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Cans")
        {
            target.gameObject.SetActive(false);
            cansCount--;

            // Update score by adding points (e.g., 10 points per can)
            scoreManager.AddScore(10);

            if (cansCount == 0)
            {
                Invoke("RestartGame", 2f);
            }
        }

        if (target.tag == "Player")
        {
            target.gameObject.SetActive(false);
            if (cansCount != 0)
            {
                Instantiate(balls[Random.Range(0, balls.Length)]);
            }
        }
    }
}
