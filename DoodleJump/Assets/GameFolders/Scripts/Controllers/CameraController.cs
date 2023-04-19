using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _followLerpSpeed;
    [SerializeField] Transform _player;

    float _offset;
    bool _isTransition;
    private void Start()
    {
        _offset = transform.position.y - _player.position.y;
    }
    private void LateUpdate()
    {
        if (transform.position.y < _player.position.y + _offset)
        {
          
            Vector3 newPos = new Vector3(transform.position.x, _player.position.y + _offset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, _followLerpSpeed * Time.fixedDeltaTime);
            GameManager.Instance.IncreaseScore(0.5f);
            
        }

    }
}
