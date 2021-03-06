using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbWispController : MonoBehaviour
{
    public GameObject target;
    public float angle;
    public bool isSideways;

    public bool combining = false; 
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<StateMachine>().ChangeState(new RotateState());
    }

    private void OnEnable()
    {
        StartCoroutine(Combine());
    }

    // Update is called once per frame
    void Update()
    {
        if(isSideways)
            transform.RotateAround(target.transform.position, Vector3.up, angle * Time.deltaTime);
        else
        {
            transform.RotateAround(target.transform.position, Vector3.right, angle * Time.deltaTime);        }
    }
    
    IEnumerator Combine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            combining = true;

        }
    }
}
