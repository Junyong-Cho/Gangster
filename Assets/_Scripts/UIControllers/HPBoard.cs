using UnityEngine;

public class HPBoard : MonoBehaviour
{
    Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.rotation = cam.rotation;
    }
}
