using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enums;
using GameConsts;


namespace GameLogic
{

    public class BaseLogic
    {
        //memebers
        protected PlayerIndex m_currentPlayer;

        //methods
        public int CheckVictory()
        {
            if (isGameOver() != GameOver.TIE)
            {
                if (m_currentPlayer == PlayerIndex.PLAYER1) return GameOver.PLAYER1;
                if (m_currentPlayer == PlayerIndex.PLAYER2) return GameOver.PLAYER2;
            }
            else
            {
                return GameOver.TIE;
            }

            return GameOver.NO_VAL;
        }

        public void NextTurn()
        {
            m_currentPlayer = (m_currentPlayer == PlayerIndex.PLAYER1) ? PlayerIndex.PLAYER2 : PlayerIndex.PLAYER1;
        }

        protected int isGameOver()
        {
            //used for override
            return GameOver.TIE;
        }
        


    }

}