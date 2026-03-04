using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolSingletons : MonoBehaviour
{
    public static ObjectPoolSingletons objectSingletons;

    [SerializeField]
    GameObject HealItem;        // 힐 아이템 오브젝트풀
    [SerializeField]        
    GameObject Zombie1;         // 좀비 오브젝트풀

    public static ObjectPool<GameObject> HealItemPool;
    public static ObjectPool<GameObject> Zombie1Pool;

    void Awake()
    {
        HealItemPool = new(
            createFunc: () => Instantiate(HealItem),
            actionOnGet: (heal) => heal.SetActive(true),
            actionOnRelease: (heal) => heal.SetActive(false),
            actionOnDestroy: (heal) => Destroy(heal)
            );
        Zombie1Pool = new(
            createFunc: () => Instantiate(Zombie1),
            actionOnGet: (zombie) => zombie.SetActive(true),
            actionOnRelease: (zombie) => zombie.SetActive(false),
            actionOnDestroy: (zombie) => Destroy(zombie)
            );
    }
    
}
