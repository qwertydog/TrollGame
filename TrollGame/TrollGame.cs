﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class TrollGame
    {
        private readonly Board _board;
        private readonly Player _player;
        private Random _rand;
        private readonly List<Troll> _trolls;

        public TrollGame(Board board, Random rand, AStar aStar, int numTrolls)
        {
            _board = board;
            _rand = rand;
            _trolls = new List<Troll>(numTrolls);

            while (_trolls.Count != numTrolls)
            {
                var xpos = rand.Next(_board.Width);
                var ypos = rand.Next(_board.Height);

                if (_board.GameBoard[xpos, ypos].Character != Character.Blank) continue;

                if (_player == null)
                {
                    var values = Enum.GetValues(typeof(Direction));
                    var direction = (Direction)values.GetValue(rand.Next(values.Length));

                    var character = Character.PlayerUp;
                    switch (direction)
                    {
                        case Direction.Down:
                            character = Character.PlayerDown;
                            break;
                        case Direction.Left:
                            character = Character.PlayerLeft;
                            break;
                        case Direction.Up:
                            character = Character.PlayerUp;
                            break;
                        case Direction.Right:
                            character = Character.PlayerRight;
                            break;
                    }

                    _player = new Player(character, _trolls, board, xpos, ypos);
                    _board.SetCharacter(xpos, ypos, character);
                }
                else
                {
                    _trolls.Add(new Troll(Character.Troll, rand, board, aStar, xpos, ypos));
                    _board.SetCharacter(xpos, ypos, Character.Troll);
                }
            }
        }

        

        public void Run()
        {
            var isFinished = false;
            var playersTurn = true;
            var playerWon = true;

            while (!isFinished)
            {
                _board.Print();

                if (playersTurn)
                {
                    var input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.UpArrow:
                            isFinished = _player.Move(Direction.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            isFinished = _player.Move(Direction.Down);
                            break;
                        case ConsoleKey.RightArrow:
                            isFinished = _player.Move(Direction.Right);
                            break;
                        case ConsoleKey.LeftArrow:
                            isFinished = _player.Move(Direction.Left);
                            break;
                    }
                    playersTurn = false;
                }
                else
                {
                    foreach (var troll in _trolls)
                    {
                        troll.Move();
                    }
                    playersTurn = true;
                }

                if (_board.GetPlayerLocation() == null)
                {
                    playerWon = false;
                    break;
                }

            }

            if (playerWon)
            {
                Console.WriteLine("You won!");
            }
            else
            {
                Console.WriteLine("You lost :(");
            }

            while (true)
            {
                Console.Read();
            }
        }
    }
}
