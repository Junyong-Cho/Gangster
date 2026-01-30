using static AnimeParams;

using UnityEngine;

partial class ZombieController
{
    Vector2 _moveVector(Vector2 posA, Vector2 posB)
    {
        float dist = Vector2.Distance(posA, posB);

        if (dist < _canAttak) ;
        else if (dist < _recognizedDist)
            return posA - posB;

        return Vector2.zero;
    }

    void _setAnime(Vector2 move)
    {
        if (move.x < 0)
            filpRenderer.flipX = true;
        else if (move.x > 0)
            filpRenderer.flipX = false;

        animator.SetBool(Move, move != Vector2.zero);
    }
}
