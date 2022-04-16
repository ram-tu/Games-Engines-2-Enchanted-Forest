using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numObjects;
    public int radius;
    public int yComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numObjects; i++)
        {
            GameObject newObj = Instantiate(objectToSpawn);
            Vector2 spawnPos = Random.insideUnitCircle * radius;
            newObj.transform.position = transform.TransformPoint(new Vector3(spawnPos.x, yComponent, spawnPos.y));
            newObj.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
