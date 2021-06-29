using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

    protected void DisableObjectAbroadScreen()
    {
        var disablePoint = camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in pool
            .Where(item =>
                item.activeSelf && item.transform.position.x < disablePoint.x))
            item.SetActive(false);
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
