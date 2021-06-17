using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_tomenu : MonoBehaviour
{

    public GameObject gameObject_shop;
    public GameObject gameObject_inven;
    public GameObject GS;
    public GameObject mane;
    public GameObject countmanager;
    Button button;

    public void OnClickButton()
    {
        GS.SetActive(true);
        gameObject_inven.SetActive(false);
        gameObject_shop.SetActive(false);
        mane.SetActive(false);
        countmanager.SetActive(false);

    }


}
