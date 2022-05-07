using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }

    // Increase score
    public void increaseScore(int increaseBy = 1)
    {
        score = score + increaseBy;
        FindObjectOfType<GameManager>().updateGameSpeed(score);
    }
}
