using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    public List<Flocking> tagged = new List<Flocking>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 Seperation()
    {
        Vector3 steeringForce = Vector3.zero;
        for (int i = 0; i < tagged.Count; i++)
        {
            GameObject entity = tagged[i].gameObject;
            if (entity != null)
            {
                Vector3 toEntity = transform.position - entity.transform.position;
                steeringForce = (toEntity.normalized / toEntity.magnitude);
            }
        }
        return steeringForce;
    } 

    Vector3 Cohesion()
    {
        Vector3 centerofMass = Vector3.zero;
        Vector3 steeringForce = Vector3.zero;
        float taggedCount = 0;
        foreach (Flocking entity in tagged)
        {
            if (entity != this)
            {
                centerofMass += entity.gameObject.transform.position;
                taggedCount++;
            }
        }
        if (taggedCount > 0)
        {
            centerofMass /= taggedCount;
            steeringForce = GetComponent<Boid>().SeekForce(centerofMass);
        }

        return steeringForce;
    }

    Vector3 Alignment()
    {
        Vector3 steeringForce = Vector3.zero;
        float taggedCount = 0;
        foreach (Flocking entity in tagged)
        {
            if (entity != this)
            {
                steeringForce += entity.gameObject.GetComponent<Boid>().velocity;
                taggedCount++;
            }
        }
        if (taggedCount > 0)
        {
            steeringForce /= (float)taggedCount;
            steeringForce -= GetComponent<Boid>().velocity;
        }

        return steeringForce;
    }
}
