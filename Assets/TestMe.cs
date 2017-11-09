using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TestMe : MonoBehaviour {

    [YarnCommand("testme")]
    public void Lol()
    {
        print("sha brush");
    }
}