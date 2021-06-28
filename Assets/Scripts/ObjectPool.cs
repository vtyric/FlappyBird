using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int capacity;

    private Camera camera;

    private readonly List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        camera = Camera.main;

        for (var i = 0; i < capacity; i++)
        {
            var spawned = Instantiate(prefab, container.transform);
            spawned.SetActive(false);
            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject res)
    {
        res = pool.FirstOrDefault(x => !x.activeSelf);

        return res != null;
    }

    public void ResetPool()
    {
        foreach (var item in pool)
            item.SetActive(false);
    }
}
