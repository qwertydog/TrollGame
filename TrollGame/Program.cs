using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const string boardFileName = "board.txt";

            var boardLines = File.ReadAllLines(boardFileName);
            var board = new Board(boardLines);

            var random = new Random();

            Console.CursorVisible = false;

            var game = new TrollGame(board, random);
            game.Run();
        }
    }
}
