using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HuddleSO", menuName = "ScriptableObjects/HuddleSO", order = 0)]
public class HuddleSO : ScriptableObject
{
    public string dataName;
    public int dataScore;
    public int dataSpeedAdd;
}
