using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector2 jumpHeight;
    public Animator animator;
    public GameObject ground;
    private bool touchingObject = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingObject && Input.GetButtonDown("Jump"))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))  //makes player sneak
        {
            animator.SetBool("IsJumping", false);
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.2f);
            GetComponent<Rigidbody2D>().gravityScale = 20;
            animator.SetBool("IsSneaking", true);
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.4f);
            GetComponent<Rigidbody2D>().gravityScale = 10;
            animator.SetBool("IsSneaking", false);
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
