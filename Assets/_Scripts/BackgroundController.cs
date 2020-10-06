using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(0.0f, verticalBounds, 0.0f);
    }

    private void _Move()
    {
        transform.position += new Vector3(0.0f, -verticalSpeed, 0.0f);
    }

    private void _CheckBounds()
    {
        // check if the background is at the bottom of the screen
        // reset if true
        if (transform.position.y <= -verticalBounds)
        {
            _Reset();
        }
    }
}
