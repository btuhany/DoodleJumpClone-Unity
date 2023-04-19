using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Score;
    bool _isGameOver;
    public static GameManager Instance { get; private set; }
    public event System.Action OnScoreChanged;
    private void Awake()
    {
        Instance= this;
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _isGameOver = true;
    }
    public void IncreaseScore(float value)
    {
        if(_isGameOver) { return; }
        Score += value;
        OnScoreChanged?.Invoke();
    }
}
