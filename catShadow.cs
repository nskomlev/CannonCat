using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catShadow : MonoBehaviour {
    public static catShadow inst;
    Transform trnsShadow;

    void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != null)
        {
            Destroy(gameObject);
        }

        trnsShadow = GetComponent<Transform>();
        gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {
        if (main.inst.GAME_STATE != main.gameState.begin)
        {
            trnsShadow.position = (new Vector3(main.inst.catTrns.position.x, -.49F, 0));
            var tmpScale = main.inst.currentHeight * -0.1F + 1.7F;
            if(tmpScale>0.32)
            trnsShadow.localScale=new Vector3(tmpScale, trnsShadow.localScale.y, trnsShadow.localScale.z);
        }
    }

    public void ShowShadow()
    {
        //go.SetActive(true);
       gameObject.SetActive(true);
    }
}
