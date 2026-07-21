using JetBrains.Annotations;
using UnityEngine;

public class CactusHandlerScript : MonoBehaviour
{
    public GameObject Cactus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        
    }
    public int FrameCount = 0;
    public int FrameRNG = -1;
    // Update is called once per frame
    void Update()
    {
        if (FrameCount == 0)
        {
            FrameRNG = (Random.Range(120, 300));
        }
        if (FrameCount == FrameRNG)
        {
            Instantiate(Cactus, new Vector3(9f,0.5f), Quaternion.identity);
            FrameCount = 0;
            FrameRNG = (Random.Range(120,300));
        }
        FrameCount++;
    }
}
