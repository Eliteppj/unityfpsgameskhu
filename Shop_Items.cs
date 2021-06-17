using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop_Items : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Item item;

    [SerializeField]
    GameObject text_des;

    [SerializeField]
    GameObject cntmanager;

    [SerializeField]
    GameObject UIMaster;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                cntmanager.SetActive(true);
                UIMaster.GetComponent<MasterUI>().ItemName = this.transform.GetChild(0).GetComponent<Text>().text;
                UIMaster.GetComponent<MasterUI>().itemcost =(int)item.ItemBuyCost;
                UIMaster.GetComponent<MasterUI>().currentitem = this.item;
                UIMaster.GetComponent<MasterUI>().currentarea = MasterUI.CurrentArea.Shop;
                UIMaster.GetComponent<MasterUI>().currentoption = MasterUI.CurrentOption.trade;
            }
            else
                text_des.GetComponent<Text>().text = item.des;

        }

     

    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        this.transform.GetChild(3).GetComponent<Text>().text = item.itemweight.ToString();
        this.transform.GetChild(4).GetComponent<Text>().text = item.ItemBuyCost.ToString();
    }

  
}
