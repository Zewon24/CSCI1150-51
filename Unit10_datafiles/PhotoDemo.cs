using System;
using static System.Console;
using System.Globalization;
public class Photo
{
    private int width;
    private int height;
    protected double price;

    public int Width
    {
        get { return width; }
        set
        {
            width = value;
            SetPrice();
        }
    }

    public int Height
    {
        get { return height; }
        set
        {
            height = value;
            SetPrice();
        }
    }

    public double Price
    {
        get { return price; }
    }

    public Photo() { }

    protected virtual void SetPrice()
    {
        if ((width == 8 && height == 10) || (width == 10 && height == 8))
            price = 3.99;
        else if ((width == 10 && height == 12) || (width == 12 && height == 10))
            price = 5.99;
        else
            price = 9.99;
    }

    public override string ToString()
    {
        return $"{GetType().Name}    {width} X {height}   Price: {price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}

public class MattedPhoto : Photo
{
    public string Color { get; set; }

    public MattedPhoto() { }

    protected override void SetPrice()
    {
        base.SetPrice();
        price += 10.00;
    }

    public override string ToString()
    {
        return $"{GetType().Name}    {Color} matting {Width} X {Height}   Price: {price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}

public class FramedPhoto : Photo
{
    public string Material { get; set; }
    public string Style { get; set; }

    public FramedPhoto() { }

    protected override void SetPrice()
    {
        base.SetPrice();
        price += 25.00;
    }

    public override string ToString()
    {
        return $"{GetType().Name}    {Style}, {Material} frame. {Width} X {Height}   Price: {price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";
    }
}

public class PhotoDemo
{
    public static void Main(string[] args)
    {
        Photo photo1 = new Photo();
        photo1.Width = 8;
        photo1.Height = 10;

        Photo photo2 = new Photo();
        photo2.Width = 8;
        photo2.Height = 9;

        MattedPhoto matted = new MattedPhoto();
        matted.Width = 10;
        matted.Height = 12;
        matted.Color = "white";

        FramedPhoto framed = new FramedPhoto();
        framed.Width = 8;
        framed.Height = 10;
        framed.Style = "modern";
        framed.Material = "silver";

        WriteLine(photo1.ToString());
        WriteLine(photo2.ToString());
        WriteLine(matted.ToString());
        WriteLine(framed.ToString());
    }
}