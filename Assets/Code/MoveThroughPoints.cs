using System.Linq;
using UnityEngine;

public class MoveThroughPoints : MonoBehaviour
{
    [SerializeField]
    private float displacementPerSecond = 1;

    private Vector3[] Points { get; set; }
    private int[] PathIndices { get; set; }
    private int CurrentPathIndex { get; set; }
    private float t { get; set; }
    private bool IsMoving { get; set; } = false;

    void Update()
    {
        if (!IsMoving || PathIndices.Length < 2) return;

        //COMPLÉTEZ À PARTIR D'ICI
        
    }

    public void StartMove(Vector3[] points, int[] pathIndices)
    {
        Points = points;
        PathIndices = pathIndices;
        IsMoving = true;
        CurrentPathIndex = 0;
    }

    public void StartMove(Vector3[] points)
    {
        PathIndices = Enumerable.Range(0, points.Length).ToArray();
        StartMove(points, PathIndices);
    }
}
