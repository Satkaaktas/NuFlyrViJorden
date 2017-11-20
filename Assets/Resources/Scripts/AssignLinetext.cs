using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignLinetext : MonoBehaviour {               /*By Björn Andersson*/

    bool assigned = false;

    void Awake()
    {
        if (!assigned)
        {
            GameObject.Find("DialogueManager").GetComponent<TextColorChanger>().LineText = GetComponent<Text>();
        }
    }
}
