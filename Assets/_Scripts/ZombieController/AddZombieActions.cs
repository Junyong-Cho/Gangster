using DG.Tweening;
using UnityEngine;

partial class ZombieController
{
    protected virtual Vector2 _moveVector(Vector2 player, Vector2 thisObject)
    {
        float dist = Vector2.Distance(player, thisObject);

        if (dist <= 1)
        {
            _attack();
            return Vector2.zero;
        }

        return player - thisObject;
    }



    public void GetUppercut(Vector2 dir, int damage)
    {
        if (_dead)
            return;

        rgBody.AddForce(dir, ForceMode2D.Impulse);
        GetDamage(damage);
    }

}
