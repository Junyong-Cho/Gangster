using UnityEngine;

public class HealItemController : MonoBehaviour
{
    float speed = 2f;
    float height = 0.1f;

    [SerializeField]
    Rigidbody2D rgBody;
    [SerializeField]
    GameObject healItem;

    Vector2 pos;

    void Awake()
    {
        pos = healItem.transform.localPosition;
    }

    void OnEnable()
    {
        rgBody.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }

    void Update()
    {
        healItem.transform.localPosition = new(pos.x, pos.y + Mathf.Sin(Time.time * speed) * height);
    }
}
