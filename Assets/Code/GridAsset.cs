using UnityEngine;

[System.Serializable]
public class Flat2DArray<T>
{
    private T[] Array { get; set; }
    private int NRows { get; set; }
    private int NColumns { get; set; }

    public Flat2DArray(int nRows, int nColumns)
    {
        NRows = nRows;
        NColumns = nColumns;
        Array = new T[NRows * NColumns];
    }

    public T this[int i, int j]
    {
        get => Array[i * NRows + j];
        set => Array[i * NRows + j] = value;
    }
}

[CreateAssetMenu(fileName = "New Grid", menuName = "Data Structures/Grid")]
public class GridAsset : ScriptableObject
{
    [SerializeField]
    private Flat2DArray<int> grid = new(defaultSize, defaultSize);

    [SerializeField]
    private int defaultValue = -1;

    private const int defaultSize = 3;

    public int Size { get; set; } = defaultSize;

    public int this[int i, int j]
    {
        get => grid[i,j];
        set => grid[i,j] = value;
    }

    public void Reset()
    {
        ResetGrid();
    }
    public void ResetGrid()
    {
        grid = new Flat2DArray<int>(Size, Size);
        FillGrid(defaultValue);
    }

    private void FillGrid(int value)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                grid[i, j] = value;
            }
        }
    }
}
