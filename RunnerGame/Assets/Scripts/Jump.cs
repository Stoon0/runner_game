using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Vector2 jumpHeight;
    private bool touchingObject = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingObject && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

    // Collision enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        touchingObject = true;
    }

    // Collision exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingObject = false;
    }
}
