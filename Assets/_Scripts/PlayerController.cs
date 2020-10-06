using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidBody;
    private Vector3 finalTouch = new Vector3(0, 0, 0);
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalBounds;
    


    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        bool touched = false;
        float dir = 0.0f;
        
        foreach (var touch in Input.touches)
        {
            touched = true;
            
            var worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));

            if (worldTouch.x > transform.position.x)
            {
                dir = 1;
            }
            if (worldTouch.x < transform.position.x)
            {
                dir = -1;
            }
            finalTouch = worldTouch;
        }

        if (Input.GetAxis("Horizontal")>=0.1f)
        {
            dir = 1;
        }
        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            dir = -1;
        }

        m_rigidBody.velocity = Vector2.ClampMagnitude(m_rigidBody.velocity + new Vector2(dir*horizontalSpeed, 0.0f), maxSpeed);
        m_rigidBody.velocity *= 0.8f;

        if (finalTouch.magnitude> 0)
        {
            m_rigidBody.velocity = new Vector3(0, 0, 0);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, finalTouch.x, 0.1f), transform.position.y, transform.position.z);
        }
        if (transform.position.x == finalTouch.x)
            finalTouch *= 0;
        
    }

    private void _CheckBounds()
    {
        // check right bounds and left bounds
        if (transform.position.x <= -horizontalBounds)
        {
            transform.position = new Vector3(-horizontalBounds, transform.position.y, 0.0f);
        }
        if (transform.position.x >= horizontalBounds)
        {
            transform.position = new Vector3(horizontalBounds, transform.position.y, 0.0f);
        }
    }
}
