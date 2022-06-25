using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerMan;
    public GameObject playerWoman;
    public Vector2 spawnPoint;
    public Text gameOverText;
    public Button restartGameButton, backToMainMenuButton;
    private float gameSpeed = 1;
    private Material materialBackGround;
    private Material materialGround;

    // Start
    private void Start()
    {
        if (PlayerData.Character == "man")
        {
            Instantiate(playerMan, spawnPoint, Quaternion.identity);
        }
        if (PlayerData.Character == "woman")
        {
            Instantiate(playerWoman, spawnPoint, Quaternion.identity);
        }
        restartGameButton.gameObject.SetActive(false);
        backToMainMenuButton.gameObject.SetActive(false);
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
        this.gameSpeed = 1 + (score / 200);
    }

    // Gameover script
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        restartGameButton.gameObject.SetActive(true);
        restartGameButton.onClick.AddListener(() => Restart());
        backToMainMenuButton.gameObject.SetActive(true);
        backToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene("StartScreen"));
    }

    // Restart the scene
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

// Static class to pass data
public static class PlayerData
{
    public static string Character { get; set; }
}