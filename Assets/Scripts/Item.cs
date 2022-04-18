using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[System.Serializable]
public class Item
{
    public string itemİsmi, itemBilgi;
    public int itemid, itemMiktar, itemDepoMiktar,itemHasar;
   
    public ItemType itemTipi;
    
    
    public Sprite itemİcon;
    public GameObject itemModel;

    public enum ItemType
    {

     Silah,        
     Zirh,
     Kask,
     Ayakkabı,
     Kalkan,


     Et,
     İksir,
     Meyve,

     Bos
    
    }
    public Item(string isim,string bilgi,int id ,int miktar,int depo, int hasar, ItemType tipi) 
    {
        itemİsmi = isim;
        itemBilgi = bilgi;
        itemid = id;
        itemMiktar = miktar;
        itemDepoMiktar = depo;
        itemHasar = hasar;
       
        itemTipi = tipi;

        itemİcon = Resources.Load<Sprite>(id.ToString());
        itemModel =Resources.Load<GameObject>("a");

    }
    public Item()
    {


    }



}
