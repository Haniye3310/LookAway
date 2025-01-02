using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataRepo : MonoBehaviour
{
    public List<PlayerData> Players;
    [NonSerialized] public bool CouldPlayerEnterInput;
    public FixedJoystick Joystick;
    [NonSerialized] public int NumberOfRound= 5;
    public TextMeshProUGUI ResultText;
    public GameObject ResultPanel;
}
[Serializable]
public class PlayerData
{
    public GameObject PlayerGameobject;
    public bool IsKing;
    public bool IsUser;
    public Animator Animator;
    [NonSerialized]public Vector2 HeadDirection;
    [NonSerialized]public Direction PlayerDirection;
    [NonSerialized]public int NumberOfMistake = 0;
    public List<Image> Crosses;
}
public enum Direction
{
    Left = 0, 
    Right = 1, 
    Up = 2,
    Down = 3,
    Forward = 4
}