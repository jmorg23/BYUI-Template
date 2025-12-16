public class GameEngine
{
    private Grid grid;

    public GameEngine(Grid grid)
    {
        this.grid = grid;
    }

    public void NextGeneration()
    {
        bool[,] newStates = new bool[grid.Cells.GetLength(0), grid.Cells.GetLength(1)];

        for (int r = 0; r < grid.Cells.GetLength(0); r++)
        {
            for (int c = 0; c < grid.Cells.GetLength(1); c++)
            {
                int neighbors = grid.GetAliveNeighbors(r, c);
                bool alive = grid.Cells[r, c].IsAlive();

                newStates[r, c] = alive
                    ? neighbors == 2 || neighbors == 3
                    : neighbors == 3;
            }
        }

        for (int r = 0; r < grid.Cells.GetLength(0); r++)
            for (int c = 0; c < grid.Cells.GetLength(1); c++)
                grid.Cells[r, c].SetAlive(newStates[r, c]);
    }
}
    