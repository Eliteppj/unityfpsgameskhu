using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUI_ItemClick : MonoBehaviour, IPointerClickHandler
{
   
    
    public Item item;
    public GameObject gms;
    public GameObject UIMaster;
    public GameObject gui_menu;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UIMaster.GetComponent<MasterUI>().currentarea = MasterUI.CurrentArea.MyInventory;
            UIMaster.GetComponent<MasterUI>().currentitem = item;
            UIMaster.GetComponent<MasterUI>().itemcount = int.Parse(this.transform.GetChild(2).GetComponent<Text>().text);
            UIMaster.GetComponent<MasterUI>().currentilc = this.transform.gameObject;


            gui_menu.transform.GetChild(0).gameObject.SetActive(true);
            gui_menu.transform.GetChild(0).transform.position = new Vector3(this.transform.position.x + 150, this.transform.position.y-50);
           
        }

        else if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (Input.GetKey(KeyCode.LeftControl)&&!gms.GetComponent<GameStatusManager>().gameplaying)
            {
               
                UIMaster.GetComponent<MasterUI>().ItemName = this.transform.GetChild(0).GetComponent<Text>().text;
                UIMaster.GetComponent<MasterUI>().itemcost = (int)this.item.ItemSellCost;
                UIMaster.GetComponent<MasterUI>().currentitem = this.item;
                UIMaster.GetComponent<MasterUI>().forbidvalue1 = int.Parse(this.transform.GetChild(2).GetComponent<Text>().text);
                UIMaster.GetComponent<MasterUI>().myitem = this.transform.GetChild(2).GetComponent<Text>();
                UIMaster.GetComponent<MasterUI>().currentarea = MasterUI.CurrentArea.MyInventory;
                UIMaster.GetComponent<MasterUI>().currentoption = MasterUI.CurrentOption.trade;
                UIMaster.GetComponent<MasterUI>().ison = true;
            }
         

        }




    }

    // Start is called before the first frame update
    private void Start()
    {
        gms = GameObject.Find("Canvas");
        gui_menu = GameObject.Find("ManeO");
        UIMaster = GameObject.Find("New_InventorySet");


    }

    // Update is called once per frame
    void Update()
    {
        int tmp1 = int.Parse(this.transform.GetChild(2).GetComponent<Text>().text);
        if(tmp1 <=0)
        {
            Destroy(this.transform.gameObject);

        }

    
    }
}
