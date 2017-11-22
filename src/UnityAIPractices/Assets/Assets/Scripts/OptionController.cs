using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Enums;

public class OptionController : MonoBehaviour
{

    public Sprite[] Options = new Sprite[3];
    
    public BoardOption CurrentOption;

    private bool valid = true;
    private Image Ref;
	// Use this for initialization
	void Start ()
    {
        Ref = GetComponent<Image>();
        GetComponent<Button>().targetGraphic = Ref;
        CurrentOption = BoardOption.NO_VAL;
        valid = false;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (valid) return;

        switch (CurrentOption) {

            case BoardOption.NO_VAL:
                //change graphic
                Ref.sprite = Options[(int)BoardOption.NO_VAL];
                CurrentOption = BoardOption.NO_VAL;
                valid = true;
                break;
            case BoardOption.X:
                //change graphic
                Ref.sprite = Options[(int)BoardOption.X];
                CurrentOption = BoardOption.X;
                valid = true;
                break;
            case BoardOption.O:
                //change graphic
                Ref.sprite = Options[(int)BoardOption.O];
                CurrentOption = BoardOption.O; 
                valid = true;
                break;
            
            default:
                break;
        }

	}

    public void ChangeOption(BoardOption opt)
    {
        if(CurrentOption == BoardOption.NO_VAL) CurrentOption = opt;
    }
}
