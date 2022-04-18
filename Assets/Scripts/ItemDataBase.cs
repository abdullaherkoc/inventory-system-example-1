using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items;
    void Awake()
    {
        items.Add(new Item("", "", 0, 0, 0,0, Item.ItemType.Bos));
       
        items.Add(new Item("Silah", "Hasar", 1, 0, 1,10, Item.ItemType.Silah));
        items.Add(new Item("Zırh", "savunma", 2, 1,1,0, Item.ItemType.Zirh));
        items.Add(new Item("Kask", "savunma", 3, 0, 1,10, Item.ItemType.Kask));
        items.Add(new Item("Ayakkabı","savunma", 4, 0, 1, 10, Item.ItemType.Ayakkabı));
        items.Add(new Item("Kalkan", "savunma", 5, 0, 1, 10, Item.ItemType.Kalkan));


        items.Add(new Item("Et", "yemek", 6, 1,50,0, Item.ItemType.Et));
        items.Add(new Item("Malzeme", "iksir", 7, 1, 50, 0, Item.ItemType.İksir));
        items.Add(new Item("Meyve", "Elma", 8, 1, 50, 0, Item.ItemType.Meyve));

    }
}
