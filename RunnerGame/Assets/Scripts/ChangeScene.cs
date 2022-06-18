using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button startGameButtonMan;
    public Button startGameButtonWoman;
    public string mainSceneName;

    // Start
    private void Start()
    {
        startGameButtonMan.onClick.AddListener(() => LoadScene("man"));
        startGameButtonWoman.onClick.AddListener(() => LoadScene("woman"));
    }

    private void LoadScene(string character)
    {
        SceneManager.LoadScene(mainSceneName);
        PlayerData.Character = character;
    }
}
