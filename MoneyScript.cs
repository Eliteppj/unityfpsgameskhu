using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    
    public int Gold = 0;

    [SerializeField]
    GameObject var_gold;

    void Update()
    {
        var_gold.transform.GetComponent<Text>().text = Gold.ToString();
        
    }
}
