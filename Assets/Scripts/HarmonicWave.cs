using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmonicWave : MonoBehaviour
{
    public float frequency = 1;
    public float amplitude = 40;
    public float theta = 0;
    public Direction direction;
    public enum Direction
    {
        LEFT,
        RIGHT
    }
    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Sin(theta) * amplitude;
        Quaternion q;
        switch (direction)
        {
            case Direction.LEFT:
                q = Quaternion.AngleAxis(angle, Vector3.left);
                transform.rotation = q;
                break;
            case Direction.RIGHT:
                q = Quaternion.AngleAxis(angle, Vector3.right);
                transform.rotation = q;
                break;
        }
        theta += Mathf.PI * 2.0f * Time.deltaTime * frequency;
    }
 }