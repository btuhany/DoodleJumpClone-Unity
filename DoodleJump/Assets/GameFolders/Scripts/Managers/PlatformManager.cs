using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { get; private set; }
    public float MaxHorizontalPos { get => _maxHorizontalPos;  }
    public float MinHorizontalPos { get => _minHorizontalPos; }

    [SerializeField] GameObject _platformPrefab;
    [SerializeField] GameObject _jumpBoostPrefab;
    [SerializeField] GameObject _mobilePlatformPrefab;
    [SerializeField] [Range(0,1)] float _jumpBoostSpawnProb = 0.1f;
    [SerializeField][Range(0, 1)] float _mobilePlatformSpawnProb = 0.2f;
    [SerializeField] int platformCount;
    [SerializeField] float _maxHorizontalPos, _minHorizontalPos;
    [SerializeField] float _maxVerticalDistance, _minVerticalDistance;
    [SerializeField] float _firstPlatformHeight;
    private void Awake()
    {
        Instance= this;
    }
    private void Start()
    {
        Vector3 newPlatformPos = new Vector3(Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f), _firstPlatformHeight);
        Instantiate(_platformPrefab, newPlatformPos, this.transform.rotation);
        for (int i = 0; i < platformCount-1; i++)
        {
            newPlatformPos.x = Random.Range(_minHorizontalPos, _maxHorizontalPos + 0.005f);
            
            if(i>170)
            {
                newPlatformPos.y += _maxVerticalDistance;
            }
            else if(i>130)
            {
                newPlatformPos.y += Random.Range(_maxVerticalDistance / 1.3f, _maxVerticalDistance + 0.005f);
            }
            else if(i>80)
            {
                newPlatformPos.y += Random.Range(_maxVerticalDistance / 2f, _maxVerticalDistance + 0.005f);
            }
            else if(i>50)
            {
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
                    GameObject gameObj = Instantiate(_jumpBoostPrefab, newPlatformPos + new Vector3(0, 0.25f, 0), this.transform.rotation);
                    gameObj.transform.SetParent(this.transform);
                }
            }


        }
    }
}
