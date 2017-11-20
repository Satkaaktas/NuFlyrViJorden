using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
                                                        /*By Björn Andersson*/
public class TextColorChanger : MonoBehaviour
{
    Text lineText;

    public Text LineText
    {
        set { if (lineText == null) this.lineText = value; }
    }

    [YarnCommand("TColor")]
    public void ChangeTextColor(string textColor)
    {
        switch (textColor.ToUpper())
        {
            case "BLUE":
                lineText.color = Color.blue;
                break;

            case "RED":
                lineText.color = Color.red;
                break;

            case "BLACK":
                lineText.color = Color.black;
                break;
        }
    }
}
