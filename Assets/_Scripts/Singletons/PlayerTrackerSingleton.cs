using UnityEngine;

public class PlayerTrackerSingleton : MonoBehaviour
{
    static GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }

    public static GameObject Player => player;
    public static Vector2 PlayerPostion => player.transform.position;
}
