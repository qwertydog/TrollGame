using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class Troll : Entity
    {
        private readonly Board _board;
        private readonly Random _rand;
        private readonly AStar _aStar;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Troll(Character character, Random rand, Board board, AStar aStar, int xpos, int ypos) : base(character)
        {
            _board = board;
            _rand = rand;
            _aStar = aStar;

            X = xpos;
            Y = ypos;
        }

        public void Move() // Randomly choose what direction to go in
        {
            var values = Enum.GetValues(typeof(Direction));
            var moveFinished = false;

            while (!moveFinished)
            {
                var direction = (Direction)values.GetValue(_rand.Next(values.Length));
                Entity nextSquare;

                switch (direction)
                {
                    case Direction.Down:
                        nextSquare = _board.GameBoard[X, Y + 1];

                        switch (nextSquare.Character)
                        {
                            case Character.Blank:
                            case Character.PlayerDown:
                            case Character.PlayerUp:
                            case Character.PlayerLeft:
                            case Character.PlayerRight:
                                _board.SetCharacter(X, Y + 1, Character.Troll);
                                _board.SetCharacter(X, Y, Character.Blank);
                                Y++;
                                moveFinished = true;
                                break;
                            case Character.Wall:
                                if (_board.GameBoard[X, Y + 2].Character != Character.Wall)
                                {
                                    _board.SetCharacter(X, Y + 2, Character.Wall);
                                    _board.SetCharacter(X, Y + 1, Character.Troll);
                                    _board.SetCharacter(X, Y, Character.Blank);
                                    Y++;
                                    moveFinished = true;
                                }
                                break;
                        }
                        break;
                    case Direction.Up:
                        nextSquare = _board.GameBoard[X, Y - 1];

                        switch (nextSquare.Character)
                        {
                            case Character.Blank:
                            case Character.PlayerDown:
                            case Character.PlayerUp:
                            case Character.PlayerLeft:
                            case Character.PlayerRight:
                                _board.SetCharacter(X, Y - 1, Character.Troll);
                                _board.SetCharacter(X, Y, Character.Blank);
                                Y--;
                                moveFinished = true;
                                break;
                            case Character.Wall:
                                if (_board.GameBoard[X, Y - 2].Character != Character.Wall)
                                {
                                    _board.SetCharacter(X, Y - 2, Character.Wall);
                                    _board.SetCharacter(X, Y - 1, Character.Troll);
                                    _board.SetCharacter(X, Y, Character.Blank);
                                    Y--;
                                    moveFinished = true;
                                }
                                break;
                        }
                        break;
                    case Direction.Left:
                        nextSquare = _board.GameBoard[X - 1, Y];

                        switch (nextSquare.Character)
                        {
                            case Character.Blank:
                            case Character.PlayerDown:
                            case Character.PlayerUp:
                            case Character.PlayerLeft:
                            case Character.PlayerRight:
                                _board.SetCharacter(X - 1, Y, Character.Troll);
                                _board.SetCharacter(X, Y, Character.Blank);
                                X--;
                                moveFinished = true;
                                break;
                            case Character.Wall:
                                if (_board.GameBoard[X - 2, Y].Character != Character.Wall)
                                {
                                    _board.SetCharacter(X - 2, Y, Character.Wall);
                                    _board.SetCharacter(X - 1, Y, Character.Troll);
                                    _board.SetCharacter(X, Y, Character.Blank);
                                    X--;
                                    moveFinished = true;
                                }
                                break;
                        }
                        break;
                    case Direction.Right:
                        nextSquare = _board.GameBoard[X + 1, Y];

                        switch (nextSquare.Character)
                        {
                            case Character.Blank:
                            case Character.PlayerDown:
                            case Character.PlayerUp:
                            case Character.PlayerLeft:
                            case Character.PlayerRight:
                                _board.SetCharacter(X + 1, Y, Character.Troll);
                                _board.SetCharacter(X, Y, Character.Blank);
                                X++;
                                moveFinished = true;
                                break;
                            case Character.Wall:
                                if (_board.GameBoard[X + 2, Y].Character != Character.Wall)
                                {
                                    _board.SetCharacter(X + 2, Y, Character.Wall);
                                    _board.SetCharacter(X + 1, Y, Character.Troll);
                                    _board.SetCharacter(X, Y, Character.Blank);
                                    X++;
                                    moveFinished = true;
                                }
                                break;
                        }
                        break;
                }
            }
        }
    }
}
