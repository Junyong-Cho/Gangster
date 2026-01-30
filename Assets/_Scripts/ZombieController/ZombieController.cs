using UnityEngine;

public partial class ZombieController : MonoBehaviour
{
    void Start()
    {
        hpBar.value = 1;
    }

    void Update()
    {
        Vector2 move = _moveVector(PlayerTrackerSingleton.GetPlayer().transform.position, transform.position);

        move.Normalize();

        transform.Translate(move * Time.deltaTime * _speed);

        _setAnime(move);
    }
}
