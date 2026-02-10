using TMPro;
using UnityEngine;

public class GameOverBoardController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetScore(string sc)
    {
        score.text += sc;
    }
}
