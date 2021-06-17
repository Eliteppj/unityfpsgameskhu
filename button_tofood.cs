using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class button_tofood : MonoBehaviour
{
    Button button;
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;

    public void OnClickButton()
    {
        bt1.SetActive(false);
        bt2.SetActive(false);
        bt3.SetActive(true);

    }
}
