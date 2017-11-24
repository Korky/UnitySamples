using System.Collections.Generic;

using Models;
using Enums;

namespace AI {
    public struct Move
    {
        public int x, y, score;
        public Move(int x,int y,int score)
        {
            this.x = x;
            this.y = y;
            this.score = score;
        }
        public Move(int score)
        {
            this.x = 0;
            this.y = 0;
            this.score = score;
        }
    }
    public class MinimaxAI
    {

        private Player human, ai;
        public MinimaxAI(Player h, Player cpu)
        {
            human = h;
            ai = cpu;
        }
        public Move PerformAIMove(ref Board board)
        {
            //TODO
            return getBestMove(ref board,ai);
        }
        private Move getBestMove(ref Board board,Player player)
        {
            //base case
            GameOver cond = board.CheckGameOver();
            if(cond == GameOver.P1)
            {
                if(ai.Index == PlayerIndex.PLAYER1){
                    return new Move(10);
                }
                else{
                    return new Move(-10);
                }
            }
            else if(cond == GameOver.TIE){
                return new Move(0);
            }


            //test all posible moves
            List<Move> moves = new List<Move>();

            for (int y = 0 ; y < 3 ; y++) {
                for (int x = 0; x < 3; x++) {
                    Move AIMove = new Move();
                    if (board.PlaceMove(x, y, player.Icon)) {
                    
                        if(player == ai) {
                        
                            AIMove = new Move(x, y,getBestMove(ref board,human).score);
                        }
                        else {
                        
                            AIMove = new Move(x, y, getBestMove(ref board, ai).score);
                        }
                        
                    }
                    moves.Add(AIMove);
                    board.BacktrackMove(x, y);
                }
            }


            //get best move
            int bestMove = 0;

            if(player == ai) {
                int bestScore = -100000;
                for(int i = 0; i < moves.Count; i++) {
                    if (moves[i].score > bestScore) {
                        bestMove = i;
                        bestScore = moves[i].score;
                    }
                }
            }
            else {
                int bestScore = 100000;
                for (int i = 0; i < moves.Count; i++) {
                
                    if (moves[i].score < bestScore) {
                    
                        bestMove = i;
                        bestScore = moves[i].score;
                    }
                }
            }
            return moves[bestMove];
        }
    }
}
