using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 -> dolne
    //2 -> gorne
    //3 -> lewe
    //4 -> prawe

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime = 2f;
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
        
    }
    private void Spawn()
    {
        if(spawned == false && templates.RoomCap >= templates.Rooms)
        {
            if (openingDirection == 1)
            {
                //Stworz pokoj z dolnymi drzwiami
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                templates.Rooms++;
            }
            else if (openingDirection == 2)
            {
                //Stworz pokoj z gornymi drzwiami
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                templates.Rooms++;
            }
            else if (openingDirection == 3)
            {
                //Stworz pokoj z lewymi drzwiami
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                templates.Rooms++;
            }
            else if (openingDirection == 4)
            {
                //Stworz pokoj z prawymi drzwiami
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                templates.Rooms++;
            }
            spawned = true;
        }
        else if (spawned == false && templates.RoomCap <= templates.Rooms)
        {
            if(openingDirection == 1)
            {
                rand = Random.Range(0, 2);
                if(rand == 0)
                {
                    Instantiate(templates.bottomRooms[1], transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(templates.bottomRooms[2], transform.position, Quaternion.identity);
                }
            }
            if (openingDirection == 2)
            {
                Instantiate(templates.topRooms[1], transform.position, Quaternion.identity);
            }
            if (openingDirection == 3)
            {
                Instantiate(templates.leftRooms[1], transform.position, Quaternion.identity);
            }
            if (openingDirection == 4)
            {
                Instantiate(templates.rightRooms[1], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
        Debug.Log(templates.Rooms + " " + templates.RoomCap);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
