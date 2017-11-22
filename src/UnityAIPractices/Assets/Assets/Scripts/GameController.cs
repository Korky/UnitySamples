//System Libraries
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

//Custom Libraries
using Models;
using Enums;

public class GameController : MonoBehaviour
{
    //views
    public Image[] Row1 = new Image[3];
    public Image[] Row2 = new Image[3];
    public Image[] Row3 = new Image[3];

    public Image[,] GridRef = new Image[3, 3];
    //views ref
    private ArrayList BoardViewRef = new ArrayList(3);
    
    //models
    public List<Player> Players = new List<Player>(2);
    private GameState CurrentGameState;
    private PlayerIndex currentPlayer;
    private Board GameBoard;

	// Use this for initialization
	void Start ()
    {
        GridRef[0, 0] = Row1[0];
        GridRef[0, 1] = Row1[1];
        GridRef[0, 2] = Row1[2];
        GridRef[1, 0] = Row2[0];
        GridRef[1, 1] = Row2[1];
        GridRef[1, 2] = Row2[2];
        GridRef[2, 0] = Row3[0];
        GridRef[2, 1] = Row3[1];
        GridRef[2, 2] = Row3[2];
        BoardViewRef.Add(Row1);
        BoardViewRef.Add(Row2);
        BoardViewRef.Add(Row3);

        //set up players [temporary]
        Player p1 = new Player();
        p1.Index = PlayerIndex.PLAYER1;
        p1.Type = PlayerType.HUMAN;
        Players.Add(p1);

        Player p2 = new Player();
        p2.Index = PlayerIndex.PLAYER2;
        p2.Type = PlayerType.HUMAN;
        Players.Add(p2);

        //Initialiaze Game
        GameInit();


    }
	private void ModifyOptionView(int x,int y,BoardOption opt)
    {
        GridRef[y,x].GetComponent<OptionController>().ChangeOption(opt);

    }
	// Update is called once per frame
	void Update ()
    {

	}

    public void ClickOption(string cord)
    {
        int x, y;

        x = int.Parse(cord[0].ToString());
        y = int.Parse(cord[1].ToString());
        Debug.Log("UI Clicked Cord:" + x + ", " + y);
        if (currentPlayer == PlayerIndex.PLAYER1)
        {
            if (GameBoard.PlaceMove(x, y, BoardOption.X))
            {
                ModifyOptionView(x, y, BoardOption.X);
                currentPlayer = PlayerIndex.PLAYER2;
            }


        }
        else
        {
            if (GameBoard.PlaceMove(x, y, BoardOption.O))
            {
                ModifyOptionView(x, y, BoardOption.O);
                currentPlayer = PlayerIndex.PLAYER1;
            }
        }

        GameOver checker = GameBoard.CheckGameOver();
        Debug.Log(checker);
        if(checker != GameOver.IDLE)
        {
            //End Game
            CurrentGameState = GameState.GAMEOVER;
        }
    }

    private void GameInit()
    {
        //start Game Init
        CurrentGameState = GameState.INIT;
        GameBoard = new Board();
        GameBoard.Init();
        currentPlayer = PlayerIndex.PLAYER1;

        //finish Game Init
        if (Players[0].Type != PlayerType.NULL && Players[1].Type != PlayerType.NULL)
            CurrentGameState = GameState.IN_PROGRESS;
        else
            Debug.Log("FATAL ERROR: Still Haven't Assigned Players in Game Model Class");

    }
}
