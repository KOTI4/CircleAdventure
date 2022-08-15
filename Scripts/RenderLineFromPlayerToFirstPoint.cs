using UnityEngine;

public class RenderLineFromPlayerToFirstPoint : RenderLine
{
    public GameObject player;

    void Start() => RenderLineStart();

    void Update()
    {
        if (Path.Points.Count != 0)
        {
            lineRenderer.positionCount = 0;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(1, Path.FirstPointCoordinates);
        }
    }
}
