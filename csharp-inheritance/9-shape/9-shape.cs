using System;
/// <summary>
/// task 9
/// </summary>
public class Shape
{
    /// <summary>
    /// area
    /// </summary>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}
/// <summary>
/// rectangle
/// </summary>
public class Rectangle : Shape
{
    private int width;
    private int height;
    /// <summary>
    /// width
    /// </summary>
    public int Width
    {
        get {return width; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width must be greater than or equal to 0");
            }
            width = value;
        }
    }
    /// <summary>
    /// height
    /// </summary>
    public int Height
    {
        get {return height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height must be greater than or equal to 0");
            }
            height = value;
        }
    }
    /// <summary>
    /// area override
    /// </summary>
    public override int Area()
    {
        return width * height;
    }
    /// <summary>
    /// string override
    /// </summary>
    public override string ToString()
    {
        return $"[Rectangle] {width} / {height}";
    }
}
/// <summary>
/// square
/// </summary>
public class Square : Rectangle
{
    private int size;
    /// <summary>
    /// size
    /// </summary>
    public int Size
    {
        get {return size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Size must be greater than or equal to 0");
            }
            size = value;
            Width = value;
            Height = value;

        }
    }
    /// <summary>
    /// override
    /// </summary>
    public override string ToString()
    {
        return $"[Square] {size} / {size}";
    }
}