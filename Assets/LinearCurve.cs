using UnityEngine;

public class LinearCurve : MonoBehaviour
{
    public LineRenderer line;
    public Transform p0, p1;
    public int lineResolution = 10;

    private void Awake()
    {
        // Add one for the end point
        line.positionCount = lineResolution + 1;
    }

    void Start()
    {
        // Loop through all the points up until the last
        for (int i = 0; i < line.positionCount - 1; i++)
        {
            // Finding t for the current iteration
            float t = (float)i / (float)line.positionCount;
            Vector3 p = GetPointOnLinearCurve(t, p0.position, p1.position);
            line.SetPosition(i, p);
        }

        // Set the last position to p1 to complete the curve 
        line.SetPosition(line.positionCount - 1, p1.position);
    }

    /// <summary>
    /// Calculates the linear point on the curve for the value of t which is a fraction
    /// </summary>
    /// <param name="t">time</param>
    /// <param name="p0">start point</param>
    /// <param name="p1">end point</param>
    /// <returns></returns>
    private Vector3 GetPointOnLinearCurve(float t, Vector3 p0, Vector3 p1)
    {
        //P = P0 + t(P1 – P0),  0 < t < 1
        return p0 + t * (p1 - p0);
    }
}
