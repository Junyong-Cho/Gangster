using UnityEngine;

public class PlayerTrackerSingleton : MonoBehaviour
{
    static GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag(Tags.Player);
    }

    public static GameObject GetPlayer() => Player;
}
