using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _maxMoveSpeed;
    float _leftPoint = -2f;
    float _rightPoint = 2f;
    
    bool _moveToRight;
    SpriteRenderer _sprite;
    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            _leftPoint = Random.Range(LevelGeneratorManager.Instance.MinHorizontalPos, LevelGeneratorManager.Instance.MaxHorizontalPos);
            _rightPoint = Random.Range(_leftPoint, LevelGeneratorManager.Instance.MaxHorizontalPos);
        }
        else
        {
            _rightPoint = Random.Range(LevelGeneratorManager.Instance.MinHorizontalPos, LevelGeneratorManager.Instance.MaxHorizontalPos);
            _leftPoint = Random.Range(LevelGeneratorManager.Instance.MinHorizontalPos, _rightPoint);
        }
        _maxMoveSpeed = Mathf.Abs(_leftPoint-_rightPoint)/Random.Range(1f,5f);
    }
    void Update()
    {
        
        if (_moveToRight)
        {
            transform.Translate(Vector3.right * _maxMoveSpeed * Time.deltaTime);
            if (transform.position.x > _rightPoint)
            {
                _moveToRight = false;
            }
            _sprite.flipX= false;
        }
        else
        {
            transform.Translate(Vector3.left * _maxMoveSpeed * Time.deltaTime);
            if (transform.position.x < _leftPoint)
            {
                _moveToRight = true;
            }
            _sprite.flipX = true;
        }
    }
}
