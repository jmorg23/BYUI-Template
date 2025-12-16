public class Cell
{
    private bool _alive = false;
    private int _x;
    private int _y;


    public bool IsAlive()
    {
        return _alive;
    }

    public int GetX()
    {
        return _x;
    }
    public int GetY()
    {
        return _y;
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
    public void SetX(int x)
    {
        _x = x;
    }
    public void SetY(int y)
    {
        _y = y;
    }
    


    public Cell(int x, int y, bool isAlive = false)
    {
        _x = x;
        _y = y;
        _alive = isAlive;
    }
}
