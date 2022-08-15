using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed = 1;

    public delegate void DeleteReachedPoint();
    public static event DeleteReachedPoint DeletePoint;
    void Update()
    {
        if (Path.Points.Count != 0)
        {
            if (transform.localPosition == Path.FirstPointCoordinates)
            {
                Path.DeleteFirstCoordinate();
                DeletePoint();
            }
            else
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, Path.FirstPointCoordinates, Time.deltaTime * speed);
        }
    }
}
