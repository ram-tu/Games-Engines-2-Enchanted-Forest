using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : SteeringBehaviour
{
    public List<Flocking> tagged = new List<Flocking>();

    public float cohesionDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //tagged = new List<Flocking>();
        tagged.Remove(GetComponent<Flocking>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Vector3 Calculate()
    {
        Vector3 force = Alignment() + Cohesion() + Seperation();
        return force;
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

        Debug.Log("the seperation force is " + steeringForce);
        return steeringForce;
    } 

    Vector3 Cohesion()
    {
        Vector3 centerofMass = Vector3.zero;
        Vector3 steeringForce = Vector3.zero;
        float taggedCount = 0;
        foreach (Flocking entity in tagged)
        {
            if (entity.gameObject != gameObject)
            {
                centerofMass += entity.gameObject.transform.position;
                taggedCount++;
            }
        }
        if (taggedCount > 0)
        {
            centerofMass /= taggedCount + cohesionDistance;
            steeringForce = GetComponent<Boid>().SeekForce(centerofMass);
        }
        Debug.Log("the cohesion force is " + steeringForce);
        return steeringForce;
    }

    Vector3 Alignment()
    {
        Vector3 steeringForce = Vector3.zero;
        float taggedCount = 0;
        foreach (Flocking entity in tagged)
        {
            if (entity.gameObject != this.gameObject)
            {
                steeringForce += entity.GetComponent<Boid>().velocity;
                taggedCount++;
            }
        }
        if (taggedCount > 0)
        {
            steeringForce /= taggedCount;
            steeringForce -= GetComponent<Boid>().velocity;
        }
        Debug.Log("the alignment force is " + steeringForce);
        return steeringForce;
    }
}
