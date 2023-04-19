using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ProjectileObjectPoolManager : MonoBehaviour
{
    [SerializeField] ProjectileController _projectilePrefab;
    [SerializeField] int _poolSize = 15;
    Queue<ProjectileController> _projectileQueue = new Queue<ProjectileController>();
    public static ProjectileObjectPoolManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitializePool();
    }
    void InitializePool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            ProjectileController newProjectile = Instantiate(_projectilePrefab);
            newProjectile.transform.SetParent(transform);
            newProjectile.gameObject.SetActive(false);
            _projectileQueue.Enqueue(newProjectile);
            
        }
    }
    public GameObject GetProjectileFromPool()
    {

        if (_projectileQueue.Count<=0)
            IncreaseThePoolSize();
        ProjectileController projectile = _projectileQueue.Dequeue();
        projectile.gameObject.SetActive(true);
        projectile.transform.SetParent(null);
        return projectile.gameObject;
    }
    public void SetToPool(ProjectileController projectile)
    {
   
        projectile.transform.SetParent(transform);
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(false);
        _projectileQueue.Enqueue(projectile);
    }
    void IncreaseThePoolSize()
    {
        for (int i = 0; i < 3; i++)
        {
            ProjectileController newProjectile = Instantiate(_projectilePrefab);
            newProjectile.transform.SetParent(transform);
            newProjectile.gameObject.SetActive(false);
            _projectileQueue.Enqueue(newProjectile);

        }
    }
}
