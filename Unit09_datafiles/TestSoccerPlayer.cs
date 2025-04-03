using System;
using static System.Console;
using System.Globalization;

namespace TestSoccerPlayerApp
{
    class SoccerPlayer
    {
        public string Name { get; set; }
        public int JerseyNum { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        public SoccerPlayer(string name, int jerseyNum, int goals, int assists)
        {
            Name = name;
            JerseyNum = jerseyNum;
            Goals = goals;
            Assists = assists;
        }

        public void DisplayPlayerInfo()
        {
            WriteLine($"Player: {Name}");
            WriteLine($"Jersey Number: {JerseyNum}");
            WriteLine($"Goals: {Goals}");
            WriteLine($"Assists: {Assists}");
        }
    }

    class TestSoccerPlayer
    {
        static void Main()
        {
            SoccerPlayer player = new SoccerPlayer("Lionel Messi", 10, 30, 12);

            player.DisplayPlayerInfo();
        }
    }
}
