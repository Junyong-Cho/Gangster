using UnityEngine;

public class BulletController : MonoBehaviour
{
    static int _damage = 10;
    static float _speed = 10f;

    [SerializeField]
    Rigidbody2D rb;

    void Start()
    {
        rb.linearVelocity = transform.right * _speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
