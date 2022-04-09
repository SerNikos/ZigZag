using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody rb;

    bool started;
    bool gameOver;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(speed, 0, 0);
        started = false;
        gameOver = false;
    }

        
    void Update()
    {
        if(!Physics.Raycast(transform.position, Vector3.down, 5f))//The Ray looks downwards 5 unit, if collides with anything returns true
        {
            gameOver = true; // the ray doesen't collide with anything, it returns false and we have a game over!
            rb.velocity = new Vector3(0, -25, 0); // -25 to go down 
        }
        if (Input.GetMouseButtonDown(0)&& !gameOver)
        {
            SwitchDirection();
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        Camera.main.GetComponent<CameraFollow>().gameOver = true;

    }

    void SwitchDirection()
    {
        if(rb.velocity.z >0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
}
