using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    public LineRenderer line;
    public Transform[] points = new Transform[3]; 
    private Transform p0, p1, p2;
    public int lineResolution = 10;

    private void Awake()
    {
        p0 = points[0];
        p1 = points[1];
        p2 = points[2];
        
        // Add one for the end point
        line.positionCount = lineResolution + 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        Draw();
    }

    private void Draw()
    {
        // Loop through all the points up until the last
        for (int i = 0; i < line.positionCount - 1; i++)
        {
            // Finding t for the current iteration
            float t = (float)i / (float)line.positionCount;
            Vector3 p = GetPointOnQuadraticCurve(t, p0.position, p1.position, p2.position);
            line.SetPosition(i, p);
        }

        // Set the last position to p1 to complete the curve 
        line.SetPosition(line.positionCount - 1, points.Last().position);
    }

    private Vector3 GetPointOnQuadraticCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        /// B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
        float oneMinusT = 1 - t;
        float tSquared = t * t;
        Vector3 p = oneMinusT * oneMinusT * 2 * p0;
        p += 2 * oneMinusT * t * p1;
        p += tSquared * p2;

        return p;
    }

    void Update()
    {
        Draw();
    }
}
