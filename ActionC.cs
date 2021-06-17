using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionC : MonoBehaviour
{
    [SerializeField]
    private float range; //획득 사거리
    private bool pickupactivate = false; //습득 가능할 시 true


    private RaycastHit hitInfo; // 충돌체 정보 저장 값

    [SerializeField]
    private LayerMask layermask;

    [SerializeField]
    private GameObject hint;

    [SerializeField]
    private InventoryC theinventory;

    [SerializeField]
    private MyInventory_List icnt;

    public AudioSource as1;
    public AudioSource as2;
    public AudioSource as3;
    public AudioSource as4;


    // Update is called once per frame
    void Update()
    {
        CheckItem();
        TryAction();

    }



    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            Pickup();
        }
    }


    private void Pickup()
    {
        if (pickupactivate)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.name);

                icnt.ItemAdd(hitInfo.transform.GetComponent<Itempickup>().item);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDis();
                as1.Play();


            }
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layermask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            ItemInfoDis();

    }

    private void ItemInfoAppear()
    {
        pickupactivate = true;
        hint.SetActive(true);
    }

    private void ItemInfoDis()
    {
        pickupactivate = false;
        hint.SetActive(false);
    }

    public void SS_cash()
    {
        as2.Play();
    }

    public void SS_Buttonclick()
    {
        as3.Play();
    }

    public void SS_fail()
    {
        as4.Play();
    }


}

