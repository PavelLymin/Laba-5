// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace MyLibrary
{
    public class PrivateResidentBuilding : Realty
    {
        public PrivateResidentBuilding(string NameOwner, DateTime DateCreated, int Cost)
        : base(NameOwner, DateCreated, Cost) { }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is PrivateResidentBuilding other)
            {
                return NameOwner == other.NameOwner && DateCreated == other.DateCreated &&
                       Cost == other.Cost;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (NameOwner, DateCreated, Cost).GetHashCode();
        }
    }
}
