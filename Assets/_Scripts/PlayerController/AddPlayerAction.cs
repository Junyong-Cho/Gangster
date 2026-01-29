using System;
using System.Collections;
using UnityEngine;

public partial class PlayerController
{
    void _action(Action action)
    {
        _idleTimer.Reset();
        _idleTimer.Start();
        _attacking = false;

        action();
    }

    IEnumerator _attack()
    {
        _idleTimer.Reset();
        while (input.Player.Attack.IsPressed())
        {
            if (_moveVec == Vector2.zero && !_onAir)
                _attacking = true;
            yield return null;
        }
        _idleTimer.Start();
    }

    void _jump()
    {
        if (!_onAir)
        {
            rgBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    void _setAnimation()
    {
        animator.SetInteger("IdieTime", (int)(_idleTimer.ElapsedMilliseconds / 1000));
        animator.SetBool("Run", _moveVec != Vector2.zero);
        animator.SetBool("Jump", _onAir);
        animator.SetBool("Shot", _attacking);
    }
}
