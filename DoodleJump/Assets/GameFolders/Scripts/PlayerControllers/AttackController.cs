using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _projectileSpawnTransform;
    [SerializeField] [Range(0,0.8f)] float _coolDown;
    bool _canShoot = true;
    AnimationController _anim;
    private void Awake()
    {
        _anim = new AnimationController(GetComponent<Animator>());
    }
    public void FireProjectile()
    {
        if (_canShoot)
        {
            GameObject projectile = ProjectileObjectPoolManager.Instance.GetProjectileFromPool();
            projectile.transform.position = _projectileSpawnTransform.position;
            StartCoroutine(FireCooldown());
            _anim.AttackAnim();
        }
    }

    IEnumerator FireCooldown()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_coolDown); 
        _canShoot = true;
        yield return null;
    }
}
