//System libraries
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
        public List<List<BoardOption>> BoardData;

        public void Init()
        {
            List<BoardOption> emptyRow = new List<BoardOption>(3);
            BoardData = new List<List<BoardOption>>(3);
            for(int y = 0; y < 3; y++) {
            
                BoardData.Add(emptyRow);
            }
        }

        public bool PlaceMove(int x, int y, BoardOption opt)
        {
            List<BoardOption> temp = BoardData[y];

            if(temp[x] == BoardOption.NO_VAL) {
                temp[x] = opt;
                BoardData[y] = temp;
                return true;
            }
           
            return false;
        }

        public GameOver CheckGameOver()
        {
            GameOver ret;
            ret = checkAllRows();
            if (ret != GameOver.IDLE) return ret;
            
            ret = checkAllDiagonals();
            if (ret != GameOver.IDLE) return ret;

            if (checkForEmpty() == GameState.GAMEOVER) return GameOver.TIE;

            return GameOver.IDLE;
        }

        private BoardOption getBoardValue(int x, int y)
        {
            List<BoardOption> temp = BoardData[y];
            return temp[x];
        }

        private GameOver checkAllRows()
        {
            int countforP1 = 0;
            int countforP2 = 0;

            for (int y = 0; y < 3; y++)
            {
                countforP1 = 0;
                countforP2 = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (getBoardValue(x, y) == BoardOption.X)
                    {
                        countforP1++;
                    }
                    if (getBoardValue(x, y) == BoardOption.O)
                    {
                        countforP2++;
                    }

                    if (countforP1 == 3)
                    {
                        //Player 1 Wins
                        return GameOver.P1;
                    }
                    if (countforP2 == 3)
                    {
                        //Player 2 Wins
                        return GameOver.P2;
                    }
                }
            }
            return GameOver.IDLE;
        }

        private GameOver checkAllDiagonals()
        {
            int countforP1 = 0;
            int countforP2 = 0;

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (y == x && getBoardValue(x, y) == BoardOption.X)
                    {
                        countforP1++;
                    }

                    if (y == x && getBoardValue(x, y) == BoardOption.O)
                    {
                        countforP2++;
                    }

                    if (countforP1 == 3)
                    {
                        //Player 1 Wins
                        return GameOver.P1;
                    }
                    if (countforP2 == 3)
                    {
                        //Player 2 Wins
                        return GameOver.P2;
                    }
                }
            }
            return GameOver.IDLE;
        }

        private GameState checkForEmpty()
        {

            for (int i = 0; i < 3; i++)
            {
                if(BoardData[i].BinarySearch(BoardOption.NO_VAL) > 0)
                {
                    return GameState.IN_PROGRESS;
                }
            }

            return GameState.GAMEOVER;
        }

    }
    public class Game
    {
        public List<Player> Players = new List<Player>(2);

        private GameState CurrentGameState;
        private PlayerIndex currentPlayer;
        private Board GameBoard;

        public void Init()
        {
            //start Game Init
            CurrentGameState = GameState.INIT;
            GameBoard.Init();
            currentPlayer = PlayerIndex.PLAYER1;

            //finish Game Init
            if (Players[0].Type != PlayerType.NULL && Players[1].Type != PlayerType.NULL)
                CurrentGameState = GameState.IN_PROGRESS;
            else
                Debug.Log("FATAL ERROR: Still Haven't Assigned Players in Game Model Class");
        }

    }

}