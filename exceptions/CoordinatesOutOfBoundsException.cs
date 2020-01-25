using System;

public class CoordinatesOutOfBoundsException : Exception
{
    public CoordinatesOutOfBoundsException()
    {
    }

    public CoordinatesOutOfBoundsException(string message)
        : base(message)
    {
    }

    public CoordinatesOutOfBoundsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}