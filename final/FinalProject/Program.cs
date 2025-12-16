using System;
using System.Drawing;
using System.Windows.Forms;

public class MainForm : Form
{
    private readonly PictureBox canvas;
    private readonly GameController controller;
    private readonly Grid grid;
    private readonly Settings settings;

    public MainForm()
    {
        settings = new Settings();
        grid = new Grid(settings.Rows, settings.Cols);

        Width = settings.Cols * settings.CellSize + 20;
        Height = settings.Rows * settings.CellSize + 80;

        canvas = new PictureBox
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White
        };
        Controls.Add(canvas);

        controller = new GameController(grid, canvas, settings.CellSize, settings.Speed);

        var startButton = new Button { Text = "Start", Dock = DockStyle.Top };
        var stopButton = new Button { Text = "Stop", Dock = DockStyle.Top };
        var clearButton = new Button { Text = "Clear", Dock = DockStyle.Top };

        startButton.Click += (s, e) => controller.Start();
        stopButton.Click += (s, e) => controller.Stop();
        clearButton.Click += (s, e) =>
        {
            foreach (var cell in grid.Cells)
                cell.SetAlive(false);
            canvas.Invalidate();
        };

        Controls.Add(startButton);
        Controls.Add(stopButton);
        Controls.Add(clearButton);


        canvas.MouseClick += Canvas_MouseClick;

        canvas.Paint += (s, e) => controller.Render(e.Graphics);
    }

    private void Canvas_MouseClick(object sender, MouseEventArgs e)
    {
        int col = e.X / settings.CellSize;
        int row = e.Y / settings.CellSize;

        if (row >= 0 && row < settings.Rows && col >= 0 && col < settings.Cols)
        {
            grid.Cells[row, col].SetAlive(!grid.Cells[row, col].IsAlive());
            canvas.Invalidate();
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MainForm());
    }
}
