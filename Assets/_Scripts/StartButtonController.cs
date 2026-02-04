using UnityEngine;
using UnityEngine.SceneManagement;


public class StartButtonController : MonoBehaviour
{
    void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
