using System.Collections;
using UnityEngine;

public class RandomGeneratorController : MonoBehaviour
{
    [SerializeField]
    Transform[] Generators;
    [SerializeField]
    GameObject Zombie;

    public float waitSecond { get; set; } = 3;

    WaitForSeconds wait;

    void Start()
    {
        StartCoroutine(Generate());

        wait = new(waitSecond);
    }

    IEnumerator Generate()
    {
        while (true)
        {
            int genNo = Random.Range(0, Generators.Length);
            GameObject zombie = ObjectPoolSingletons.Zombie1Pool.Get();

            zombie.transform.position = Generators[genNo].position;
            
            yield return wait;
        }
    }

    void Update()
    {
        
    }
}
