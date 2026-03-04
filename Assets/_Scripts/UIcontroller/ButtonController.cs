using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject rankingBoard;

    public void GameStart()                 // 게임 시작
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GotoTitle()                 // 타이틀 화면 이동
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadRanking()               // 상위 5명 랭킹 불러오기
    {
        rankingBoard.SetActive(true);
    }
    
    public void QuitRanking()               // 랭킹 보드 비활성화
    {
        rankingBoard.SetActive(false);
    }
}
