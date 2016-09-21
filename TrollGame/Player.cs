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
        private Direction Direction { get; set; }

        private readonly Board _board;
        private int _xpos;
        private int _ypos;
        private readonly IList<Troll> _trolls;

        public Player(Character character, Random rand, IList<Troll> trolls, Board board, int xpos, int ypos) : base(character)
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
            _trolls = trolls;
        }

        
        public bool Move(Direction direction) // Returns true if next move is the exit
        {
            Entity nextSquare;

            switch (direction)
            {
                case Direction.Up:
                    nextSquare = _board.GameBoard[_xpos, _ypos - 1];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerUp);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(_xpos, _ypos - 1, Character.PlayerUp);
                            _board.SetCharacter(_xpos, _ypos, Character.Blank);
                            _ypos--;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[_xpos, _ypos - 2].Character != Character.Wall)
                            {
                                if (_board.GameBoard[_xpos, _ypos - 2].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != _xpos || troll.Y != _ypos - 2) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(_xpos, _ypos - 2, Character.Wall);
                                _board.SetCharacter(_xpos, _ypos - 1, Character.PlayerUp);
                                _board.SetCharacter(_xpos, _ypos, Character.Blank);
                                _ypos--;
                            }
                            break;
                    }
                    break;
                case Direction.Right:
                    nextSquare = _board.GameBoard[_xpos + 1, _ypos];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerRight);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(_xpos + 1, _ypos, Character.PlayerRight);
                            _board.SetCharacter(_xpos, _ypos, Character.Blank);
                            _xpos++;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[_xpos + 2, _ypos].Character != Character.Wall)
                            {
                                if (_board.GameBoard[_xpos + 2, _ypos].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != _xpos + 2 || troll.Y != _ypos) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(_xpos + 2, _ypos, Character.Wall);
                                _board.SetCharacter(_xpos + 1, _ypos, Character.PlayerRight);
                                _board.SetCharacter(_xpos, _ypos, Character.Blank);
                                _xpos++;
                            }
                            break;
                    }
                    break;
                case Direction.Down:
                    nextSquare = _board.GameBoard[_xpos, _ypos + 1];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerDown);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(_xpos, _ypos + 1, Character.PlayerDown);
                            _board.SetCharacter(_xpos, _ypos, Character.Blank);
                            _ypos++;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[_xpos, _ypos + 2].Character != Character.Wall)
                            {
                                if (_board.GameBoard[_xpos, _ypos + 2].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != _xpos || troll.Y != _ypos + 2) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(_xpos, _ypos + 2, Character.Wall);
                                _board.SetCharacter(_xpos, _ypos + 1, Character.PlayerDown);
                                _board.SetCharacter(_xpos, _ypos, Character.Blank);
                                _ypos++;
                            }
                            break;
                    }
                    break;
                case Direction.Left:
                    nextSquare = _board.GameBoard[_xpos - 1, _ypos];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(_xpos, _ypos, Character.PlayerLeft);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(_xpos - 1, _ypos, Character.PlayerLeft);
                            _board.SetCharacter(_xpos, _ypos, Character.Blank);
                            _xpos--;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[_xpos - 2, _ypos].Character != Character.Wall)
                            {
                                if (_board.GameBoard[_xpos - 2, _ypos].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != _xpos - 2 || troll.Y != _ypos) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(_xpos - 2, _ypos, Character.Wall);
                                _board.SetCharacter(_xpos - 1, _ypos, Character.PlayerLeft);
                                _board.SetCharacter(_xpos, _ypos, Character.Blank);
                                _xpos--;
                            }
                            break;
                    }
                    break;
            }
            return false;
        }
    }
}
