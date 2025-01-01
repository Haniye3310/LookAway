using System;
using System.Collections.Generic;
using UnityEngine;

public class DataRepo : MonoBehaviour
{
    public List<PlayerData> Players;
    [NonSerialized] public bool CouldPlayerEnterInput;
    public FixedJoystick Joystick;
}
[Serializable]
public class PlayerData
{
    public GameObject PlayerGameobject;
    public bool IsKing;
    public bool IsUser;
    public Animator Animator;
    [NonSerialized]public Direction PlayerDirection;
    [NonSerialized]public int NumberOfMistake = 0;
}
public enum Direction
{
    Left = 0, 
    Right = 1, 
    Up = 2,
    Down = 3,
    Forward = 4
}