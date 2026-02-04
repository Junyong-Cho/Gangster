using System.Collections;
using UnityEngine;

public class RandomGeneratorController : MonoBehaviour
{
    [SerializeField]
    Transform[] Generators;
    [SerializeField]
    GameObject Zombie;

    WaitForSeconds wait = new(3);

    void Start()
    {
        StartCoroutine(Generate());
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
