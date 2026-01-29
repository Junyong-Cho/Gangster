using System.Diagnostics;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    void Awake()
    {
        input = new();
        _idleTimer = Stopwatch.StartNew();
        animator = GetComponent<Animator>();

        input.Player.Move.performed += context => _action(() =>
        {
            _moveVec = context.ReadValue<Vector2>();
        });

        input.Player.Move.canceled += context => _moveVec = Vector2.zero;

        input.Player.Attack.performed += context => StartCoroutine(_attack());

        input.Player.Attack.canceled += context => _attacking = false;

        input.Player.Jump.performed += context => _action(_jump);
    }

    void OnEnable()
    {
        input.Enable();    
    }

    void OnDisable()
    {
        input.Disable();    
    }

    void Update()
    {
        if (_moveVec.x < 0)
            flipRender.flipX = true;
        else if (_moveVec.x > 0)
            flipRender.flipX = false;

        transform.Translate(_moveVec * speed * Time.deltaTime);
        _setAnimation();
    }

    void FixedUpdate()
    {
        var hit = Physics2D.Raycast(Feet.position, Vector2.down, 0.1f, groundLayer);

        _onAir = hit.collider == null;
    }

}
