using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnvanterSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler

{
    public Item item;
    public GameObject acıklamapanel;
    public int slotSayi;

    
    public Envanter er;

    public Image itemİcon;
    public Text itemMikter;

 


    void Start()
    {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        itemİcon = transform.GetChild(0).GetComponent<Image>();
        itemMikter = transform.GetChild(1).GetComponent<Text>();
        
    }
    void Update()
    {
        
          item = er.items[slotSayi];
         


        if (item.itemİsmi != null)
        {
            itemİcon.enabled = true;
            itemİcon.sprite = item.itemİcon;

            if (item.itemMiktar > 1)
            {
                itemMikter.enabled = true;
                itemMikter.text = item.itemMiktar.ToString();


            }

            else
               itemMikter.enabled = true;

        }
        else
            itemİcon.enabled = true;
        if (item.itemMiktar==0 ||item.itemİcon==null)
        {
           
            itemMikter.enabled=false;
            itemİcon.enabled = false;

           
        }


    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (item.itemİsmi != null)
        {
            er.BilgiPanelAc(item);
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (data.button.ToString() == "Left")
        {
            if (!er.tasımaAcık && item.itemİsmi != null)
            {
                er.TasımaPanelAc(item);
                er.items[slotSayi] = new Item();
            }
            else if (er.tasımaAcık) // bunlar bos slot tasıyoruz 
            {
                    if (slotSayi == 7)
                {
               
                    if (er.tasımaİtem.itemTipi==Item.ItemType.Silah)
                    {
                      er.items[slotSayi] = er.tasımaİtem;
                      er.TasımaPanelKapat();
                    }
                    else
                     StartCoroutine(beklemezamanı());
                    

                }
               else if (slotSayi == 8)
                {

                    if (er.tasımaİtem.itemTipi == Item.ItemType.Kask)
                    {
                        er.items[slotSayi] = er.tasımaİtem;
                        er.TasımaPanelKapat();
                    }
                    else
                        StartCoroutine(beklemezamanı());

                }
               else if (slotSayi == 9)
                {

                    if (er.tasımaİtem.itemTipi == Item.ItemType.Zirh)
                    {
                        er.items[slotSayi] = er.tasımaİtem;
                        er.TasımaPanelKapat();
                    }
                    else
                        StartCoroutine(beklemezamanı());

                }
               else if (slotSayi == 10)
                {

                    if (er.tasımaİtem.itemTipi == Item.ItemType.Kalkan)
                    {
                        er.items[slotSayi] = er.tasımaİtem;
                        er.TasımaPanelKapat();
                    }
                    else
                        StartCoroutine(beklemezamanı());

                }
               else if (slotSayi == 11)
                {

                    if (er.tasımaİtem.itemTipi == Item.ItemType.Ayakkabı)
                    {
                        er.items[slotSayi] = er.tasımaİtem;
                        er.TasımaPanelKapat();
                    }
                    else
                        StartCoroutine(beklemezamanı());

                }


                else if (item.itemİsmi == null)
                {
                    er.items[slotSayi] = er.tasımaİtem;
                    er.TasımaPanelKapat();
                }
                else
                {
                    if (item.itemİsmi == er.tasımaİtem.itemİsmi)
                    {
                        if (item.itemTipi == Item.ItemType.Et || item.itemTipi == Item.ItemType.İksir || item.itemTipi == Item.ItemType.Meyve)

                        {
                            er.items[slotSayi].itemMiktar += er.tasımaİtem.itemMiktar;
                            er.TasımaPanelKapat();
                            print("girdimburadayım1");

                        }
                       


                    } else if (item.itemİsmi != er.tasımaİtem.itemİsmi)
                        {
                            print("girdissdfdsdfsdfdsfsdfsfyım1");
                            Item yeniİtem = er.items[slotSayi];
                            er.items[slotSayi] = er.tasımaİtem;
                            er.tasımaİtem = yeniİtem;
                        }




                }


            }

        }

     
        
        
        
        if (data.button.ToString() == "Middle")
        {
            if (!er.tasımaAcık)
            {
                if (item.itemTipi == Item.ItemType.Et || item.itemTipi == Item.ItemType.İksir || item.itemTipi == Item.ItemType.Meyve)


                {
                    if (item.itemMiktar > 1)
                    {
                        int deger = item.itemMiktar / 2;
                        Item Yeniİtem = new Item(item.itemİsmi, item.itemBilgi, item.itemid, deger, item.itemDepoMiktar, item.itemHasar, item.itemTipi);
                        er.TasımaPanelAc(Yeniİtem);
                        int deger2 = item.itemMiktar - deger;
                        er.items[slotSayi].itemMiktar = deger2;
                    }
                }
            }

        }
    }




    public void OnPointerExit(PointerEventData data)
    {
        er.bilgiPanelKapat();
    }

    public void OnDrag(PointerEventData data)
    {

    }

    IEnumerator beklemezamanı() 
    {
        er.acıklamapanelac();
        yield return new WaitForSeconds(1);
        er.acıklamapanelkapt();
    }




}
