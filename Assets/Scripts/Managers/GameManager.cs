using System;
using Unity;
public class GameManager : SingletonBase<GameManager>
{
    private int _score;
    private int _huddleCount;
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
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(int amount)
    {
        _score += amount;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    public void AddHuddleCount(int amount)
    {
        _huddleCount += amount;
    }

    public void ResetHuddleCount()
    {
        _huddleCount = 0;
    }
    public void ResetGame()
    {
        ResetScore();
        ResetHuddleCount();
    }
}