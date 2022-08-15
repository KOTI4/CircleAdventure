using UnityEngine;

public class RenderLine : MonoBehaviour
{
    public LineRenderer lineRenderer;

    protected void RenderLineStart()
    {
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        Manager.GameWasWin += DeleteAllLines;
        Manager.GameWasLosed += DeleteAllLines;
    }
    protected void DeleteAllLines() => lineRenderer.positionCount = 0;
}
