using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIclick : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    Item item;
    bool isSelected;
    ItemVisuals visuals;
    Image icon;
    public int index;
    void Awake()
    {
        visuals = GameObject.Find("ItemVisuals").GetComponent<ItemVisuals>();
        icon= GameObject.Find("SlotImg"+index).GetComponent<Image>();
        item = new Item { itemType = Item.Type.none };

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetImage();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            if (Input.GetKey(KeyCode.Space))
            {
               //temporarily removed. Will be added later on
               
            }
        }

        //Use this to tell when the user left-clicks on the Button
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            AccesoryScript.SetItem(item);
            
        }
    }
    public void SetImage()
    {
        if (item.itemType != Item.Type.none)
        {
            icon.color = new Color(icon.color.r, icon.color.g,icon.color.b,1);
            switch (item.itemType)
            {
                case Item.Type.sun:
                    icon.sprite = visuals.sprite1;
                    break;
                case Item.Type.moon:
                    icon.sprite = visuals.sprite2;
                    break;
                case Item.Type.stars:
                    icon.sprite = visuals.sprite3;
                    break;
                case Item.Type.sky:
                    icon.sprite = visuals.sprite4;
                    break;
                case Item.Type.magicBranch:
                    icon.sprite = visuals.sprite5;
                    break;
                case Item.Type.sunriseBull:
                    icon.sprite = visuals.sprite6;
                    break;
                case Item.Type.sunsetBull:
                    icon.sprite = visuals.sprite7;
                    break;
                case Item.Type.windBessing:
                    icon.sprite = visuals.sprite8;
                    break;
                case Item.Type.guardSword:
                    icon.sprite = visuals.sprite9;
                    break;
                default:
                    break;

            }
        }
        else
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 0);


    }
    public void setItem(Item ity)
    {
        item = ity;
    }
    public Item GetItem()
    {
        return item;
    }
}
