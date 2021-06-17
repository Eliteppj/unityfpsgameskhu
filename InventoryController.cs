using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    public GameObject gsm;
    [SerializeField]
    private GameObject Inventory;

    public GameObject Mane;
    public GameObject countmanager;
    public static bool InventoryActivated = false;
    // Start is called before the first frame update
  


    // Update is called once per frame
    void Update()
    {
        if (gsm.GetComponent<GameStatusManager>().caninventory == true)
        {
            TryOpenInventory();
           
        }
    }

    public void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryActivated = !InventoryActivated;

            if (InventoryActivated)
            {
                Cursor.visible = true;
                Inventory.SetActive(true);
            }
               

            else if(!InventoryActivated)
            {
                Inventory.SetActive(false);
                Cursor.visible = false;

            }

            Mane.SetActive(false);
            countmanager.SetActive(false);


        }
    }

    }

