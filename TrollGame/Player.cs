using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class Player : Entity
    {
        public Direction Direction { get; set; }

        private readonly Board _board;
        private int _xpos;
        private int _ypos;

        public Player(Character character, Random rand, Board board, int xpos, int ypos) : base(character)
        {
            var values = Enum.GetValues(typeof(Direction));
            Direction = (Direction)values.GetValue(rand.Next(values.Length));

            if (Direction == Direction.Down)
            {
                Character = Character.PlayerDown;
            }
            else if (Direction == Direction.Left)
            {
                Character = Character.PlayerLeft;
            }
            else if (Direction == Direction.Up)
            {
                Character = Character.PlayerUp;
            }
            else if (Direction == Direction.Right)
            {
                Character = Character.PlayerRight;
            }

            _board = board;
            _xpos = xpos;
            _ypos = ypos;
        }

        public bool Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerUp);
                    }
                    else if (_board.GameBoard[_xpos, _ypos - 1].Character == Character.Exit)
                    {
                        return true;
                    }
                    else if (_board.GameBoard[_xpos, _ypos - 1].Character == Character.Blank)
                    {
                        _board.SetCharacter(_xpos, _ypos - 1, Character.PlayerUp);
                        _board.SetCharacter(_xpos, _ypos, Character.Blank);
                        _ypos--;
                    }
                    break;
                case Direction.Right:
                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerRight);
                    }
                    else if (_board.GameBoard[_xpos + 1, _ypos].Character == Character.Exit)
                    {
                        return true;
                    }
                    else if (_board.GameBoard[_xpos + 1, _ypos].Character == Character.Blank)
                    {
                        _board.SetCharacter(_xpos + 1, _ypos, Character.PlayerRight);
                        _board.SetCharacter(_xpos, _ypos, Character.Blank);
                        _xpos++;
                    }
                    break;
                case Direction.Down:
                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerDown);
                    }
                    else if (_board.GameBoard[_xpos, _ypos + 1].Character == Character.Exit)
                    {
                        return true;
                    }
                    else if (_board.GameBoard[_xpos, _ypos + 1].Character == Character.Blank)
                    {
                        _board.SetCharacter(_xpos, _ypos + 1, Character.PlayerDown);
                        _board.SetCharacter(_xpos, _ypos, Character.Blank);
                        _ypos++;
                    }
                    break;
                case Direction.Left:
                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerLeft);
                    }
                    else if (_board.GameBoard[_xpos - 1, _ypos].Character == Character.Exit)
                    {
                        return true;
                    }
                    else if (_board.GameBoard[_xpos - 1, _ypos].Character == Character.Blank)
                    {
                        _board.SetCharacter(_xpos - 1, _ypos, Character.PlayerLeft);
                        _board.SetCharacter(_xpos, _ypos, Character.Blank);
                        _xpos--;
                    }
                    break;
            }
            return false;
        }
    }
}
