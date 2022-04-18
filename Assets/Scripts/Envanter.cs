using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Envanter : MonoBehaviour
{
    public List<Item> items;

    

    public int slotMiktar, baslangıcMiktar;
    public GameObject slot, BilgiPanel, tasımaPanel,ekipmanSlot,acıklamapanel;
    public ItemDataBase dataİtem;
    public bool bilgiAcık, tasımaAcık;
    public Item bilgiİtem, tasımaİtem;

    void Start()
    {

        for (int i = baslangıcMiktar; i < slotMiktar; i++)
        {
            
            
                print("oluşturddum");

           GameObject slots = (GameObject)Instantiate(slot);
            slots.transform.SetParent(this.gameObject.transform);
            slots.GetComponent<EnvanterSlot>().slotSayi = i;
            slots.name = "slot " + i;
            

         

 

        }

        for (int i = 0; i <slotMiktar; i++)
        {
         
       
            items.Add(new Item());

            
        }
        İtemEkle(1,6); 
        İtemEkle(2,4);
        İtemEkle(4,3);
        İtemEkle(3,2);
        
        İtemEkle(5, 2);
        İtemEkle(6, 2);
        İtemEkle(7, 2);
        İtemEkle(8, 2);
        İtemEkle(5, 3);
        İtemEkle(6, 4);
        İtemEkle(7, 3);

    }
         public void İtemEkle(int id, int miktar)
    {
        for (int i = 0; i < dataİtem.items.Count; i++)
        {
            if (dataİtem.items[i].itemid == id)
            {
                Item yeniitem = new Item(dataİtem.items[i].itemİsmi, dataİtem.items[i].itemBilgi,
                                     dataİtem.items[i].itemid, miktar, dataİtem.items[i].itemDepoMiktar,
                                     dataİtem.items[i].itemHasar, dataİtem.items[i].itemTipi);


                if (yeniitem.itemTipi==Item.ItemType.Et || yeniitem.itemTipi == Item.ItemType.İksir /*||*//* yeniitem.itemTipi == Item.ItemType.Meyve*/)
                {
                    SlotUzerineEkle(yeniitem);
                }
                else if (yeniitem.itemMiktar>1)
                {
                    int deger = yeniitem.itemMiktar - 1;
                         Item yeniİtem2 = new Item(yeniitem.itemİsmi, yeniitem.itemBilgi,yeniitem.itemid, 
                              deger, yeniitem.itemDepoMiktar, yeniitem.itemHasar, yeniitem.itemTipi);

                    yeniitem.itemMiktar = 1;

                    BosSlotİtemEkle(yeniitem);

                    İtemEkle(yeniİtem2.itemid,yeniİtem2.itemMiktar);         
                    
                }else
                {
                    BosSlotİtemEkle(yeniitem);
                }

            }
        }
        
    }
    void BosSlotİtemEkle(Item item)
    {
        for (int i = 12; i < items.Count; i++)
        {
            if (items[i].itemİsmi == null)
            {
                items[i] = item;
                break;
            }
        }

    }


    public void SlotUzerineEkle(Item item) 
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemİsmi==item.itemİsmi)
            {
                items[i].itemMiktar += item.itemMiktar;
                break;
            }
            if (i ==items.Count-1)
            {
                BosSlotİtemEkle(item);
            }
        }
    
    }
    public void BilgiPanelAc(Item item)
    {
        bilgiAcık = true;
        bilgiİtem = item;
        BilgiPanel.SetActive(true);

    }
    public void bilgiPanelKapat()
    {
        bilgiAcık = false;
        //bilgiİtem = item;
        BilgiPanel.SetActive(false);

    }
    public void TasımaPanelAc(Item item)
    {
        tasımaAcık = true;
        tasımaİtem = item;
        tasımaPanel.SetActive(true);

    }
    public void TasımaPanelKapat()
    {
        tasımaAcık = false;
        tasımaİtem = null;
        tasımaPanel.SetActive(false);

    }
    public void acıklamapanelac()
    {
      
        acıklamapanel.SetActive(true);

    }
    public void acıklamapanelkapt()
    {
      
        acıklamapanel.SetActive(false);

    }

     void Update()
    {
        if (bilgiAcık)
        {
            BilgiPanel.SetActive(true);

            BilgiPanel.transform.GetChild(0).GetComponent<Text>().text = bilgiİtem.itemİsmi;
            BilgiPanel.transform.GetChild(1).GetComponent<Text>().text = bilgiİtem.itemBilgi;
            //BilgiPanel.gameObject.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
      

        if (tasımaAcık)
        {
            
            tasımaPanel.transform.GetChild(0).GetComponent<Image>().sprite = tasımaİtem.itemİcon;
           
            tasımaPanel.gameObject.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (tasımaİtem.itemMiktar>1)
            {
                tasımaPanel.transform.GetChild(1).GetComponent<Text>().enabled = true;
                tasımaPanel.transform.GetChild(1).GetComponent<Text>().text = tasımaİtem.itemMiktar.ToString();
            }
            else
            {
                tasımaPanel.transform.GetChild(1).GetComponent<Text>().enabled = false;
            }
        }
        
    }


}
