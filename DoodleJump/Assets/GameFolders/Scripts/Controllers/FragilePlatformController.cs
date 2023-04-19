using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatformController : MonoBehaviour
{
    
    [SerializeField] float _destroyDelay = 2f;
    Rigidbody2D _rb;
    EdgeCollider2D _collider;
    private void Awake()
    {
        _rb= GetComponent<Rigidbody2D>();
        _collider= GetComponent<EdgeCollider2D>();
        
    }
    public void Fall()
    {
        _rb.isKinematic = false;
        _rb.velocity = Vector3.down * 10f;
        _collider.isTrigger = true;
        Destroy(this.gameObject, _destroyDelay);
    }


}
