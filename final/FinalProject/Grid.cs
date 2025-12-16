using System.Runtime.ConstrainedExecution;

public class Grid
{
    private int ROWS = 50, COLLS = 50;
    public Cell[,] Cells;

    public Grid(int rows, int cols)
    {
        this.ROWS = rows;
        this.COLLS = cols;
        Cells = new Cell[ROWS, COLLS];
        Initialize();
    }

    private void Initialize()
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLLS; c++)
                Cells[r, c] = new Cell(r, c);
    }

    public int GetAliveNeighbors(int row, int col)
    {
        int count = 0;
        for (int dr = -1; dr <= 1; dr++)
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;
                int r = row + dr, c = col + dc;
                if (r >= 0 && r < ROWS && c >= 0 && c < COLLS && Cells[r, c].IsAlive())
                    count++;
            }
        return count;
    }
}
