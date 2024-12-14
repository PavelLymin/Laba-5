// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ApartmentBuilding : Realty
    {
        private int _floor;
        public int Floor
        {
            get
            {
                return _floor;
            }
            set
            {
                if (value >= 0)
                    _floor = value;
                else
                    throw new ArgumentException("Этаж не может быть отрицательным числом.");
            }
        }

        public ApartmentBuilding(string NameOwner, DateTime DateCreated, int Cost, int Floor)
            : base(NameOwner, DateCreated, Cost)
        {
            this.Floor = Floor;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Floor: {Floor}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ApartmentBuilding other)
            {
                return NameOwner == other.NameOwner && DateCreated == other.DateCreated &&
                       Cost == other.Cost && Floor == other.Floor;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (NameOwner, DateCreated, Cost, Floor).GetHashCode();
        }
    }
}
