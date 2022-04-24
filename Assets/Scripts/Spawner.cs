using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numObjects;
    public int radius;
    public int yComponent;

    public bool isFlock = false;
    
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

        if (isFlock)
        {
            int count = 0;
            foreach (Transform child in transform)
            {
                child.name = "Wisp Flock " + count;
                count++;
                child.GetComponent<Flocking>().tagged = transform.GetComponentsInChildren<Flocking>().ToList();
                Debug.Log(child.GetComponent<Flocking>().tagged.Count);
            }

            foreach (Flocking f in transform.GetChild(0).GetComponent<Flocking>().tagged)
            {
                Debug.Log(f.gameObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
