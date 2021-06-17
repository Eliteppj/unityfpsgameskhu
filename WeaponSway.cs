using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    //기존 총기 위치\
    private Vector3 originpos;

    //현재 총기 위치
    private Vector3 currentpos;

    //sway 한계
    [SerializeField]
    private Vector3 limitpos;

    // 부드러운 
    [SerializeField]
    private Vector3 smoothsway;



    // Start is called before the first frame update
    void Start()
    {
        originpos =this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!InventoryC.InventoryActivated)
        {
            TrySway();
        }
        */
    }

    private void TrySway()
    {
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
        {
            Swaying();

        }
        else
            BackToOriginPos();

    }


    private void Swaying()
    {
        float _moveX = Input.GetAxisRaw("Mouse X");
        float _moveY = Input.GetAxisRaw("Mouse Y");

        currentpos.Set(Mathf.Clamp(Mathf.Lerp(currentpos.x, -_moveX, smoothsway.x), -limitpos.x, limitpos.x),
                       Mathf.Clamp(Mathf.Lerp(currentpos.y, -_moveY, smoothsway.y), -limitpos.y, limitpos.y), originpos.z);

        transform.localPosition = currentpos;
    }

    private void BackToOriginPos()
    {
        currentpos = Vector3.Lerp(currentpos, originpos,smoothsway.x);
        transform.localPosition = currentpos;
    }
}

