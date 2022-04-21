using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public bool shouldJump = false;
    public int height = 0;
    public int distance = 0;
    public List<Vector3> waypoints = new List<Vector3>();

    public Path originalPath;

    public Path jumpPath;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(Jump());
    }

    void Start()
    {
        Debug.Log("HERE WE GOOO");
        GetComponent<StateMachine>().ChangeState(new SwimState());
        jumpPath = gameObject.GetComponent<Path>();
        originalPath = GetComponent<FollowPath>().path;

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
            float distanceUp = transform.position.x + distance;
            float heightUp = transform.position.y + height;
            float distanceDown = transform.position.x + distance + (distance / 2);
            Vector3 waypoint1 = new Vector3(distanceUp,heightUp,transform.position.z);
            Vector3 waypoint2 = new Vector3(distanceDown, transform.position.y, transform.position.z);
            Debug.Log("the waypoint count is " + waypoints.Count);
            if (waypoints.Count != 2)
            {
                Debug.Log("Executing");
                waypoints.Add(waypoint1);
                waypoints.Add(waypoint2);
            }
            else
            {
                Debug.Log("Adapting");
                waypoints[0] = waypoint1;
                waypoints[1] = waypoint2;
            }

            jumpPath.waypoints = waypoints;
            GetComponent<StateMachine>().ChangeState(new JumpState());
            

        }
    }
}
