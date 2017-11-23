using UnityEngine;
using UnityEngine.UI;

using Enums;

public class OptionController : MonoBehaviour
{

    public Sprite[] Options = new Sprite[3];
    
    public BoardOption CurrentOption;

    private Image Ref;
	// Use this for initialization
	void Start ()
    {
        Ref = GetComponent<Image>();
        GetComponent<Button>().targetGraphic = Ref;
        Init();
	}
    public void Init()
    {
        CurrentOption = BoardOption.NO_VAL;
        Ref.sprite = Options[(int)BoardOption.NO_VAL];
        GetComponent<Button>().enabled = true;
    }
    public void ChangeOption(BoardOption opt)
    {
        if(CurrentOption == BoardOption.NO_VAL) CurrentOption = opt;
        Ref.sprite = Options[(int)opt];
        CurrentOption = opt;
        GetComponent<Button>().enabled = false;
    }
}
