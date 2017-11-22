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
        public List<List<BoardOption>> BoardData;

        public void Init()
        {
            List<BoardOption> emptyRow = new List<BoardOption>(3);
            BoardData = new List<List<BoardOption>>(3);
            for (int y = 0; y < 3; y++)
            {
                emptyRow.Add(BoardOption.NO_VAL);
            }
            for (int y = 0; y < 3; y++) {
            
                BoardData.Add(emptyRow);
            }
        }

        public bool PlaceMove(int x, int y, BoardOption opt)
        {
            List<BoardOption> temp = new List<BoardOption>();
            temp = BoardData[y];
            Debug.Log("Model Cord:" + x + ", " + y);
            if (temp[x] == BoardOption.NO_VAL) {
                temp[x] = opt;
                BoardData[y] = temp;
                printRowDebug(temp);
                printBoardDebug();
                
                
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

        private void printBoardDebug()
        {
            foreach (List<BoardOption> t in BoardData)
            {
                List<string> r = new List<string>();
                foreach (BoardOption g in t)
                {
                    int q = (int)g;
                    r.Add(q.ToString());
                }

                string s = string.Join("\t", r.ToArray());
                Debug.Log(s + "\n");
            }
        }
        private void printRowDebug(List<BoardOption> row)
        {

                List<string> r = new List<string>();
                foreach (BoardOption g in row)
                {
                    int q = (int)g;
                    r.Add(q.ToString());
                }

                string s = string.Join("\t", r.ToArray());
                Debug.Log(s + "\n");
          
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

                if(BoardData[i].Exists(x=> x== BoardOption.NO_VAL))
                {
                    return GameState.IN_PROGRESS;
                }
            }

            return GameState.GAMEOVER;
        }

    }

}