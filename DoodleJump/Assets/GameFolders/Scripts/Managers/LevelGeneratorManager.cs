using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorManager : MonoBehaviour
{
    public static LevelGeneratorManager Instance { get; private set; }
    public float MaxHorizontalPos { get => _maxHorizontalPos;  }
    public float MinHorizontalPos { get => _minHorizontalPos; }

    [Header("Prefabs")]
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] GameObject _jumpBoostPrefab;
    [SerializeField] GameObject _mobilePlatformPrefab;
    [SerializeField] GameObject _fragilePlatformPrefab;
    [SerializeField] GameObject _enemyPrefab;
    [Header("SpawnProbs")]
    [SerializeField] [Range(0,1)] float _jumpBoostSpawnProb = 0.1f;
    [SerializeField][Range(0, 1)] float _mobilePlatformSpawnProb = 0.2f;
    [SerializeField][Range(0, 1)] float _fragilePlatformSpawnProb = 0.2f;
    [SerializeField][Range(0, 1)] float _enemySpawnProb = 0.76f;
    [Header("Settings")]
    [SerializeField] int platformCount;
    [SerializeField] float _maxHorizontalPos, _minHorizontalPos;
    [SerializeField] float _maxVerticalDistance, _minVerticalDistance;
    [SerializeField] float _firstPlatformHeight;
    [SerializeField] int _minPlatformCountForEnemySpawn = 15;
    float _startVerticalDistance;
    private void Awake()
    {
        Instance= this;
        _startVerticalDistance = _maxVerticalDistance;
    }
    private void Start()
    {
        Vector3 newPlatformPos = new Vector3(Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f), _firstPlatformHeight);
        Vector3 lastPlatformPos;
        Instantiate(_platformPrefab, newPlatformPos, this.transform.rotation);
        for (int i = 0; i < platformCount-1; i++)
        {
            lastPlatformPos = newPlatformPos;
            newPlatformPos.x = Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f);


            if(i> platformCount* 0.85f)
            {
                _maxVerticalDistance = _startVerticalDistance * 2.9f;
                newPlatformPos.y += _maxVerticalDistance;
                _mobilePlatformSpawnProb = 0.5f;
                _enemySpawnProb = 1f;
            }
            else if(i> platformCount * 0.65f)
            {
                
                _maxVerticalDistance = _startVerticalDistance * 2.4f;
                newPlatformPos.y += Random.Range(_maxVerticalDistance / 1.3f, _maxVerticalDistance + 0.005f);
            }
            else if(i> platformCount * 0.42f)
            {
                _mobilePlatformSpawnProb = 0.3f;
                _maxVerticalDistance = _startVerticalDistance * 2f;
                newPlatformPos.y += Random.Range(_maxVerticalDistance / 2f, _maxVerticalDistance + 0.005f);
            }
            else if(i> platformCount*0.27f)
            {
                _maxVerticalDistance = _startVerticalDistance * 1.5f;
                newPlatformPos.y += Random.Range(_maxVerticalDistance/3f, _maxVerticalDistance + 0.005f);
            }
            else
            {
                newPlatformPos.y += Random.Range(_minVerticalDistance, _maxVerticalDistance + 0.005f);
            }

            if(Random.Range(0,100)<100*_mobilePlatformSpawnProb)
            {
                GameObject newPlatform = Instantiate(_mobilePlatformPrefab, newPlatformPos, this.transform.rotation);
                newPlatform.transform.SetParent(this.transform);
            }
            else
            {
                GameObject newPlatform = Instantiate(_platformPrefab, newPlatformPos, this.transform.rotation);
                newPlatform.transform.SetParent(this.transform);

                if (Random.Range(0, 100) < 100 * _jumpBoostSpawnProb)
                {
                    GameObject gameObj = Instantiate(_jumpBoostPrefab, newPlatformPos + new Vector3(0, 0.17f, 0), this.transform.rotation);
                    gameObj.transform.SetParent(this.transform);
                }
            }

            if(newPlatformPos.y - lastPlatformPos.y > _minVerticalDistance * 2.01f) 
            {
                if (Random.Range(0, 100) < 100 * _fragilePlatformSpawnProb)
                {
                    Vector3 fragilePlatformPos = new Vector3();
                    fragilePlatformPos.x = Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f);

                    fragilePlatformPos.y = Random.Range(lastPlatformPos.y + _minVerticalDistance * 0.95f, newPlatformPos.y - _minVerticalDistance * 0.95f);
                    Instantiate(_fragilePlatformPrefab, fragilePlatformPos, this.transform.rotation).transform.SetParent(transform);

                }
                else if (Random.Range(0, 100) < 100 * _enemySpawnProb && i > _minPlatformCountForEnemySpawn && newPlatformPos.y - lastPlatformPos.y > _minVerticalDistance * 4f)
                {
                    Vector3 enemyPos = new Vector3();
                    enemyPos.x = Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f);

                    enemyPos.y = Random.Range(lastPlatformPos.y + _minVerticalDistance * 1.95f, newPlatformPos.y - _minVerticalDistance * 1.95f);
                    Instantiate(_enemyPrefab, enemyPos, this.transform.rotation).transform.SetParent(transform);
                }

            }


        }
    }
}
