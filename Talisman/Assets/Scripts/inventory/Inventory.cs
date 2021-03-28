using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> inventory;
    // Start is called before the first frame update
    public Inventory()
    {
        inventory = new List<Item>();
        inventory.Capacity = 5;
        
        
    }
    private void Awake()
    {
        
    }
    public List<Item> GetList()
    {
        return inventory;
    }
    public void AddItem(Item iy)
    {
        inventory.Add(iy);
        if (inventory.Count > 5)
            RemoveItem(iy);
        
    }
    public bool IsItemIn(Item ite)
    {   bool isy=false;
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemType == ite.itemType)
                isy = true;
        }
        
        return isy;
    }
    public void RemoveItem(Item iy)
    {
        inventory.Remove(iy);
    }
   
}
