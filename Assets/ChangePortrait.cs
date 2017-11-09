using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class ChangePortrait : MonoBehaviour {

    [SerializeField]
    Sprite[] sprites;

    [YarnCommand("ChangePortrait")]
    public void ChangeSprite(string newSprite)
    {
        print(newSprite);
        foreach(Sprite sprite in this.sprites)
        {
            if (sprite.name == newSprite)
            {
                GetComponent<Image>().sprite = sprite;
            }
        }
    }
}
