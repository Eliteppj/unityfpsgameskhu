using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_todiscard : MonoBehaviour
{

    public GameObject UIMaster;
    public GameObject countUI;
    Button button;

    public void OnClickButton()
    {
        UIMaster.GetComponent<MasterUI>().currentoption = MasterUI.CurrentOption.Discard;
        countUI.SetActive(true);

    }


}
