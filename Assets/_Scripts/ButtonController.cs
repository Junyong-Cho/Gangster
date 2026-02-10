using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GotoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
