using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1f;
    public Text gameOverText;
    private float gameSpeed = 1;

    // Getter for gamepseed
    public float getGameSpeed()
    {
        return this.gameSpeed;
    }

    // Update game speed
    public void updateGameSpeed(float score)
    {
        this.gameSpeed = 1 + (score / 100);
    }

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
