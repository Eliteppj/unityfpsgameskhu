using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryC : MonoBehaviour
{
    //인벤토리 꺼진 상태
    public static bool InventoryActivated = false;


    [SerializeField]
    private GameObject go_Inventory_Base;

    [SerializeField]
    private GameObject go_SlotsParent;

    private Slot[] slots;


    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();

    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInven();
    }

    private void TryOpenInven()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryActivated = !InventoryActivated;

            if (InventoryActivated)
                OpenInven();

            else
                CloseInven();
        }

    }


    private void OpenInven()
    {
        go_Inventory_Base.SetActive(true);
    }

    private void CloseInven()
    {
        go_Inventory_Base.SetActive(false);
    }

    public void AcItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Equipment != _item.itemtype)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i].item !=null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }

                }
              
            }
        }


        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;

            }

        }



    }
}
