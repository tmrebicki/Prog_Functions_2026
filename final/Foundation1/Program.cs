using System;
using System.Threading;

class Tetris
{
    static int width = 10;
    static int height = 20;
    static int[,] board = new int[height, width];

    static int[,] piece = new int[,]
    {
        {1, 1},
        {1, 1}
    };

    static int pieceX = 4;
    static int pieceY = 0;

    static void Main()
    {
        Console.CursorVisible = false;

        while (true)
        {
            HandleInput();

            if (!Move(0, 1))
            {
                Merge();
                ClearLines();
                SpawnPiece();
            }

            Draw();
            Thread.Sleep(300);
        }
    }

    static void HandleInput()
    {
        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.LeftArrow:
                Move(-1, 0);
                break;
            case ConsoleKey.RightArrow:
                Move(1, 0);
                break;
            case ConsoleKey.DownArrow:
                Move(0, 1);
                break;
            case ConsoleKey.UpArrow:
                Rotate();
                break;
        }
    }

    static bool Move(int dx, int dy)
    {
        if (!Collision(piece, pieceX + dx, pieceY + dy))
        {
            pieceX += dx;
            pieceY += dy;
            return true;
        }
        return false;
    }

    static void Rotate()
    {
        int h = piece.GetLength(0);
        int w = piece.GetLength(1);
        int[,] rotated = new int[w, h];

        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                rotated[x, h - y - 1] = piece[y, x];

        if (!Collision(rotated, pieceX, pieceY))
            piece = rotated;
    }

    static bool Collision(int[,] p, int xPos, int yPos)
    {
        for (int y = 0; y < p.GetLength(0); y++)
        {
            for (int x = 0; x < p.GetLength(1); x++)
            {
                if (p[y, x] == 0) continue;

                int xBoard = xPos + x;
                int yBoard = yPos + y;

                if (xBoard < 0 || xBoard >= width || yBoard >= height)
                    return true;

                if (yBoard >= 0 && board[yBoard, xBoard] == 1)
                    return true;
            }
        }
        return false;
    }

    static void Merge()
    {
        for (int y = 0; y < piece.GetLength(0); y++)
        {
            for (int x = 0; x < piece.GetLength(1); x++)
            {
                if (piece[y, x] == 1)
                    board[pieceY + y, pieceX + x] = 1;
            }
        }
    }

    static void ClearLines()
    {
        for (int y = height - 1; y >= 0; y--)
        {
            bool full = true;

            for (int x = 0; x < width; x++)
            {
                if (board[y, x] == 0)
                {
                    full = false;
                    break;
                }
            }

            if (full)
            {
                for (int row = y; row > 0; row--)
                {
                    for (int col = 0; col < width; col++)
                        board[row, col] = board[row - 1, col];
                }

                for (int col = 0; col < width; col++)
                    board[0, col] = 0;

                y++;
            }
        }
    }

    static void SpawnPiece()
    {
        piece = new int[,]
        {
            {1, 1},
            {1, 1}
        };

        pieceX = width / 2 - 1;
        pieceY = 0;

        if (Collision(piece, pieceX, pieceY))
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }
    }

    static void Draw()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                bool isPiece = false;

                for (int py = 0; py < piece.GetLength(0); py++)
                {
                    for (int px = 0; px < piece.GetLength(1); px++)
                    {
                        if (piece[py, px] == 1 &&
                            y == pieceY + py &&
                            x == pieceX + px)
                        {
                            isPiece = true;
                        }
                    }
                }

                Console.Write(isPiece || board[y, x] == 1 ? "#" : ".");
            }
            Console.WriteLine();
        }
    }
}