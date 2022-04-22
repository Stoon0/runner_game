using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float timeTilNextSpawn = 5;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeTilNextSpawn)
        {
            Debug.Log(transform.position);
            Instantiate(spawnGameObject, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
