// Street is an abstract class
// OneWayStreet and TwoWayStreet derive from Street
// On a OneWayStreet, it is illegal to make a U turn
// On a TwoWayStreet, a U Turn reverses the travelling direction

// Main program creates two Street child objects - one OneWay and one TwoWay
// and demonstrates what happens when you make a U Turn
// on a OneWayStreet and a TwoWayStreet

using System;
using static System.Console;

class DebugTen02
{
    static void Main()
    {
        OneWayStreet oak = new OneWayStreet("Oak Avenue", "east");
        TwoWayStreet elm = new TwoWayStreet("Elm Street", "south");

        WriteLine("On " + oak.Name + ": " + oak.MakeUTurn());
        WriteLine("On " + oak.Name + ": " + oak.MakeUTurn());

        WriteLine("On " + elm.Name + ": " + elm.MakeUTurn());
        WriteLine("On " + elm.Name + ": " + elm.MakeUTurn());
    }
}

public abstract class Street
{
    protected string name;
    protected string direction;

    public Street(string name, string travelDirection)
    {
        this.name = name;
        this.direction = travelDirection;
    }

    public string Name
    {
        get { return name; }
    }

    public abstract string MakeUTurn();
}

class OneWayStreet : Street
{
    public OneWayStreet(string name, string direction) : base(name, direction)
    {
    }

    public override string MakeUTurn()
    {
        string temp = "U Turn is illegal! Was and still going " + direction;
        return temp;
    }
}

class TwoWayStreet : Street
{
    public TwoWayStreet(string name, string direction) : base(name, direction)
    {
    }

    public override string MakeUTurn()
    {
        string wasGoing = direction;
        string[] directions = { "north", "south", "east", "west" };
        string[] oppDirections = { "south", "north", "west", "east" };

        for (int i = 0; i < directions.Length; i++)
        {
            if (direction.Equals(directions[i], StringComparison.OrdinalIgnoreCase))
            {
                direction = oppDirections[i];
                break;
            }
        }

        return $"U Turn successful. Was going {wasGoing}. Now going {direction}";
    }
}
