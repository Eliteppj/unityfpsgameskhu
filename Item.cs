using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="New item/item")]
public class Item : ScriptableObject
{
    public int itemKeyCode; //아이템의 키코드
    public string itemName; //아이템 이름
    public Sprite itemImage; //아이템 이미지
    public ItemType itemtype; //아이템 유형
    public GameObject itemPrefab; // 아이템 프리팹

    public int up_hp;
    public int up_energy;
    public int up_water;
    public string weapontype; // 무기 유형
    public enum ItemType
    {
        Equipment,
        Food,
        Grocery,
        etc

    }

    public double ItemBuyCost; // 아이템 가격
    public double ItemSellCost; //아이템 판매금
    public bool InRaid = false; // 아이템 인레이드 마크
    public double itemweight; // 아이템 무게
    [TextArea]
    public string des; //아이템 설명
}
