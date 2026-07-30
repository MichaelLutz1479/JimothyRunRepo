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

    float roomSpeed = 2.5f;
    public float roomWidth = 10f;

    private Room lastRoom;

    float nextSpawnX = 14f;

    public float RoomSpeed => roomSpeed;



    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnRoom();
        }
    }

    void Update()
    {
        nextSpawnX -= roomSpeed * Time.deltaTime;
        roomSpeed += Time.deltaTime * 0.02f;
    }

    public void SpawnRoom()
    {
        GameObject chosenRoom = roomPrefabs[Random.Range(0, roomPrefabs.Count)];

        if (lastRoom == null)
        {
            chosenRoom = startLow[Random.Range(0, startLow.Count)];
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


        if (lastRoom == null)
        {
            newRoom = Instantiate(chosenRoom, new Vector3(14, 0, 1), Quaternion.identity);
        }
        else
        {

            newRoom = Instantiate(chosenRoom, new Vector3(nextSpawnX, 0, 1), Quaternion.identity);
        }



        Room room = newRoom.GetComponent<Room>();

        room.SetHandler(this);

        previousRoom = chosenRoom;

        lastRoom = room;

        nextSpawnX += roomWidth;
    }
}