using UnityEngine;

public class TouchToPathPoint : MonoBehaviour
{
    public delegate void CreateNewPoint();
    public static event CreateNewPoint PointCreated;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouse);
            Path.Points.Add(new Vector3(mousePosition.x, mousePosition.y, 0));
            PointCreated();
        }
    }
}
