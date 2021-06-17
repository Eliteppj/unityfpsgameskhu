using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Button_Exit : MonoBehaviour
{

    public GameObject cmd1;
    Button button;
    public GameObject mss;

    public void OnClickButton()
    {
        mss.GetComponent<ActionC>().SS_Buttonclick();
        cmd1.GetComponent<gamequit>().exitm = true;
    }


}
