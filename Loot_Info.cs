using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loot_Info : MonoBehaviour
{
    public int range;
    public GameObject[] itemprefab;
    public GameObject con;


    public void gen()
    {
        int result = Random.Range(0, itemprefab.Length);

        if (itemprefab[result] != null)
        {
           
            con = Instantiate(itemprefab[result]);
            con.transform.position = this.transform.position;
        }
    }

    public void _reset()
    {
        if (con != null)
        {
            DestroyImmediate(con, true);
            gen();
        }
        else
            gen();
    }
}
