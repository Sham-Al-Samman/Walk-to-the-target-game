using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2
{
    public class MainClass
    {
        static public List<Profile> profiles;
        static public int current = -1; //current profile index

        static MainClass()
        {
            profiles = new List<Profile>();
        }

        public static int NumOfGames()
        {
            var q = from p in profiles
                    select p.games.Count;
            return q.Sum();
        }

        public static int HighestScore()
        {
            var q = from p in profiles
                    orderby p.maxScore() descending
                    select p.maxScore();
            return q.First();
        }

        public static int LowestScore()
        {
            var q = from p in profiles
                    orderby p.minScore()
                    select p.minScore();
            return q.First();
        }

        public static string MinimumDuration()
        {
            var q = from p in profiles
                    orderby p.minDuration()
                    select p.minDuration();
            return q.First();
        }

        public static string MaximumDuration()
        {
            var q = from p in profiles
                    orderby p.maxDuration() descending
                    select p.maxDuration();
            return q.First();
        }

        public static string TotalDuration()
        {
            var q = from p in profiles
                    select p.totalSeconds();
            int total = q.Sum();

            int min = total / 60;
            int sec = total - (min * 60);

            string duration = min < 10 ? "0" + min : min.ToString();
            duration += sec < 10 ? ":0" + sec : ":" + sec;

            return duration;
        }
    }

    public class Profile
    {
        public string name;
        public Gender gender;
        public int age;
        public string toyFigure;
        public List<Game> games;
        
        
        public Profile()
        {
            games = new List<Game>();
        }

        public string minDuration()
        {
            var q = from g in games
                    orderby g.duration
                    select g.duration;

            return q.First();
        }

        public string maxDuration()
        {
            var q = from g in games
                    orderby g.duration descending
                    select g.duration;

            return q.First();
        }

        public int totalSeconds()
        {
            var q = from g in games
                    select g;

            int sum = 0;
            foreach(Game g in q)
            {
                sum += (g.min * 60) + g.sec;
            }
            return sum;
        }

        public override string ToString()
        {
            return this.name;
        }

        public int minScore()
        {
            var q = from g in games
                    orderby g.score
                    select g.score;
            return q.First();
        }

        public int maxScore()
        {
            var q = from g in games
                    orderby g.score descending
                    select g.score;
            return q.First();
        }
    }

    public class Game
    {
        private string _duration;
        public string duration
        {
            set
            {
                min = Int32.Parse(value.Substring(0, 2));
                sec = Int32.Parse(value.Substring(3, 2));
                _duration = value;
            }
            get { return _duration;}
            
        }
        public int min;
        public int sec;
        public int numOfMoves;
        public int successfulMoves;
        public List<Keys> steps;
        public int numOfBarriers;
        public string date;
        public int score;

        public Game()
        {
            steps = new List<Keys>();
            date = DateTime.Now.ToString("d/M/yyyy");
        }

        public void setInfo(string d, int m, int s, int barrier ,int sc)
        {
            duration = d;
            numOfMoves = m;
            successfulMoves = s;
            numOfBarriers = barrier;
            score = sc;
        }
        
    }

    public enum Gender
    {
        MALE,
        FEMALE
    };
}
