using System;
/// <summary>
/// task 7
/// </summary>
public class Shape
{
    /// <summary>
    /// Area
    /// </summary>
    public virtual int Area()
    {
        throw new NotImplementedException("Area() is not implemented");
    }
}
/// <summary>
///Rectangle from Shape 
/// </summary>
public class Rectangle : Shape
{
    private int width;
    private int height;
    /// <summary>
    /// find width
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
    /// find height
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
    /// Area override
    /// </summary>
    public override int Area()
    {
        return width * height;
    }
    /// <summary>
    /// to srting override
    /// </summary>
    public override string ToString()
    {
        return $"[Rectangle] {width} / {height}";
    }
}