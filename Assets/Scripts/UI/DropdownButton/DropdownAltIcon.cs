using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownAltIcon : MonoBehaviour
{
    public Sprite IconSprite { get; private set; }

    private void Awake()
    {
        IconSprite = GetComponent<Image>().sprite;
    }
}
