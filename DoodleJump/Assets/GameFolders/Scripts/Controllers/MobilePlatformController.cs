using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatformController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _offset;
    // Update is called once per frame
    bool _moveToRight;
    void Update()
    {

        if(_moveToRight)
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
            if (transform.position.x > LevelGeneratorManager.Instance.MaxHorizontalPos - _offset)
            {
                _moveToRight= false;
            }

        }
        else
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
            if (transform.position.x < LevelGeneratorManager.Instance.MinHorizontalPos + _offset)
            {
                _moveToRight = true;
            }
        }
    }
}
