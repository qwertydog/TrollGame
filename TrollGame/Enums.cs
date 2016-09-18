using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal enum Character
    {
        Blank = ' ',
        Wall = '#',
        Troll = 'T',
        PlayerUp = '^',
        PlayerRight = '>',
        PlayerDown = 'v',
        PlayerLeft = '<',
        Exit = 'X'
    }

    internal enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
}
