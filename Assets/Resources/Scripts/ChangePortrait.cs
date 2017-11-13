using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
                                                            /*By Björn Andersson*/
public class ChangePortrait : MonoBehaviour {

    [SerializeField]
    Sprite[] sprites;

    [YarnCommand("ChangePortrait")]
    public void ChangeSprite(string newSprite)          //Byter porträttet som visas under konversationer
    {
        foreach(Sprite sprite in this.sprites)
        {
            if (sprite.name == newSprite)
            {
                GetComponent<Image>().sprite = sprite;
            }
        }
    }
}
