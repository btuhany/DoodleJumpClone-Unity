using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    private void Update()
    {
        transform.Translate(new Vector3(0,_moveSpeed * Time.deltaTime,0));
    }
}
