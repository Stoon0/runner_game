using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    // Increase score
    public void increaseScore(int increaseBy = 1)
    {
        if (!FindObjectOfType<GameManager>().restartGameButton.gameObject.activeSelf)
        {
            score = score + increaseBy;
            FindObjectOfType<GameManager>().updateGameSpeed(score);

            if (score > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score);
                if (PlayerData.Character == "man")
                {
                    PlayerPrefs.SetString("player", "Michael");
                }
                if (PlayerData.Character == "woman")
                {
                    PlayerPrefs.SetString("player", "Selina");
                }
            }
        }
    }
}
