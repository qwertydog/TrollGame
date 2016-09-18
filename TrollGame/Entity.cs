using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class Entity
    {
        public Character Character { get; protected set; }

        public Entity(Character entity)
        {
            Character = entity;
        }
    }
}
