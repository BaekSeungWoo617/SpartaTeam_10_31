using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Playables;
public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private int _score;
    [SerializeField] private int _life;
    [SerializeField] private int _highScore;
    [SerializeField] private float _roadMoveSpeed;

    [SerializeField] private int _playerLevel;

    private float _powerTime = 0.0f;

    private bool _isPower = false;
    public bool IsPower
    {
        get { return _isPower; }
        set { _isPower = value; }
    }

    private float _powerGauge = 0.0f;

    public float GetPowerGauge()
    {
        return _powerGauge;
    }

    public void FillPowerGauge()
    {
        if(_powerGauge < 1.0f && !IsPower)
            _powerGauge += UnityEngine.Random.Range(0.01f, 0.03f) * Time.deltaTime;
    }

    public void SetPowered()
    {
        IsPower = true;
        _powerTime = 3.0f;
        _powerGauge = 0.0f;
    }
    
    public event Action<int> OnScoreChanged;
    public event Action OnLifeChanged;
    public event Action OnGameOver;

    public GameData gameData = new GameData();
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
        }
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
                GameOver();
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
        DontDestroyOnLoad(gameObject);
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Start()
    {
        LoadGameData();
        GameStartSettings();
    }
    private void Update()
    {
        FillPowerGauge();
        _powerTime -= Time.deltaTime;
        if (_powerTime <= 0.0f)
        {
            IsPower = false;
        }       
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    void OnApplicationQuit()
    {
        //SaveGameData();
    }
    public void GameStartSettings()
    {
        _life = 4 - _playerLevel;
        _score = 0;
        _roadMoveSpeed = 10f + (_playerLevel * 5);
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;  // 일시 정지
        OnGameOver?.Invoke();
    }

    public void AddScore(int value)
    {
        _score += value * _playerLevel;
        if (_score > _highScore)
        {
            _highScore = _score;
        }
        OnScoreChanged?.Invoke(_score);
    }

    public void AddLife(int value)
    {
        _life += value;
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameStartSettings();
    }
    void SaveGameData()
    {
        //ToDO : 업적 데이터

        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", json);
        Debug.Log("게임 저장됨");
    }
    void LoadGameData()
    {
        string path = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("게임 로드됨");
        }
        else
        {
            Debug.Log("로드 실패");
        }
    }
}