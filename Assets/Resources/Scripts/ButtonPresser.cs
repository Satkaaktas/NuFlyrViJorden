using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                                                                    /*By Björn Andersson && Timmy Alvelöv*/
public class ButtonPresser : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;
    
    KeyCode[] validKeys;

    DialogueUI dUI;

    void Start()
    {
        dUI = FindObjectOfType<DialogueUI>();
        validKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
    }
    
    void Update()
    {
        for (int i = 0; i < validKeys.Length; i++)
        {
            if (Input.GetKeyDown(validKeys[i]) && buttons[i].IsActive())
            {
                dUI.SetOption(i);               //Väljer ett alternativ i en dialog utifrån vilken knapp spelaren tryckt på
            }
        }
    }
}
