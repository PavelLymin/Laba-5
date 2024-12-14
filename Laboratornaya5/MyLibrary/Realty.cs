// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace MyLibrary
{
    public class Realty
    {
        public string NameOwner { get; set; }
        public DateTime DateCreated { get; set; }

        private int _cost;
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value >= 1000)
                    _cost = value;
                else
                    throw new ArgumentException("Цена аренды не может быть меньше 1000.");
            }
        }

        public Realty(string NameOwner, DateTime DateCreated, int Cost)
        {
            this.NameOwner = NameOwner;
            this.DateCreated = DateCreated;
            this.Cost = Cost;
        }

        public override string ToString()
        {
            return $"Owner: {NameOwner}, Date: {DateCreated:dd.MM.yyyy}, Cost: {Cost}";
        }
    }
}

