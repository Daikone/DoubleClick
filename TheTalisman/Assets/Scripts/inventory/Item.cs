using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        sun,
        moon,
        stars,
        sky,
        magicBranch,
        sunriseBull,
        sunsetBull,
        windBessing,
        guardSword,
        none,


    };
    public bool isSelected;
    public Type itemType;

}
