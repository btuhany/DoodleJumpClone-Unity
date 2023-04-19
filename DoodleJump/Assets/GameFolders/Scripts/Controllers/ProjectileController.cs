using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _maxDeathTime = 1.5f;
    
    Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _rb.velocity = Vector3.zero;
        _rb.velocity = (new Vector3(0, _moveSpeed, 0));
        StartCoroutine(SetThePoolAfterDelay());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            StopAllCoroutines();
            ProjectileObjectPoolManager.Instance.SetToPool(this);
        }
    }
    IEnumerator SetThePoolAfterDelay()
    {
        yield return new WaitForSeconds(_maxDeathTime);
        ProjectileObjectPoolManager.Instance.SetToPool(this);
        yield return null;
    }
}
