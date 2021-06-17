
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_confirm : MonoBehaviour
{
    public GameObject UIMaster;
    public GameObject Countmanager;
    public GameObject MoneyFrame;
    public GameObject Mane;
    public GameObject player1;
    public GameObject WeaponC;
    public GameObject mcc;
    public int gold = 0;
    public int count = 0;
    public int totalcost = 0;
    public int cost = 0;
    Button button;


    [SerializeField]
    private GameObject icnt;

    public void OnClickButton()
    {
        if (UIMaster.GetComponent<MasterUI>().currentarea == MasterUI.CurrentArea.MyInventory) // 내 인벤토리의 ILC를 클릭
        {
            if (UIMaster.GetComponent<MasterUI>().currentoption == MasterUI.CurrentOption.trade) // 컨트롤+좌클릭으로 트레이드 모드일 때
            {
                count = int.Parse(Countmanager.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text); //입력한 수량
                gold = MoneyFrame.transform.GetChild(0).GetComponent<MoneyScript>().Gold; // 현재 플레이어의 소지금
                cost = UIMaster.GetComponent<MasterUI>().itemcost; //판매하려는 아이템 1개의 가격*
                totalcost = count * cost;

                if (count > UIMaster.GetComponent<MasterUI>().forbidvalue1)
                {
                    mcc.GetComponent<ActionC>().SS_fail();
                    Debug.Log("수량이 맞지 않습니다.");
                }
                else
                {
                    mcc.GetComponent<ActionC>().SS_cash();
                    MoneyFrame.transform.GetChild(0).GetComponent<MoneyScript>().Gold = gold + totalcost;
                    int tmp1 = int.Parse(UIMaster.GetComponent<MasterUI>().myitem.text);
                    int tmp2 = tmp1 - count;
                    UIMaster.GetComponent<MasterUI>().myitem.text = tmp2.ToString();

                }


            }

            else if(UIMaster.GetComponent<MasterUI>().currentoption == MasterUI.CurrentOption.Discard) // Discard모드일 때
            {
                count = int.Parse(Countmanager.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text); //입력한 수량
                int tmp1 = int.Parse(UIMaster.GetComponent<MasterUI>().currentilc.transform.GetChild(2).GetComponent<Text>().text);

                if (tmp1 >= count)
                {
                    UIMaster.GetComponent<MasterUI>().currentilc.transform.GetChild(2).GetComponent<Text>().text = (tmp1 - count).ToString();
                    WeaponC.GetComponent<WeaponManager>().MasterChanger("Melee", "barehand");
                }
                else
                    mcc.GetComponent<ActionC>().SS_fail();
                    Debug.Log("수량이 맞지 않습니다.");
            }


            else if (UIMaster.GetComponent<MasterUI>().currentoption == MasterUI.CurrentOption.Use) //Use 모드 일때
            {
                if(UIMaster.GetComponent<MasterUI>().currentitem.itemtype==Item.ItemType.Food) //아이템이 소모품일 때
                {
                    count = int.Parse(Countmanager.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text);

                    if (UIMaster.GetComponent<MasterUI>().itemcount >= count)
                    {
                        player1.GetComponent<PlayerStatus>().Player_HP += UIMaster.GetComponent<MasterUI>().currentitem.up_hp * count;
                        player1.GetComponent<PlayerStatus>().Player_Energy += UIMaster.GetComponent<MasterUI>().currentitem.up_energy * count;
                        player1.GetComponent<PlayerStatus>().Player_Water += UIMaster.GetComponent<MasterUI>().currentitem.up_water * count;
                        int tmp1 = int.Parse(UIMaster.GetComponent<MasterUI>().currentilc.transform.GetChild(2).GetComponent<Text>().text);
                        UIMaster.GetComponent<MasterUI>().currentilc.transform.GetChild(2).GetComponent<Text>().text = (tmp1 - count).ToString();

                    }
                    else
                        mcc.GetComponent<ActionC>().SS_fail();
                    Debug.Log("수량이 맞지 않습니다.");
                }

            }







        }
        else if (UIMaster.GetComponent<MasterUI>().currentarea == MasterUI.CurrentArea.Shop)
        {
            count = int.Parse(Countmanager.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>().text);
            gold = MoneyFrame.transform.GetChild(0).GetComponent<MoneyScript>().Gold; // 현재 플레이어의 소지금
            cost = UIMaster.GetComponent<MasterUI>().itemcost; //구매하려는 아이템 1개의 가격
            totalcost = cost * count; //구매하려는 아이템의 합계가격


            if (gold >= totalcost)
            {
                mcc.GetComponent<ActionC>().SS_cash();
                MoneyFrame.transform.GetChild(0).GetComponent<MoneyScript>().Gold = gold - totalcost;
                icnt.GetComponent<MyInventory_List>().ItemAdd(UIMaster.GetComponent<MasterUI>().currentitem, count);

            }
            else
            {
                mcc.GetComponent<ActionC>().SS_fail();
                Debug.Log("구매불가능");
            }
        }
        UIMaster.GetComponent<MasterUI>().ison = false;
        Countmanager.SetActive(false);
        Mane.SetActive(false);
    }
}
