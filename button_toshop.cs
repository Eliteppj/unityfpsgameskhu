using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_toshop : MonoBehaviour
{
    public GameObject gameObject_shop;
    public GameObject gameObject_inven;
    public GameObject GS;
    Button button;
    public GameObject mss;
    public void OnClickButton()
    {
        mss.GetComponent<ActionC>().SS_Buttonclick();
        GS.SetActive(false);
        gameObject_inven.SetActive(true);
        gameObject_shop.SetActive(true);
    }


}
