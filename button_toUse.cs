using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_toUse : MonoBehaviour
{

    public GameObject UIMaster;
    public GameObject WeaponC;
    public GameObject countUI;
    Button button;

    public void OnClickButton()
    {
        if (UIMaster.GetComponent<MasterUI>().currentitem.itemtype==Item.ItemType.Food)
        {
            UIMaster.GetComponent<MasterUI>().currentoption = MasterUI.CurrentOption.Use;
            countUI.SetActive(true);

        }

        else if(UIMaster.GetComponent<MasterUI>().currentitem.itemtype == Item.ItemType.Equipment)
        {
            string itemtype= UIMaster.GetComponent<MasterUI>().currentitem.weapontype;
            string itemname = UIMaster.GetComponent<MasterUI>().currentitem.itemName;
            Debug.Log(itemtype);
            Debug.Log(itemname);
            WeaponC.GetComponent<WeaponManager>().MasterChanger(itemtype, itemname);
        }


    }


}
