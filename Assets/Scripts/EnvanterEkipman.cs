using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EnvanterEkipman : MonoBehaviour
{

    public GameObject ekipSilah,ekipZirh,ekipKalkan,ekipKask,ekipAyakkanbı;
    public int slotSayı;
    public Item item;
    public ItemDataBase dataİtem;
    public List<Item> items;
    Envanter env;
    void Start()
    {

        
        env = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        
    }


    void Update()
    {
        if (env.slot==ekipSilah)
        {
            İtemKontrol();
      

        
    }
        void İtemKontrol()
        {
            if (ekipSilah = env.slot)
            {
                if (item.itemid == env.tasımaİtem.itemid)
                {
                    env.İtemEkle(1, 1);

                }
            }
        }

    }  }
