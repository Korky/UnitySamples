//System Libraries
using UnityEngine;
using UnityEngine.UI;
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

        BoardViewRef.Add(Row1);
        BoardViewRef.Add(Row2);
        BoardViewRef.Add(Row3);

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
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ClickOption(string cord)
    {

    }

}
