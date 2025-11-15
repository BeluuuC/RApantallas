using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClockData", menuName = "Clock Data")]
public class ClockData : ScriptableObject
{
    public float timeClock;
    public bool isEnd;
    public bool yaInicio;
}