using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float timeTilNextSpawn;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, timeTilNextSpawn - 2);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTilNextSpawn)
        {
            var spawnPoint = transform.position;
            // Random y axis
            if (spawnGameObject.name == "FlyingObstacle")
            {
                spawnPoint.y = spawnPoint.y + Random.Range(-3, 3);
            }

            Instantiate(spawnGameObject, spawnPoint, Quaternion.identity);
            timer = Random.Range(0, timeTilNextSpawn - 2);
        }
    }
}
