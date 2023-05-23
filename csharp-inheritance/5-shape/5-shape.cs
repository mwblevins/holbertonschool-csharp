using System;
/// <summary>
/// shape class taht we will use for inheritance
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