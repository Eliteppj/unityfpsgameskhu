using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUI : MonoBehaviour //아이템 구매, 사용 등 mane, CountUI를 매개하는 스크립트
{
    public GameObject CountUI;
    public  bool ison = false;
    public enum CurrentArea { MyInventory, Shop };
    public enum CurrentOption {Use,Equip,Discard, trade };

    public Text myitem;

    public string ItemName;
    public int itemcost;
    public int itemcount;
    public int forbidvalue1;
    public CurrentArea currentarea;
    public CurrentOption currentoption;
    public Item currentitem;
    public GameObject currentilc;



    private void Update()
    {
        if (ison == true)
            CountUI.SetActive(true);
    }

}
