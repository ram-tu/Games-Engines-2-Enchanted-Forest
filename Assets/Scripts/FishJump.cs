using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public bool shouldJump = false;
    public int height = 0;
    public int distance = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Jump());
    }

    void Start()
    {
        float distanceUp = transform.position.x + distance;
        float heightUp = transform.position.y + height;
        float distanceDown = transform.position.x + distance + (distance / 2);
        Vector3 waypoint1 = new Vector3(distanceUp,heightUp,transform.position.x);
        Vector3 waypoint2 = new Vector3(distanceDown, transform.position.y, transform.position.z);
        waypoints.Add(waypoint1);
        waypoints.Add(waypoint2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Jump()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            shouldJump = true;
            
        }
    }
}
