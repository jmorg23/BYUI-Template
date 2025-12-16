using System.Drawing;

public class Renderer
{
    private readonly int cellSize;

    public Renderer(int cellSize)
    {
        this.cellSize = cellSize;
    }

    public void Draw(Graphics g, Grid grid)
    {
        for (int r = 0; r < grid.Cells.GetLength(0); r++)
        {
            for (int c = 0; c < grid.Cells.GetLength(1); c++)
            {
                Brush brush = grid.Cells[r, c].IsAlive() ? Brushes.Black : Brushes.White;
                g.FillRectangle(brush, c * cellSize, r * cellSize, cellSize, cellSize);
                g.DrawRectangle(Pens.Gray, c * cellSize, r * cellSize, cellSize, cellSize);
            }
        }
    }
}
