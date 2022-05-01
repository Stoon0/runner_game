using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;
    public Text gameOverText;

    // Gameover script
    public void GameOver()
    {
        Debug.Log("GameOver");

        gameOverText.text = "Game Over";
        Invoke("Restart", restartDelay);
    }

    // Restart the scene
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
