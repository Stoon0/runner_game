using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerSkript : MonoBehaviour
{
    public Vector2 jumpHeight;
    public Animator animator;
    private GameObject ground;
    private GameObject entityDestroyer;
    private bool touchingObject = false;
    private Vector2 boxColliderSize;
    private Vector2 boxColliderOffset;


    // Start
    void Start()
    {
        boxColliderSize = GetComponent<BoxCollider2D>().size;
        boxColliderOffset = GetComponent<BoxCollider2D>().offset;
        entityDestroyer = GameObject.Find("EntityDestroyer");
        ground = GameObject.Find("Ground");
    }

    // Update
    void Update()
    {
        if (touchingObject && CrossPlatformInputManager.GetButtonDown("Jump"))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        if (CrossPlatformInputManager.GetButtonDown("Crouch"))  //makes player sneak
        {
            animator.SetBool("IsJumping", false);
            GetComponent<BoxCollider2D>().size = new Vector2(boxColliderSize.x, boxColliderSize.y - 4);
            GetComponent<BoxCollider2D>().offset = new Vector2(boxColliderOffset.x, boxColliderOffset.y - 2);
            GetComponent<Rigidbody2D>().gravityScale = 20;
            animator.SetBool("IsSneaking", true);
        }
        else if (CrossPlatformInputManager.GetButtonUp("Crouch"))
        {
            GetComponent<BoxCollider2D>().size = boxColliderSize;
            GetComponent<BoxCollider2D>().offset = boxColliderOffset;
            GetComponent<Rigidbody2D>().gravityScale = 10;
            animator.SetBool("IsSneaking", false);
        }
    }

    // Used for bonus items
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On hit of bonus get boost
        if (collision.gameObject.tag == "Bonus")
        {
            FindObjectOfType<Score>().increaseScore(5);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            Object.Destroy(collision.gameObject);
        }
    }

    // Collision enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == ground.name)
        {
            animator.SetBool("IsJumping", false);
            touchingObject = true;
        }
        if (collision.gameObject.name == entityDestroyer.name)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        // On hit of enemy run slower
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
        }
    }

    // Collision exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == ground.name)
        {
            touchingObject = false;
        }
    }
}
