using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Path> allCameraPaths = new List<Path>();

    public int cameraCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = allCameraPaths[0].transform.position - new Vector3(0,3,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<FollowPath>().finished)
        {
            ChangeCamera();
        }
    }

    void ChangeCamera()
    {
        if (cameraCounter != allCameraPaths.Count - 1)
        {
            cameraCounter = cameraCounter + 1;
            GetComponent<FollowPath>().path = allCameraPaths[cameraCounter];
            GetComponent<FollowPath>().next = 0;
            transform.position = allCameraPaths[cameraCounter].transform.position - new Vector3(0,0,5);
        }
        
    }
}
