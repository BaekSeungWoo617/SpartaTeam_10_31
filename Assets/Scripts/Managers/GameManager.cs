using System;
using Unity;
public class GameManager : SingletonBase<GameManager>
{
    private int score;
    private int huddleCount;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public int HuddleCount
    {
        get { return huddleCount; }
        set { huddleCount = value; }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void AddHuddleCount(int amount)
    {
        huddleCount += amount;
    }

    public void ResetHuddleCount()
    {
        huddleCount = 0;
    }
    public void ResetGame()
    {
        ResetScore();
        ResetHuddleCount();
    }
}