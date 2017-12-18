//Custom libraries
using Enums;
using GameConsts;

namespace Models
{
    
    public class Player
    {
        public int Index;
        public PlayerType Type;
        public BoardOption Icon;

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

        public void BacktrackMove(int x, int y)
        {
            currentPlayer = (BoardData[y, x] == BoardOption.X) ? PlayerIndex.PLAYER1 : PlayerIndex.PLAYER2;
            BoardData[y, x] = BoardOption.NO_VAL;
        }

        public bool PlaceMove(int x, int y, BoardOption opt)
        {
            
            //Debug.Log("Model Cord:" + x + ", " + y);
            if (BoardData[y,x] == BoardOption.NO_VAL) {
                BoardData[y, x] = opt;
                currentPlayer = (opt == BoardOption.X)? PlayerIndex.PLAYER1:PlayerIndex.PLAYER2;
                //printBoardDebug();
                
                
                return true;
            }
           
            return false;
        }

        public WinnerStripeIndex GetWinMove()
        {
            BoardOption temp = (currentPlayer == PlayerIndex.PLAYER1) ? BoardOption.X : BoardOption.O;
            //check rows
            if (getBoardValue(0, 0) == temp && getBoardValue(0, 1) == temp && getBoardValue(0, 2) == temp) return WinnerStripeIndex.HT;
            if (getBoardValue(1, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(1, 2) == temp) return WinnerStripeIndex.HC;
            if (getBoardValue(2, 0) == temp && getBoardValue(2, 1) == temp && getBoardValue(2, 2) == temp) return WinnerStripeIndex.HB;

            //check colums
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 0) == temp && getBoardValue(2, 0) == temp) return WinnerStripeIndex.VL;
            if (getBoardValue(0, 1) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 1) == temp) return WinnerStripeIndex.VC;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 2) == temp && getBoardValue(2, 2) == temp) return WinnerStripeIndex.VR;

            //check diagonals
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 2) == temp) return WinnerStripeIndex.DL;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 0) == temp) return WinnerStripeIndex.DR;

            return WinnerStripeIndex.NULL;
        }

        public int CheckGameOver()
        {
            BoardOption temp;
            temp =(currentPlayer == PlayerIndex.PLAYER1)?BoardOption.X:BoardOption.O;
            
            //check rows
            if (getBoardValue(0, 0) == temp && getBoardValue(0, 1) == temp && getBoardValue(0, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;
            if (getBoardValue(1, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(1, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;
            if (getBoardValue(2, 0) == temp && getBoardValue(2, 1) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;

            //check colums
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 0) == temp && getBoardValue(2, 0) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;
            if (getBoardValue(0, 1) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 1) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 2) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;

            //check diagonals
            if (getBoardValue(0, 0) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 2) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;
            if (getBoardValue(0, 2) == temp && getBoardValue(1, 1) == temp && getBoardValue(2, 0) == temp) return (currentPlayer == PlayerIndex.PLAYER1) ? GameOver.PLAYER1 : GameOver.PLAYER2;


            if (checkForEmpty() == GameState.GAMEOVER) return GameOver.TIE;

            return GameOver.NO_VAL;
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

        
    }
    
}