using UnityEngine;
using System.Collections.Generic;

public class RoomHandler : MonoBehaviour
{
    public List<GameObject> roomPrefabs;

    public List<GameObject> startHigh;
    public List<GameObject> startMid;
    public List<GameObject> startLow;

    public List<GameObject> endHigh;
    public List<GameObject> endMid;
    public List<GameObject> endLow;

    private GameObject previousRoom;

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
        if (endHigh.Contains(previousRoom))
        {
            Debug.Log("Previous Room: " + previousRoom);
        }

        Debug.Log("RoomPrefabs: " + roomPrefabs.Count + " High: " + startHigh.Count + " Mid: " + startMid.Count + " Low: " + startLow.Count + " High: " + endHigh.Count + " Mid: " + endMid.Count + " Low: " +endLow.Count);

        Debug.Log("Is previous room in endHigh: " + endHigh.Contains(previousRoom));
        Debug.Log("Is previous room in endMid: " + endMid.Contains(previousRoom));
        Debug.Log("Is previous room in endLow: " + endLow.Contains(previousRoom));

        GameObject chosenRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
        if (chosenRoom == null)
        {
            Debug.LogError("No valid room found for this connection");
            return;
        }

        if (lastRoom == null)
        {
            chosenRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
        }
        else
        {
            if (endHigh.Contains(previousRoom))
            {
                chosenRoom = startHigh[Random.Range(0, startHigh.Count)];
            }
            else if (endMid.Contains(previousRoom))
            {
                chosenRoom = startMid[Random.Range(0, startMid.Count)];
            }
            else if (endLow.Contains(previousRoom))
            {
                chosenRoom = startLow[Random.Range(0, startLow.Count)];
            }
        }

        GameObject newRoom;

        Debug.Log("Spawned: " + chosenRoom.name);

        if(lastRoom == null)
        {
            newRoom = Instantiate(chosenRoom, new Vector3(14,0,1), Quaternion.identity);
        }
        else
        {

            newRoom = Instantiate(chosenRoom, new Vector3(nextSpawnX, 0, 1), Quaternion.identity);
        }



        Room room = newRoom.GetComponent<Room>();

        Debug.Log("Got Room component: " + room);

        room.SetSpeed(roomSpeed);
        room.SetHandler(this);

        Debug.Log("Handler assigned to: " + newRoom.name);

        previousRoom = chosenRoom;

        lastRoom = room;

        nextSpawnX += roomWidth;
    }
}
