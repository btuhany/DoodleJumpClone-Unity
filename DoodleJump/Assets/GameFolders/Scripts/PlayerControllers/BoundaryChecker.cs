using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryChecker : MonoBehaviour
{
    Rigidbody2D _rb;
    void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x > 2.9)
        {
            _rb.position = new Vector2(-2.89f, transform.position.y);
        }
        else if (transform.position.x < -2.9)
        {
            _rb.position = new Vector2(2.89f, transform.position.y);
        }
    }
}
