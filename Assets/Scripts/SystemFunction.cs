using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SystemFunction
{
    public static void Start(MonoBehaviour mono,DataRepo dataRepo)
    {
        mono.StartCoroutine( Round(mono,dataRepo));
    }

    public static void Update(DataRepo dataRepo)
    {
        if (dataRepo.CouldPlayerEnterInput)
        {
            PlayerData userData = null;
            foreach(PlayerData p in dataRepo.Players)
            {
                if (p.IsUser)
                {
                    userData = p;
                }
            }


            Vector2 joyStickDot= new Vector2(-dataRepo.Joystick.Horizontal,dataRepo.Joystick.Vertical);


            float distanceToLeft = Vector2.Distance(joyStickDot, new Vector2(-1, 0));
            float distanceToRight = Vector2.Distance(joyStickDot, new Vector2(1, 0));
            float distanceToUp = Vector2.Distance(joyStickDot, new Vector2(0, 1));
            float distanceToDown = Vector2.Distance(joyStickDot, new Vector2(0, -1));
            float distanceToForward = Vector2.Distance(joyStickDot, new Vector2(0, 0));


            float min = Mathf.Min(
            distanceToLeft,
            distanceToRight,
            distanceToUp,
            distanceToDown,
            distanceToForward);

            if (Mathf.Abs(min - distanceToLeft) < 0.1) 
            {
                userData.HeadDirection = new Vector2(-1, 0);
                userData.PlayerDirection = Direction.Left;
            }
            if(Mathf.Abs(min - distanceToRight) < 0.1) 
            {
                userData.HeadDirection = new Vector2(1, 0);
                userData.PlayerDirection = Direction.Right;
            }
            if(Mathf.Abs(min - distanceToUp) < 0.1) 
            {
                userData.HeadDirection = new Vector2(0, 1);
                userData.PlayerDirection = Direction.Up;
            }
            if(Mathf.Abs(min - distanceToDown) < 0.1) 
            {
                userData.HeadDirection = new Vector2(0, -1);
                userData.PlayerDirection = Direction.Down;
            }
            if(Mathf.Abs(min - distanceToForward) < 0.1)
            {
                userData.HeadDirection = new Vector2(0, 0);
                userData.PlayerDirection = Direction.Forward;
            }
        }

        for(int i =0; i < dataRepo.Players.Count; i++)
        {
            PlayerData p = dataRepo.Players[i];

            Vector2 currentDirection = new Vector2(
                p.Animator.GetFloat("X"),
                p.Animator.GetFloat("Y")
                );

            if (Vector2.Distance(currentDirection, p.HeadDirection) > 0.01)
            {
                p.Animator.SetFloat("X",Mathf.Lerp(currentDirection.x,p.HeadDirection.x,Time.deltaTime*10));
                p.Animator.SetFloat("Y",Mathf.Lerp(currentDirection.y,p.HeadDirection.y,Time.deltaTime*10));
            }
        }
    }
    public static IEnumerator Round(MonoBehaviour mono,DataRepo dataRepo)
    {
        yield return new WaitForSeconds(3);
        dataRepo.CouldPlayerEnterInput = true;
        for (int i = 0; i < 3; i++)
        {
            foreach (PlayerData playerData in dataRepo.Players)
            {
                if(!playerData.IsUser)
                    SelectDirectionRandomly(playerData);
            }
            yield return new WaitForSeconds(1);
        }
        dataRepo.CouldPlayerEnterInput = false;
        Direction kingFinalDirection = Direction.Forward;
        foreach(PlayerData player in dataRepo.Players)
        {
            if (player.IsKing)
            {
                kingFinalDirection = player.PlayerDirection;
            }
        }
        foreach(PlayerData player in dataRepo.Players)
        {
            if (!player.IsKing)
            {
                if(player.PlayerDirection == kingFinalDirection)
                {
                    player.NumberOfMistake++;
                    for (int i = 0;i < player.Crosses.Count; i++)
                    {
                        if (!player.Crosses[i].gameObject.activeSelf)
                        {
                            player.Crosses[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
            }
        }
        foreach(PlayerData player in dataRepo.Players)
        {
            player.PlayerDirection = Direction.Forward;
            player.HeadDirection = new Vector2(0, 0);
        }
        dataRepo.NumberOfRound--;
        if (dataRepo.NumberOfRound == 0)
        {
            PlayerData playerWithMinMistakes = null;
            int minMistakes = int.MaxValue; // Start with the maximum possible integer value.

            for (int i = 0; i < dataRepo.Players.Count; i++)
            {
                if (!dataRepo.Players[i].IsKing && dataRepo.Players[i].NumberOfMistake < minMistakes)
                {
                    minMistakes = dataRepo.Players[i].NumberOfMistake;
                    playerWithMinMistakes = dataRepo.Players[i];
                }
            }
            dataRepo.ResultPanel.SetActive(true);
            dataRepo.ResultText.text = playerWithMinMistakes.PlayerGameobject.name+" won!";
            yield break;
        }
        mono.StartCoroutine(Round(mono, dataRepo));
    }
    public static void SelectDirectionRandomly(PlayerData playerData)
    {
        //Random.InitState(System.DateTime.Now.Millisecond);
        int r = Random.Range(0, 5);
        if ((Direction)r == Direction.Left) 
        {
            playerData.HeadDirection = new Vector2(-1, 0);
            playerData.PlayerDirection= Direction.Left;
        }
        if ((Direction)r == Direction.Right) 
        {
            playerData.HeadDirection = new Vector2(1, 0);
            playerData.PlayerDirection = Direction.Right;
        }
        if ((Direction)r == Direction.Up) 
        {
            playerData.HeadDirection = new Vector2(0, 1);;
            playerData.PlayerDirection = Direction.Up;
        }
        if ((Direction)r == Direction.Down) 
        {
            playerData.HeadDirection = new Vector2(0, -1);
            playerData.PlayerDirection = Direction.Down;
        }
        if ((Direction)r == Direction.Forward)
        {
            playerData.HeadDirection = new Vector2(0, 0);
            playerData.PlayerDirection = Direction.Forward;
        }

    }
}
