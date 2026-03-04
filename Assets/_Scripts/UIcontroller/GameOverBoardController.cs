using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GameOverBoardController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;
    [SerializeField]
    TMP_InputField playerName;

    [SerializeField]
    GameObject inputBoard;
    [SerializeField]
    GameObject recordButton;
    [SerializeField]
    GameObject messageBoard;
    [SerializeField]
    TextMeshProUGUI message;

    WaitForSeconds wait = new(2);

    void Start()
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        inputBoard.SetActive(false);
    }

    public void SetScore(string sc)
    {
        score.text += sc;
    }

    public void OpenInputBoard()
    {
        inputBoard.SetActive(true);
    }

    public void QuitInputBoard()
    {
        inputBoard.SetActive(false);
    }

    public void PostRecord()
    {
        int len = playerName.text.Length;

        if (len < 2 || len > 10)
        {
            playerName.text = "";
            return;
        }

        Record record = new()
        {
            Name = playerName.text,
            Score = int.Parse(score.text.Split(':')[1])
        };

        string jsonRecord = JsonUtility.ToJson(record);

        StartCoroutine(PostRequest(jsonRecord));
    }

    IEnumerator PostRequest(string json)
    {
        using(var req = new UnityWebRequest("http://localhost:8080/postrc", "POST"))
        {
            byte[] raw = Encoding.UTF8.GetBytes(json);
            req.uploadHandler = new UploadHandlerRaw(raw);
            req.downloadHandler = new DownloadHandlerBuffer();

            req.SetRequestHeader("Content-Type", "application/json");

            yield return req.SendWebRequest();

            if(req.result == UnityWebRequest.Result.Success)
            {
                message.text = "Success!";
                inputBoard.SetActive(false);
                recordButton.SetActive(false);
            }
            else
            {
                message.text = "Failed Try Again";
            }

            StartCoroutine(CallMessageBoard());
        }
    }

    IEnumerator CallMessageBoard()
    {
        messageBoard.transform.localPosition = new(0, 0);
        yield return wait;
        messageBoard.transform.localPosition = new(9999, 9999);
    }
}