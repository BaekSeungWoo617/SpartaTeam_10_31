using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBase<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    
}
