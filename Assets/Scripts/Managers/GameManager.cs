using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    public GameData gameData = new GameData();

    public event Action<int> OnScoreChanged;
    public event Action OnLifeChanged;
    public event Action OnGameOver;

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
        set
        {
            _life = value;
            OnLifeChanged?.Invoke();
            if (_life <= 0)
            {
                Time.timeScale = 0.0f;  // ?쇱떆 ?뺤?
                ResetValue(); // Test Code
                OnGameOver?.Invoke();
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
    
    private void Start()
    {
        _playerLevel = (int)GameLevel.Easy;
        GameStartSettings(_playerLevel);
        Time.timeScale = 1.0f;

        LoadGameData();

    }
    private void Update()
    {

    }
    void OnApplicationQuit()
    {
        //SaveGameData();
    }
    public void GameStartSettings(int level)
    {
        _life = 4 - level;
        _score = 0;
        _huddleCount = 0;
        _roadMoveSpeed = 10f - (level * 2);
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
    void SaveGameData()
    {
        //gameData.userName
        //gameData.

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", json);
        Debug.Log("게임 데이터 저장됨");
    }

    void LoadGameData()
    {
        string path = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("게임 데이터 로드됨");
        }
        else
        {
            Debug.Log("저장된 게임 데이터가 없습니다.");
        }
    }
}