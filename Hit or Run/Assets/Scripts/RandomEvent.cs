using UnityEngine;
using System.Collections;


public class RandomEvent : MonoBehaviour {

    public static void executeRandomEvent()
    {
        int eventNum = (int)Random.Range(1, 1);
        switch(eventNum)
        {
            case 1:
                {
                    //Trigger DisableEvent
                    Debug.Log("DisableEvent Triggered!");
                    DisableEvent.executeEvent();
                    break;
                }
                /*
            case 2:
                {
                    //Trigger ReinforceEvent
                    Debug.Log("ReinforceEvent Triggered!");
                    break;
                }
            case 3:
                {
                    //Trigger DoorLockEvent
                    Debug.Log("DoorLockEvent Triggered!");
                    break;
                }
            case 4:
                {
                    //Nothing happens
                    break;
                }
                 * */
        }
    }
}

public class DisableEvent : MonoBehaviour
{
    public static void executeEvent()
    {
        int disableNum = (int)Random.Range(1, 3);
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        switch (disableNum)
        {
            case 1:
                {
                    Debug.Log("Punch Disabled!");
                    player.canPunch = false;
                    break;
                }
            case 2:
                {
                    Debug.Log("Throw Disabled!");
                    player.canThrow = false;
                    break;
                }
            case 3:
                {
                    Debug.Log("Shoot Disabled");
                    player.canShoot = false;
                    break;
                }
            default:
                {
                    Debug.Log("Nothing Happened");
                    break;
                }
        }
    }
}

public class ReinforceEvent
{
    public static void executeEvent()
    {
        //Add random number of enemies back into the level
    }
}

public class DoorLockEvent
{
    public static void executeEvent()
    {
        //Lock a certain door
    }
}