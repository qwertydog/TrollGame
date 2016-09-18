using System;
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
        private Random _rand;
        private bool _isFinished;
        private Player _player;

        public TrollGame(Board board, Random rand)
        {
            _board = board;
            _rand = rand;

            while (true)
            {
                var xpos = rand.Next(_board.Width);
                var ypos = rand.Next(_board.Height);

                if (_board.GameBoard[xpos, ypos].Character == Character.Blank)
                {
                    _player = new Player(Character.PlayerDown, rand, board, xpos, ypos);
                    _board.SetCharacter(xpos, ypos, _player.Character);
                    break;
                }
            }
        }

        

        public void Run()
        {
            while (!_isFinished)
            {
                _board.Print();

                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        _isFinished = _player.Move(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        _isFinished = _player.Move(Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        _isFinished = _player.Move(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        _isFinished = _player.Move(Direction.Left);
                        break;
                }
            }

            Console.WriteLine("You won!");
            while (true)
            {
                Console.Read();
            }
        }
    }
}
