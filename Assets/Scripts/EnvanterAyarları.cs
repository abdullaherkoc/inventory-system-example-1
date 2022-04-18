using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvanterAyarları : MonoBehaviour
{
    public GameObject envanterPanel, tasınanitempanel, acıklamapanel;

    public bool envanter;

    void Start()
    {
        envanter = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            envanter = !envanter;
        }
        if (envanter)
        {
            envanterPanel.SetActive(true);
        }
        else
        {
            envanterPanel.SetActive(false);

        }
    }

    public void EnvanterAcMouseButton()
    {

        print("açtımm");
        envanter = !envanter;

    }

    public void EnvanterKapatMouseButton()
    {
        envanter = false;
    }

}
