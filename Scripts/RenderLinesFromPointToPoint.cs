using System.Collections.Generic;
using UnityEngine;

public class RenderLinesFromPointToPoint: RenderLine
{
    void Start()
    {
        RenderLineStart();
        lineRenderer.positionCount = 0;
        TouchToPathPoint.PointCreated += UpdateLine;
        PlayerMovement.DeletePoint += UpdateLine;
    }

    private void UpdateLine()
    {
        if (Path.Points.Count > 0) 
        {
            List<Vector3> pointsList = new List<Vector3>(Path.Points);
            Vector3[] pointsArray = pointsList.ToArray();
            lineRenderer.positionCount = pointsArray.Length;
            lineRenderer.SetPositions(pointsArray);
        }
    }
}
