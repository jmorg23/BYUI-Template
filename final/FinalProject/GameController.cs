using System.Drawing;
using System.Windows.Forms;

public class GameController
{
    private readonly Grid grid;
    private readonly GameEngine engine;
    private readonly Renderer renderer;
    private readonly Timer timer;
    private readonly PictureBox canvas;

    public GameController(Grid grid, PictureBox canvas, int cellSize, int interval = 200)
    {
        this.grid = grid;
        engine = new GameEngine(grid);
        renderer = new Renderer(cellSize);
        this.canvas = canvas;

        timer = new Timer();
        timer.Interval = interval;
        timer.Tick += (s, e) => Step();
        
    }

    public void Start()
    {
        timer.Start();
    }
    public void Stop()
    {
        timer.Stop();
    }

    public void Step()
    {
        engine.NextGeneration();
        canvas.Invalidate();
    }

    public void Render(Graphics g){
         renderer.Draw(g, grid);
    }
}
