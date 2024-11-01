using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : SingletonBase<GameManager>
{
    enum GameLevel
    {
        Easy,
        Normal,
        Hard
    }
    
    [SerializeField] private int _score;
    [SerializeField] private int _huddleCount;
    [SerializeField] private int _life;
    [SerializeField] private int _highScore;
    [SerializeField] private float _roadMoveSpeed;

    [SerializeField] private int _playerLevel;
    
    public event Action<int> OnScoreChanged;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }
    public int huddleCount
    {
        get { return _huddleCount; }
        set { _huddleCount = value; }
    }
    public int life
    {
        get { return _life; }
        set { _life = value; }
    }
    public float roadMoveSpeed
    {
        get { return _roadMoveSpeed; }
        set { _roadMoveSpeed = value; }
    }
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        // UI 테스트 시에만 활성화하여 사용
        // CreateManager();
    }
    
    private void Start()
    {
        _playerLevel = (int)GameLevel.Easy;
        GameStartSettings(_playerLevel);
    }

    private void CreateManager()
    {
        UIManager UI = UIManager.Instance;
    }
    
    public void GameStartSettings(int level)
    {
        _life = 3 - level;
        _score = 0;
        _huddleCount = 0;
        _roadMoveSpeed = 10f - (level * 2);
    }
    public void GameOver()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
        ResetValue();
    }
    public void ResetValue()
    {
        _score = 0;
        _huddleCount = 0;
        _life = 5;
    }
    public void AddScore(int value)
    {
        _score += value;
    }
    public void AddHuddleCount(int value)
    {
        _huddleCount += value;
    }
    public void AddLife(int value)
    {
        _life += value;
    }
}