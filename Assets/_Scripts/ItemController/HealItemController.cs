using UnityEngine;

public class HealItemController : MonoBehaviour
{
    float speed = 2f;                   // 위아래로 움직이는 속도
    float height = 0.1f;                // 움직이는 범위

    [SerializeField]
    Rigidbody2D rgBody;
    [SerializeField]
    GameObject healItem;                // 실제 아이템 오브젝트

    Vector2 pos;                        // 이 위치를 기준으로 위아래 움직임

    void Awake()
    {
        pos = healItem.transform.localPosition;             // 아이템 처음 위치 저장
    }

    void OnEnable()
    {
        rgBody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);  // 아이템 생성될 때 위로 튀어오르게
    }

    void Update()                                           // sin 함수로 상하운동
    {
        healItem.transform.localPosition = new(pos.x, pos.y + Mathf.Sin(Time.time * speed) * height);
    }
}
