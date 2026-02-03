using UnityEngine;

partial class ZombieController
{
    protected virtual Vector2 _moveVector(Vector2 posA, Vector2 posB)
    {
        float dist = Vector2.Distance(posA, posB);

        if (dist < 1)
        {
            // 공격 로직 작성
        }
        else if (dist < _recognizedDist)
            return posA - posB;

        return Vector2.zero;
    }
    

    public void GetUppercut(Vector2 dir, int damage)
    {
        if (_dead)
            return;

        rgBody.AddForce(dir, ForceMode2D.Impulse);
        GetDamage(damage);
    }

}
