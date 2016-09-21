using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollGame
{
    internal class Board
    {

        public Entity[,] GameBoard { get; }
        public int Width { get; }
        public int Height { get; }

        public Board(string[] boardLines)
        {
            Console.CursorVisible = false;

            Width = boardLines[0].Length + 2;
            Height = boardLines.GetLength(0) + 2;

            GameBoard = new Entity[Width, Height];

            for (var idy = 0; idy < Height; idy++)
            {
                for (var idx = 0; idx < Width; idx++)
                {
                    if (idx == 0 || idy == 0 || idx == Width - 1 || idy == Height - 1)
                    {
                        GameBoard[idx, idy] = new Entity(Character.Wall, idx, idy);
                    }
                    else
                    {
                        GameBoard[idx, idy] = new Entity((Character)boardLines[idy-1][idx-1], idx, idy);
                    }
                    
                }
            }
        }

        internal Tuple<int, int> GetPlayerLocation()
        {
            for (var idy = 0; idy < Height; idy++)
            {
                for (var idx = 0; idx < Width; idx++)
                {
                    if (GameBoard[idx, idy].Character == Character.PlayerDown ||
                        GameBoard[idx, idy].Character == Character.PlayerUp ||
                        GameBoard[idx, idy].Character == Character.PlayerLeft ||
                        GameBoard[idx, idy].Character == Character.PlayerRight)
                    {
                        return new Tuple<int, int>(idx, idy);
                    }
                }
            }
            return null;
        }

        internal void SetCharacter(int xpos, int ypos, Character character)
        {
            GameBoard[xpos, ypos] = new Entity(character, xpos, ypos);
        }

        internal void Print()
        {
            Console.SetCursorPosition(0, 0);

            for (var idy = 0; idy < Height; idy++)
            {
                for (var idx = 0; idx < Width; idx++)
                {
                    var character = GameBoard[idx, idy].Character;

                    if (character == Character.PlayerDown ||
                        character == Character.PlayerUp ||
                        character == Character.PlayerLeft ||
                        character == Character.PlayerRight)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (character == Character.Troll)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write((char)character);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
