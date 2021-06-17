using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_to_disable_obj : MonoBehaviour
{
    [SerializeField]
    GameObject go1;

    [SerializeField]
    GameObject go2;
    Button button;

    public GameObject UIMaster;
    public void OnClickButton()
    {
        UIMaster.GetComponent<MasterUI>().ison = false;
        go1.SetActive(false);
        go2.SetActive(false);
       
    }

}
