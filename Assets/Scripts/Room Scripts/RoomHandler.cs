using UnityEngine;
using System.Collections.Generic;

public class RoomHandler : MonoBehaviour
{
    public List<GameObject> roomPrefabs;

    public float roomSpeed = 5f;
    public float roomWidth = 10f;

    private Room lastRoom;

    float nextSpawnX = 14f;


    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnRoom();
        }
    }

    void Update()
    {
        nextSpawnX -= roomSpeed * Time.deltaTime;
    }

    public void SpawnRoom()
    {
        GameObject chosenRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];

        GameObject newRoom;

        if(lastRoom == null)
        {
            newRoom = Instantiate(chosenRoom, new Vector3(14,0,1), Quaternion.identity);
        }
        else
        {
            newRoom = Instantiate(chosenRoom, new Vector3(nextSpawnX, 0, 1), Quaternion.identity);
        }



        Room room = newRoom.GetComponent<Room>();

        room.SetSpeed(roomSpeed);
        room.SetHandler(this);
        lastRoom = room;

        nextSpawnX += roomWidth;
    }
}
