using System;
using Unity;
public class GameManager : SingletonBase<GameManager>
{
    private int _score;
    private int _huddleCount;
    private int _life;
    private int _highScore;
    public int score
    {
        get { return _score; }
        set { _score = value; }
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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void GameOver()
    {
        if (_score > _highScore) _score = _highScore;
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