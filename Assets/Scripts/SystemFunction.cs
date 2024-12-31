using System.Collections;
using System.Linq;
using UnityEngine;

public class SystemFunction
{
    public static void Start(DataRepo dataRepo)
    {
        
    }

    public static void Update(DataRepo dataRepo)
    {
        
    }
    public static IEnumerator Round(DataRepo dataRepo)
    {
        // play music and shake their heads and wait for the lights
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 3; i++)
        {
            SelectDirection();
            yield return new WaitForSeconds(1);
            //turn on lights
        }
        for (int i = 0; i < dataRepo.Players.Count; i++)
        {
            if (dataRepo.Players[i].IsUser)
            {

            }
        }
    }
    public static void SelectDirection()
    {
        int r = Random.Range(0, 4);
        if ((Direction)r == Direction.Left) 
        {
            // Set animator to left 
            //set player diection 
        }
        if ((Direction)r == Direction.Right) { }
        if ((Direction)r == Direction.Up) { }
        if ((Direction)r == Direction.Down) { }


    }
}
