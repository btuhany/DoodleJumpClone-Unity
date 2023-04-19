using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatformController : MonoBehaviour
{
    Rigidbody2D _rb;
    EdgeCollider2D _collider;
    private void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
        _collider= GetComponent<EdgeCollider2D>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player");
        if (collision.gameObject.CompareTag("Player"))
        {
            
            _rb.isKinematic = false;
            _collider.isTrigger = true;
        }
    }
}
