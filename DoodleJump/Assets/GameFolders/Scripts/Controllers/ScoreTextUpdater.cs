using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTextUpdater : MonoBehaviour
{
    TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        GameManager.Instance.OnScoreChanged += HandleOnScoreChanged;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= HandleOnScoreChanged;
    }
    public void HandleOnScoreChanged()
    {
        _text.SetText("Score: " + (int)GameManager.Instance.Score);
    }
}
