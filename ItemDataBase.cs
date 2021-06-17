using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemDataBase : MonoBehaviour
{
    int dic_leng;
   [Serializable]
   public class ItemInfo
    {
        public Item itemRef;
        public int ItemCount;
        public bool ItemInraid;
            
    }

    public ItemInfo[] list;


    private void Update()
    {
        dic_leng = list.Length;
        

    }
}
