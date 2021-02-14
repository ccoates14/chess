﻿using System;


namespace Chess3
{
    class GameController
    {
        private bool gameOver;
        private Board board;
        private Player player1;
        private Player player2;

        public void start()
        {
            const bool topPlayer = true;
            gameOver = false;
            player1 = new Player(topPlayer);
            player2 = new Player(!topPlayer);
            board = new Board();

            run();
        }


        private void run()
        {
            Player currentPlayer = player1;
            Console.WriteLine("Enter moves by entering 0 - 7 for x index and 0 - 7 for y index seperated by a space, with position from to position seperated by a -");
            Console.WriteLine("For example, 0 1 - 0 2, would move white pawn from position 0 1 to position 0 2");

            board.printSelf();

            while (!gameOver)
            {

                Console.Write("Enter move: ");
                Tuple<int, int, int, int> userMove = sanitizePlayerInput(Console.ReadLine());

                if (userMove != null)
                {

                    currentPlayer.move(userMove);

                    board.printSelf();

                    if (currentPlayer == player1)
                    {
                        currentPlayer = player2;
                    }
                    else
                    {
                        currentPlayer = player1;
                    }

                    gameOver = board.isGameOver();
                }

            }



        }

        private Tuple<int, int, int, int> sanitizePlayerInput(string i)
        {
            //0 1 - 0 2
            try
            {
                string[] inputSplit = i.Split(" ");
                string x1 = inputSplit[0];
                string y1 = inputSplit[1];
                string x2 = inputSplit[3];
                string y2 = inputSplit[4];

                return new Tuple<int, int, int, int>(Int32.Parse(x1), Int32.Parse(y1), Int32.Parse(x2), Int32.Parse(y2));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid ars!");
                return null;
            }



        }
    }
}