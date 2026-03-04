using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class RankingBoardController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI rankList;
    StringBuilder rankBuilder;

    void Awake()
    {
        gameObject.SetActive(false);
        rankBuilder = new();
    }

    void OnEnable()
    {
        StartCoroutine(RequestRanking());
    }

    IEnumerator RequestRanking()
    {
        using (var req = UnityWebRequest.Get("http://localhost:8080/list"))
        {
            yield return req.SendWebRequest();
            rankBuilder.Clear();

            if(req.result == UnityWebRequest.Result.Success)
            {
                string json = req.downloadHandler.text;

                List<Record> records = JsonConvert.DeserializeObject<List<Record>>(json);


                for (int i = 0; i < records.Count; i++)
                {
                    rankBuilder.Append(i + 1);
                    rankBuilder.Append('\t');
                    rankBuilder.Append(records[i].Name);
                    rankBuilder.Append('\t');
                    rankBuilder.AppendLine(records[i].Score.ToString());
                }

            }
            else
            {
                rankList.text = "Server Error";
            }
                rankList.text = rankBuilder.ToString();
        }
    }

    void Update()
    {
        
    }
}
