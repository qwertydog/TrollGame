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
        private readonly IList<Troll> _trolls;

        public Player(Character character, IList<Troll> trolls, Board board, int xpos, int ypos) : base(character, xpos, ypos)
        {
            switch (character)
            {
                case Character.PlayerDown:
                    Direction = Direction.Down;
                    break;
                case Character.PlayerUp:
                    Direction = Direction.Up;
                    break;
                case Character.PlayerLeft:
                    Direction = Direction.Left;
                    break;
                case Character.PlayerRight:
                    Direction = Direction.Right;
                    break;
            }

            _board = board;
            _trolls = trolls;
        }

        
        public bool Move(Direction direction) // Returns true if next move is the exit
        {
            Entity nextSquare;

            switch (direction)
            {
                case Direction.Up:
                    nextSquare = _board.GameBoard[X, Y - 1];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(X, Y, Character.PlayerUp);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(X, Y - 1, Character.PlayerUp);
                            _board.SetCharacter(X, Y, Character.Blank);
                            Y--;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[X, Y - 2].Character != Character.Wall)
                            {
                                if (_board.GameBoard[X, Y - 2].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != X || troll.Y != Y - 2) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(X, Y - 2, Character.Wall);
                                _board.SetCharacter(X, Y - 1, Character.PlayerUp);
                                _board.SetCharacter(X, Y, Character.Blank);
                                Y--;
                            }
                            break;
                    }
                    break;
                case Direction.Right:
                    nextSquare = _board.GameBoard[X + 1, Y];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(X, Y, Character.PlayerRight);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(X + 1, Y, Character.PlayerRight);
                            _board.SetCharacter(X, Y, Character.Blank);
                            X++;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[X + 2, Y].Character != Character.Wall)
                            {
                                if (_board.GameBoard[X + 2, Y].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != X + 2 || troll.Y != Y) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(X + 2, Y, Character.Wall);
                                _board.SetCharacter(X + 1, Y, Character.PlayerRight);
                                _board.SetCharacter(X, Y, Character.Blank);
                                X++;
                            }
                            break;
                    }
                    break;
                case Direction.Down:
                    nextSquare = _board.GameBoard[X, Y + 1];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(X, Y, Character.PlayerDown);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(X, Y + 1, Character.PlayerDown);
                            _board.SetCharacter(X, Y, Character.Blank);
                            Y++;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[X, Y + 2].Character != Character.Wall)
                            {
                                if (_board.GameBoard[X, Y + 2].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != X || troll.Y != Y + 2) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(X, Y + 2, Character.Wall);
                                _board.SetCharacter(X, Y + 1, Character.PlayerDown);
                                _board.SetCharacter(X, Y, Character.Blank);
                                Y++;
                            }
                            break;
                    }
                    break;
                case Direction.Left:
                    nextSquare = _board.GameBoard[X - 1, Y];

                    if (Direction != direction)
                    {
                        Direction = direction;
                        _board.SetCharacter(X, Y, Character.PlayerLeft);
                    }
                    else switch (nextSquare.Character)
                    {
                        case Character.Exit:
                            return true;
                        case Character.Blank:
                            _board.SetCharacter(X - 1, Y, Character.PlayerLeft);
                            _board.SetCharacter(X, Y, Character.Blank);
                            X--;
                            break;
                        case Character.Wall:
                            if (_board.GameBoard[X - 2, Y].Character != Character.Wall)
                            {
                                if (_board.GameBoard[X - 2, Y].Character == Character.Troll)
                                {
                                    foreach (var troll in _trolls)
                                    {
                                        if (troll.X != X - 2 || troll.Y != Y) continue;
                                        _trolls.Remove(troll);
                                        break;
                                    }
                                }
                                _board.SetCharacter(X - 2, Y, Character.Wall);
                                _board.SetCharacter(X - 1, Y, Character.PlayerLeft);
                                _board.SetCharacter(X, Y, Character.Blank);
                                X--;
                            }
                            break;
                    }
                    break;
            }
            return false;
        }
    }
}
