using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public bool isFull;


    UIclick s1;
    UIclick s2;
    UIclick s3;
    UIclick s4;
    UIclick s5;

    private void Awake()
    {
        s1 = slot1.GetComponent<UIclick>();
        s2 = slot2.GetComponent<UIclick>();
        s3 = slot3.GetComponent<UIclick>();
        s4 = slot4.GetComponent<UIclick>();
        s5 = slot5.GetComponent<UIclick>();

    }
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {

      
        setItems();
    }
    public void setItems()
    {   if (GameManager.inventory.GetList().Count >= 1)
        { s1.setItem(GameManager.inventory.GetList()[0]);
            
        }
        
        if (GameManager.inventory.GetList().Count >= 2)
        { s2.setItem(GameManager.inventory.GetList()[1]);
            
        }
        
        if (GameManager.inventory.GetList().Count >= 3)
        { s3.setItem(GameManager.inventory.GetList()[2]);
            
        }
        
        if (GameManager.inventory.GetList().Count >= 4)
        { s4.setItem(GameManager.inventory.GetList()[3]);
           
        }
        
        if (GameManager.inventory.GetList().Count >= 5)
        {
            s5.setItem(GameManager.inventory.GetList()[4]);
           
        }
       
    }
}
