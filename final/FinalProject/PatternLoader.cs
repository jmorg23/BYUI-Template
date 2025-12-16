public static class PatternLoader
{
    public static void LoadGlider(Grid grid, int x, int y)
    {
        grid.Cells[x, y + 1].SetAlive(true);
        grid.Cells[x + 1, y + 2].SetAlive(true);
        grid.Cells[x + 2, y].SetAlive(true);
        grid.Cells[x + 2, y + 1].SetAlive(true);
        grid.Cells[x + 2, y + 2].SetAlive(true);
    }

    
}
