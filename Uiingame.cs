using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uiingame : MonoBehaviour {


    public Text rykzakCount;
    public Button tnt;
    public GameObject rukzak;
    public GameObject fire;

    public static Uiingame inst;

    void Awake()
    {
        if (inst == null)         inst = this;
        else if (inst != null)    Destroy(gameObject);

        tnt.onClick.AddListener(FireF);
        setButtonType("fire");
        //tnt.SetActive(false);
        tnt.gameObject.SetActive(false);
    }

    void FireF()
    {
        main.inst.ButtonPress();
    }

    public void setButtonType(string type)
    {

        switch (type)
        {
            case "fire":
                rukzak.SetActive(false);
                fire.SetActive(true);
                break;
            case "rukzak":
                rukzak.SetActive(true);
                fire.SetActive(false);
                break;
        }
    }

    public void setRukzakUiCount(int rukzakCount)
    {
        string uiText = rukzakCount.ToString();
        rykzakCount.text = uiText;
    }
}
