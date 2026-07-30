using UnityEngine;

public class Room : MonoBehaviour
{
    private float roomSpeed;

    public float destroyX = -20f;

    private bool hasSpawnedNext = false;

    private RoomHandler handler;



    public void SetHandler(RoomHandler roomHandler)
    {
        handler = roomHandler;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - handler.RoomSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (!hasSpawnedNext && transform.position.x < 20f)
        {
            if (handler != null)
            {
                handler.SpawnRoom();

            }

            hasSpawnedNext = true;

        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
