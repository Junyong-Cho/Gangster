using static AnimeParams;

using UnityEngine;

partial class ZombieController
{
    protected virtual Vector2 _moveVector(Vector2 posA, Vector2 posB)
    {
        float dist = Vector2.Distance(posA, posB);

        if (dist < _canAttak)
        {
            // 공격 로직 작성
        }
        else if (dist < _recognizedDist)
            return posA - posB;

        return Vector2.zero;
    }
    

    public void GetUppercut(Vector2 dir, int damage)
    {
        rgBody.AddForce(dir, ForceMode2D.Impulse);
        GetDamage(damage);
    }

    protected virtual void _setAnime(Vector2 move)
    {
        if (move.x < 0)
            flipRenderer.flipX = true;
        else if (move.x > 0)
            flipRenderer.flipX = false;

        animator.SetBool(Move, move != Vector2.zero);
    }
}
