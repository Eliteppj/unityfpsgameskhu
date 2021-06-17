using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_active_manetocount : MonoBehaviour
{

    public GameObject countmanager;
    Button button;

    public void OnClickButton()
    {
        countmanager.SetActive(true);
    }


}
