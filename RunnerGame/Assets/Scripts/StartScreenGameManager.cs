using UnityEngine;
using UnityEngine.UI;
using System;

public class StartScreenGameManager : MonoBehaviour
{
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "H I G H S C O R E: " + PlayerPrefs.GetInt("highscore") + (string.IsNullOrEmpty(PlayerPrefs.GetString("player")) ? "" : " (" + PlayerPrefs.GetString("player") + ")");
    }
}
