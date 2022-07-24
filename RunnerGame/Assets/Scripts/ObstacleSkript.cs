using UnityEngine;

public class ObstacleSkript : MonoBehaviour
{
    public float speed = 0;
    private GameObject entityDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed * FindObjectOfType<GameManager>().getGameSpeed();
        entityDestroyer = GameObject.Find("EntityDestroyer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }

    // Used for bonus items
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On hit of bonus get boost
        if (gameObject.tag == "Bonus" && collision.gameObject.name == entityDestroyer.name)
        {
            Object.Destroy(gameObject);
        }
    }

    // On collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == entityDestroyer.name)
        {
            FindObjectOfType<Score>().increaseScore();
            Object.Destroy(gameObject);
        }
    }
}
