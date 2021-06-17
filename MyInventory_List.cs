using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MyInventory_List : MonoBehaviour
{
    public Image img1;
    public int inveni = 0;
    public GameObject GUiComponent1;
    public GameObject GUIParent;
    public ItemDataBase myitemdb;
    public GameObject con;
    public GameObject mylist;
    public GameObject contentcon;
  
    


    private void Start()
    {
       
        myitemdb = GameObject.Find("DB_MyInventory").GetComponent<ItemDataBase>();

      
        for (; inveni < myitemdb.list.Length; inveni++)
        {
            con = Instantiate(GUiComponent1);
            con.transform.parent = GUIParent.transform;
            con.transform.GetChild(0).GetComponent<Text>().text = myitemdb.list[inveni].itemRef.itemName;
            con.transform.GetChild(1).GetComponent<Text>().text = myitemdb.list[inveni].itemRef.itemweight.ToString();
            con.transform.GetChild(2).GetComponent<Text>().text = myitemdb.list[inveni].ItemCount.ToString();
            con.GetComponent<GUI_ItemClick>().item = myitemdb.list[inveni].itemRef;


            if (myitemdb.list[inveni].ItemInraid)
                con.transform.GetChild(3).GetComponent<Image>().color = new Color(0, 255, 0, 255);

            else
                con.transform.GetChild(3).GetComponent<Image>().color = new Color(0, 255, 0, 0);
        }


    }

    private void Update()
    {
        


    }

    public void ItemAdd(Item _item, int count = 1)
    {
        Debug.Log(contentcon.transform.childCount);
       
 
        for (int i = 0 ; i < contentcon.transform.childCount; i++)
        {
            if (_item.itemName == contentcon.transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text)
            {
                int tmp1 = int.Parse(contentcon.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text);
                tmp1 += count;
                contentcon.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = tmp1.ToString();
                con.GetComponent<GUI_ItemClick>().item = _item;
                return ;
            }


        }
        con = Instantiate(GUiComponent1);
        con.transform.parent = GUIParent.transform;
        con.transform.GetChild(0).GetComponent<Text>().text = _item.itemName;
        con.transform.GetChild(1).GetComponent<Text>().text = _item.itemweight.ToString();
        con.transform.GetChild(2).GetComponent<Text>().text = count.ToString();


        con.GetComponent<GUI_ItemClick>().item = _item;
    }

    public void ItemDrop(Item _item, int count = 1)
    {



    }

   
}
