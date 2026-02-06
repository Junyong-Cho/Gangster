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
            Instantiate(Zombie, Generators[genNo].position, Quaternion.identity);
            
            yield return wait;
        }
    }

    void Update()
    {
        
    }
}
