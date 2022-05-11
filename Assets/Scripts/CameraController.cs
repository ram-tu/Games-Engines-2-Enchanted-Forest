using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    public List<Path> allCameraPaths = new List<Path>();

    public int cameraCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = allCameraPaths[0].transform.position - new Vector3(0,3,5);
        StartCoroutine(ChangeCamera());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeCamera()
    {
        while (true)
        {
            if (GetComponent<FollowPath>().finished)
            {
                if (cameraCounter != allCameraPaths.Count - 1)
                {
                    cameraCounter = cameraCounter + 1;
                    GetComponent<FollowPath>().path = allCameraPaths[cameraCounter];
                    GetComponent<FollowPath>().next = 0;
                    GetComponent<FollowPath>().finished = false;
                    transform.position = allCameraPaths[cameraCounter].transform.position - new Vector3(0, 0, 2);
                    yield return new WaitForSeconds(2.0f);
                }
                else{
                    Debug.Log("camera log is now greater than count");
                    GetComponent<FreeCamera>().enabled = true;
                    GetComponent<Boid>().enabled = false;
                    yield return new WaitForSeconds(2.0f);
                }
            }

            yield return null;
        }
        
        
    }
    
}
