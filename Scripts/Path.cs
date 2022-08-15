using System.Collections.Generic;
using UnityEngine;

public static class Path 
{
    private static List<Vector3> points = new List<Vector3>();

    public static List<Vector3> Points
    {
        get => points;
        set => points = value;
    }

    public static Vector3 LastPointCoordinates => points[points.Count - 1];
    public static Vector3 FirstPointCoordinates => points[0];

    public static void DeleteFirstCoordinate() => points.RemoveAt(0);
    public static void ResetPath() => points = new List<Vector3>();
}
