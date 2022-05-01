using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public int speed;
    public GameObject entityDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    // On collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == entityDestroyer.name)
        {
            FindObjectOfType<Score>().score++;
            Object.Destroy(gameObject);
        }
    }
}
