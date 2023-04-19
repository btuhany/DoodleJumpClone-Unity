using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _jumpForce = 200f;
    [SerializeField] float _jumpBoostMultiplier = 2.4f;
    [SerializeField] float _horizontalSpeed = 3f;
    float _horizontalAxis;
    bool _isAttack;
    RbMovement _movement;
    CharacterFlipHandler _flip;

    AttackController _attack;
    private void Awake()
    {
        _movement = new RbMovement(GetComponent<Rigidbody2D>());
        _flip = new CharacterFlipHandler(GetComponentInChildren<SpriteRenderer>());
        _attack = GetComponent<AttackController>();

    }

    // Update is called once per frame
    void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _attack.FireProjectile();
        }
        _flip.FlipCharacter(_horizontalAxis);
        
        
    }
    private void FixedUpdate()
    {
        _movement.HorizontalMovement(_horizontalSpeed * _horizontalAxis);
        if(transform.position.x>2.9)
        {
            transform.position = new Vector2(-2.89f, transform.position.y);
        }
        else if(transform.position.x < -2.9)
        {
            transform.position = new Vector2(2.89f, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (_movement.Velocity.y<=0.1f)
        {
            if (collision.gameObject.CompareTag("JumpBoost"))
            {
                _movement.VerticalForce(_jumpForce * _jumpBoostMultiplier);
            }
            else if (collision.gameObject.CompareTag("SafePlatform"))
            {
                _movement.VerticalForce(_jumpForce);
            }
            


        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UnsafePlatform") && _movement.Velocity.y <= 0.1f)
        {
            collision.gameObject.GetComponent<FragilePlatformController>().Fall();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
        }
    }

}
