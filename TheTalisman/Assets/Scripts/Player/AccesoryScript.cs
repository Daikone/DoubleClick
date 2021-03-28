using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesoryScript : MonoBehaviour
{
    SpriteRenderer render;
    public static Item activeItem;
    public Sprite look1;
    public Sprite look2;
    public Sprite look3;
    public Sprite look4;
    public Sprite look5;
    public Sprite look6;
    public Sprite look7;
    public Sprite look8;
    public Sprite look9;
    symbolPool pool;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        pool = GetComponent<symbolPool>();
        activeItem = new Item { itemType = Item.Type.none };
    }

    // Update is called once per frame
    void Update()
    {
        
        SetLook();
        if(activeItem.itemType!=Item.Type.none)
        {
            GameManager.addRange = 2;
        }
        Action();
    }
    void SetLook()
    {

        if (activeItem.itemType != Item.Type.none)
        {
            render.enabled = true;
            switch (activeItem.itemType)
            {
                case Item.Type.sun:
                    render.sprite = look1;
                    break;
                case Item.Type.moon:
                    render.sprite = look2;
                    break;
                case Item.Type.stars:
                    render.sprite = look3;
                    break;
                case Item.Type.magicBranch:
                    render.sprite = look4;
                    break;
                case Item.Type.sunriseBull:
                    render.sprite = look5;
                    break;
                case Item.Type.sunsetBull:
                    render.sprite = look6;
                    break;
                case Item.Type.windBessing:
                    render.sprite = look7;
                    break;
                case Item.Type.sky:
                    render.sprite = look8;
                    break;
                case Item.Type.guardSword:
                    render.sprite = look9;
                    break;

                default:

                    break;
            }
        }
        else
            render.enabled = false;

    }
    public static void SetItem(Item iteme)
    {
        activeItem = iteme;
    }
    void Action()
    {
        GameManager.bonusDmg = 0;
        GameManager.extraHeal = 0;
        GameManager.EnableProj = false;
        switch (activeItem.itemType)
        {
            case Item.Type.sun:
                GameManager.bonusDmg = 4;
                GameManager.extraHeal = 0.3f;
                break;
            case Item.Type.moon:
                
                break;
            case Item.Type.stars:
                
                break;
            case Item.Type.magicBranch:
                GameManager.EnableProj = true;
                GameManager.projIndex = 0;
                pool.nrProjectiles = 3;
                
                break;
            case Item.Type.sunriseBull:
                GameManager.extraHeal =1.5f;
                
                break;
            case Item.Type.sunsetBull:
               
                break;
            case Item.Type.windBessing:
                
                break;
            case Item.Type.sky:
                
                break;
            case Item.Type.guardSword:
                
                break;
            default:
                
                break;
        }
        
    }
}
