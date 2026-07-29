using UnityEngine;

public class Room : MonoBehaviour
{
    private float roomSpeed;

    public float destroyX = -20f;

    private bool hasSpawnedNext = false;

    private RoomHandler handler;



    public void SetHandler(RoomHandler roomHandler)
    {
            Debug.Log("========== SET HANDLER HIT =========");
            handler = roomHandler;
            Debug.Log(gameObject.name + " assigned handler AFTER SET: " + handler);
            Debug.Log(gameObject.name + " receieved handler");

    }

    public void SetSpeed(float speed)
    {
        roomSpeed = speed;
    }

    void Update()
    {
        Debug.Log("========== UPDATE HIT =========");

        transform.position = new Vector3(transform.position.x - roomSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        Debug.Log(gameObject.name + " assigned handler UPDATE: " + handler);

        if (!hasSpawnedNext && transform.position.x < 20f)
        {
            if (handler != null)
            {
            handler.SpawnRoom();

            }
            else
            {
                Debug.LogError(gameObject.name + " has no room handler");
            }
            hasSpawnedNext = true;

        }

        if(transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
