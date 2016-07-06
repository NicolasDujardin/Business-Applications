using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeExcelOefening
{
    public class Team : ModelBaseClass, IComparable<Team>
    {
        public Cyclist Cyclist1 { get; set; }
        public Cyclist Cyclist2 { get; set; }
        private int _rounds;
        public int Rounds { get { return _rounds; } }
        private List<int> _points = new List<int>();
        public List<int> Points { get { return _points; } }
        public double Score
        {
            get
            {
                int totalPoints = Points.Sum();
                int bonusRounds = totalPoints / 100;
                int bonusPoints = totalPoints % 100;
                double score = Rounds + bonusRounds + bonusPoints;
                return score;
            }
        }
        public void AddPoint(int point)
        {
            Points.Add(point);
            OnPropertyChanged(nameof(Points));
            OnPropertyChanged(nameof(Score));
        }
        public void AddRound()
        {
            _rounds += 1;
            OnPropertyChanged(nameof(Rounds));
            OnPropertyChanged(nameof(Score));
        }

        public override bool Equals(object obj)
        {
            Team other = obj as Team;
            if (null == other) return false;
            return this.Cyclist1.Sponsor.Equals(other.Cyclist1.Sponsor);
        }
        public override int GetHashCode()
        {
            return (this.Cyclist1?.Sponsor?.GetHashCode()).Value;
        }

        public int CompareTo(Team other)
        {
            //We want to sort descending: 10 points is better then 4 points
            return other.Score.CompareTo(this.Score);
        }
    }
}