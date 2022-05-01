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
}
