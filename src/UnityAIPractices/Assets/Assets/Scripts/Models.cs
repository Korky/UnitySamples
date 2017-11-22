//System libraries
using UnityEngine;
using System.Collections.Generic;

//Custom libraries
using Enums;

namespace Models
{
    
    public class Player
    {
        public PlayerIndex Index;
        public PlayerType Type;
    }
    public class Board
    {
        public BoardOption[,] BoardData;
        private PlayerIndex currentPlayer;

        //public
        public void Init()
        {
            currentPlayer = PlayerIndex.PLAYER1;

            BoardData = new BoardOption[3, 3];
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    BoardData[y, x] = BoardOption.NO_VAL;
                    
                }
              
            }
            
        }

        public bool PlaceMove(int x, int y, BoardOption opt)
        {
            
            Debug.Log("Model Cord:" + x + ", " + y);
            if (BoardData[y,x] == BoardOption.NO_VAL) {
                BoardData[y, x] = opt;
                currentPlayer = (opt == BoardOption.X)? PlayerIndex.PLAYER1:PlayerIndex.PLAYER2;
                printBoardDebug();
                
                
                return true;
            }
           
            return false;
        }

        public GameOver CheckGameOver()
        {
            BoardOption temp;
            temp =(currentPlayer == PlayerIndex.PLAYER1)?BoardOption.X:BoardOption.O;
            
            //check rows
            if (getBoardValue(0, 0) == temp && getBoardValue(0, 1) == temp && getBoardValue(0, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;
            if (getBoardValue(1, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(1, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;
            if (getBoardValue(2, 0) == temp && getBoardValue(2, 1) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;

            //check colums
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 0) == temp && getBoardValue(2, 0) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;
            if (getBoardValue(0, 1) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 1) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 2) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;

            //check diagonals
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 0) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.P1 : GameOver.P2;


            if (checkForEmpty() == GameState.GAMEOVER) return GameOver.TIE;

            return GameOver.IDLE;
        }

        //private
        private BoardOption getBoardValue(int x, int y)
        {
            return BoardData[y,x];
        }

        private GameState checkForEmpty()
        {

            for (int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    if(BoardData[y,x] == BoardOption.NO_VAL)
                    {
                        return GameState.IN_PROGRESS;
                    }
                }
                
            }

            return GameState.GAMEOVER;
        }

        private void printBoardDebug()
        {
            string[] p = new string[3];
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    int t = (int)BoardData[x, y];
                    p[x] = t.ToString();

                }
                Debug.Log(string.Join("\t", p)+"\n");
            }

        }
    }

}