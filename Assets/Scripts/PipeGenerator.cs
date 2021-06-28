using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject template;
    [SerializeField] private float secondsBetweenSpawn;
    [SerializeField] private float minSpawnPositionY;
    [SerializeField] private float maxSpawnPositionY;

    private float elepsedTime = 0;

    private void Start()
    {
        Initialize(template);
    }

    private void Update()
    {
        elepsedTime += Time.deltaTime;

        if (elepsedTime > secondsBetweenSpawn && TryGetObject(out var pipe))
        {
            elepsedTime = 0;
            var spawnPositionY = Random.Range(minSpawnPositionY, maxSpawnPositionY);
            pipe.SetActive(true);
            pipe.transform.position= new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        }
    }
}
