using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    enum GameLevel
    {
        Easy = 1,
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
    public event Action OnLifeChanged;
    public event Action OnGameOver;

    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
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
        set
        {
            _life = value;
            OnLifeChanged?.Invoke();
            if (_life <= 0)
            {
                Time.timeScale = 0.0f;  // 일시 정지
                OnGameOver?.Invoke();
                // ResetValue(); // Test Code

            }
        }
    }

    public int highScore
    {
        get { return _highScore; }
    }

    public float roadMoveSpeed
    {
        get { return _roadMoveSpeed; }
        set { _roadMoveSpeed = value; }
    }

    public int playerLevel
    {
        get { return _playerLevel; }
        set { _playerLevel = value; }
    }
    
    protected override void Awake()
    {
        base.Awake();
        // RoadManager roadManager = RoadManager.Instance;
        // roadManager.transform.parent = this.transform;
        // BuildingManager buildingManager = BuildingManager.Instance;
        // buildingManager.transform.parent = this.transform;
        // ObstacleManager obstacleManager = ObstacleManager.Instance;
        // obstacleManager.transform.parent = this.transform;
        DontDestroyOnLoad(gameObject);
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Start()
    {
        _playerLevel = (int)GameLevel.Easy;
        //GameStartSettings(_playerLevel);
        GameStartSettings();

        Debug.Log("Start");
    }
    private void Update()
    {
        Debug.Log(_score);
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    
   // public void GameStartSettings(int level)
    public void GameStartSettings()
    {
        int level = 1;
        _life = 4 - level;
        Debug.Log(_life);
        _score = 0;
        _huddleCount = 0;
        _roadMoveSpeed = 10f - (level * 2);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;

        // Comment For UI Test
        // if (_score > _highScore)
        // {
        //     _highScore = _score;
        // }
        // ResetValue();
    }

    public void ResetValue()
    {
        // For UI Test
        _score = 0;
        _huddleCount = 0;
        _life = 4 - _playerLevel;
    }

    public void AddScore(int value)
    {
        _score += value;
        if (_score > _highScore)
        {
            _highScore = _score;
        }
        OnScoreChanged?.Invoke(_score);
    }

    public void AddHuddleCount(int value)
    {
        _huddleCount += value;
        AddScore(value);
    }

    public void AddLife(int value)
    {
        _life += value;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded");
        GameStartSettings();
    }
}