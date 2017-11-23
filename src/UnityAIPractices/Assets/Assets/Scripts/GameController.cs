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
    public Image[] GUIRef = new Image[9];
    public Image[,] GridRef = new Image[3, 3];
    public Canvas[] MenuFlow = new Canvas[4]; 

    //models
    private List<Player> Players = new List<Player>(2);
    private Player currentPlayer;
    private Board GameBoard;
    private int currentMenuIndex;

    //utils
    private Player p1, p2;


    // Overrides
    void Awake()
    {
        p1 = new Player();
        p2 = new Player();
        currentPlayer = new Player();
        currentMenuIndex = 0;

    }
	void Start ()
    {

        //Setup UI Pointers
        GridRef[0, 0] = GUIRef[0];
        GridRef[0, 1] = GUIRef[1];
        GridRef[0, 2] = GUIRef[2];
        GridRef[1, 0] = GUIRef[3];
        GridRef[1, 1] = GUIRef[4];
        GridRef[1, 2] = GUIRef[5];
        GridRef[2, 0] = GUIRef[6];
        GridRef[2, 1] = GUIRef[7];
        GridRef[2, 2] = GUIRef[8];

        //start Menu Flow
        MenuFlow[currentMenuIndex].gameObject.SetActive(true);
    }
	
    //public
    public void ClickOption(string cord)
    {
        int x, y;
        x = int.Parse(cord[0].ToString());
        y = int.Parse(cord[1].ToString());
        //Debug.Log("UI Clicked Cord:" + x + ", " + y);


        if (GameBoard.PlaceMove(x, y, currentPlayer.Icon))
        {
            ModifyOptionView(x, y, currentPlayer.Icon);            
        }
        currentPlayer = (currentPlayer.Index == PlayerIndex.PLAYER1) ? Players[1] : Players[0];


        GameOver checker = GameBoard.CheckGameOver();
        Debug.Log(checker);
        if(checker != GameOver.IDLE)
        {
            //End Game
            GameEnd(checker);
        }
    }

    public void ClickMenuOption(string opt)
    {
        
        
        switch (opt)
        {
            case "PVP":
                p1.Type = PlayerType.HUMAN;
                p2.Type = PlayerType.HUMAN;
                ChangeMenu();
                break;
            case "PVE":
                p1.Type = PlayerType.HUMAN;
                p2.Type = PlayerType.AI;
                ChangeMenu();
                break;
            case "EVE":
                p1.Type = PlayerType.AI;
                p2.Type = PlayerType.AI;
                ChangeMenu();
                break;
            case "X":
                p1.Icon = BoardOption.X;
                p1.Index = PlayerIndex.PLAYER1;
                p2.Icon = BoardOption.O;
                p2.Index = PlayerIndex.PLAYER2;
                GameSetup(p1, p2);
                break;
            case "O":
                p2.Icon = BoardOption.X;
                p2.Index = PlayerIndex.PLAYER1;
                p1.Icon = BoardOption.O;
                p1.Index = PlayerIndex.PLAYER2;
                GameSetup(p1, p2);
                break;
            default:
                break;
        }
    }

    //private
    private void ChangeMenu()
    {
        MenuFlow[currentMenuIndex++].gameObject.SetActive(false);

        if (currentMenuIndex > 4) currentMenuIndex = 0;
        
        MenuFlow[currentMenuIndex].gameObject.SetActive(true);

    }

    private void ModifyOptionView(int x,int y,BoardOption opt)
    {
        GridRef[x,y].GetComponent<OptionController>().ChangeOption(opt);

    }

    private void GameSetup(Player p1, Player p2)
    {
        Players.Add(p1);
        Players.Add(p2);

        //Initialiaze Game
        GameInit();
    }

    private void GameEnd(GameOver winner)
    {
        ChangeMenu();
    }

    private void GameInit()
    {
        //start Game Init
        GameBoard = new Board();
        GameBoard.Init();


        //finish Game Init
        if (Players[0].Type != PlayerType.NULL || Players[1].Type != PlayerType.NULL)
            currentPlayer = (Players[0].Index == PlayerIndex.PLAYER1) ? Players[0] : Players[1];
        else
            Debug.Log("FATAL ERROR: Still Haven't Assigned Players in Game Model Class");


        ChangeMenu();
    }
}
