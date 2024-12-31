using System;
using System.Collections.Generic;
using UnityEngine;

public class DataRepo : MonoBehaviour
{
    public List<PlayerData> Players;
}
[Serializable]
public class PlayerData
{
    public GameObject PlayerGameobject;
    public bool IsKing;
    public bool IsUser;
    public Animator Animator;
    public Direction PlayerDirection;
}
public enum Direction
{
    Left = 0, 
    Right = 1, 
    Up = 2,
    Down = 3,
}