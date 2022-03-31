using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour{
    private const string constMainScene = "MainScene";

    public void Play()
    {
        SceneManager.LoadScene(constMainScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
