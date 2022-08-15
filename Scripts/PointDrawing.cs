using System.Collections.Generic;
using UnityEngine;

public class PointDrawing : MonoBehaviour
{

    public GameObject pointPrefab;
    private List<GameObject> points = new List<GameObject>();

    void Start()
    {
        TouchToPathPoint.PointCreated += DrawPoint;
        PlayerMovement.DeletePoint += ErasePoint;
        Manager.GameWasLosed += EraseAllPoint;
        Manager.GameWasWin += EraseAllPoint;
    }

    private void DrawPoint()
    {
        GameObject createdPoint = Instantiate(pointPrefab, Path.LastPointCoordinates, new Quaternion());
        points.Add(createdPoint);
    }

    private void ErasePoint()
    {
        Destroy(points[0]);
        points.RemoveAt(0);
    }

    private void EraseAllPoint()
    {
        foreach (var point in points)
            Destroy(point);

        points = new List<GameObject>();
    }
}
