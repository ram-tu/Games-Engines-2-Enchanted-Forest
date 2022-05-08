using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<Path> allCameraPaths = new List<Path>();
    // Start is called before the first frame update
    void Start()
    {
        transform.position = allCameraPaths[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
