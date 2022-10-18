using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public int RoomCap = 8;
    public int Rooms;

    public float waitTime;
    private bool spawnedExit;
    public GameObject Exit;

    void Update()
    {
        if(waitTime <=0 && spawnedExit == false)
        {
            for(int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(Exit, rooms[i].transform.position, Quaternion.identity);
                    spawnedExit = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
