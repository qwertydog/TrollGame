using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class Entity
    {
        public Character Character { get; }
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Entity(Character entity, int x, int y)
        {
            Character = entity;
            X = x;
            Y = y;
        }
    }
}
