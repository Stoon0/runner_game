using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public Button restartGameButton;
    private float gameSpeed = 1;
    private Material materialBackGround;
    private Material materialGround;

    // Start
    private void Start()
    {
        restartGameButton.gameObject.SetActive(false);
        materialBackGround = GameObject.Find("BackGround").GetComponent<Renderer>().material;
        materialGround = GameObject.Find("Ground").GetComponent<Renderer>().material;
    }

    // Update
    private void Update()
    {
        Vector2 offset = new Vector2(Time.time * 0.3f, 0);
        materialBackGround.mainTextureOffset = offset;

        Vector2 offsetGround = new Vector2(Time.deltaTime * (this.gameSpeed / 3.35f), 0);
        materialGround.mainTextureOffset += offsetGround;
    }

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
        gameOverText.text = "Game Over";
        restartGameButton.gameObject.SetActive(true);
        restartGameButton.onClick.AddListener(() => Restart());

    }

    // Restart the scene
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
