using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stolb : MonoBehaviour {

    public Text km;

    public void Init(float curDist)
    {
        km.text = Mathf.RoundToInt(curDist).ToString() + "m";
    }
}
