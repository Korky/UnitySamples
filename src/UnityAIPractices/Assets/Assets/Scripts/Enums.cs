namespace Enums
{
    public enum PlayerIndex
    {
        PLAYER1 = 0,
        PLAYER2
    }
    public enum PlayerType
    {
        NULL = 0,
        HUMAN,
        AI
    }
    public enum GameState
    {
        NOT_INIT = 0,
        INIT,
        IN_PROGRESS,
        GAMEOVER
    }
    public enum GameOver
    {
        IDLE = 0,
        P1,
        P2,
        TIE
    }
    public enum BoardOption
    {
        NO_VAL = 0,
        X,
        O
    }
    public enum WinnerStripeIndex
    {
        NULL=0,
        VC,
        VR,
        VL,
        HC,
        HT,
        HB,
        DL,
        DR
    }
}
