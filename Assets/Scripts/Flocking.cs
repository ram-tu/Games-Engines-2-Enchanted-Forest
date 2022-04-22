using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : SteeringBehaviour
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

    public override Vector3 Calculate()
    {
        Vector3 force = Alignment() + Cohesion() + Seperation();
        return boid.SeekForce(force);
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
            steeringForce = boid.SeekForce(centerofMass);
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
                steeringForce += entity.boid.velocity;
                taggedCount++;
            }
        }
        if (taggedCount > 0)
        {
            steeringForce /= taggedCount;
            steeringForce -= boid.velocity;
        }

        return steeringForce;
    }
}
