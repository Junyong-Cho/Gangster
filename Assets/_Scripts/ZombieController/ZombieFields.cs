using UnityEngine;
using UnityEngine.UI;

partial class ZombieController
{
    static float _speed = 1f;
    static float _recognizedDist = 10f;
    static float _canAttak = 1f;

    int maxHp = 100;
    int hp = 100;

    [SerializeField]
    SpriteRenderer filpRenderer;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Slider hpBar;
}
