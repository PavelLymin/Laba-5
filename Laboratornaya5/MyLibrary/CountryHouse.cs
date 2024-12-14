// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace MyLibrary
{
    public class CountryHouse : Realty
    {
        private double _landPlotArea;
        public double LandPlotArea
        {
            get
            {
                return _landPlotArea;
            }
            set
            {
                if (value >= 20 && value <= 120)
                    _landPlotArea = value;
                else
                    throw new ArgumentException("Неверно введена площадь земельного участка");
            }
        }

        public CountryHouse(string NameOwner, DateTime DateCreated, int Cost, double LandPlotArea)
            : base(NameOwner, DateCreated, Cost)
        {
            this.LandPlotArea = LandPlotArea;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Plot area: {LandPlotArea}";
        }

        public override bool Equals(object obj)
        {
            if (obj is CountryHouse other)
            {
                return NameOwner == other.NameOwner && DateCreated == other.DateCreated &&
                       Cost == other.Cost && LandPlotArea == other.LandPlotArea;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (NameOwner, DateCreated, Cost, LandPlotArea).GetHashCode();
        }
    }
}
