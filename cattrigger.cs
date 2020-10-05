using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cattrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
        main.inst.gameControl(other.tag, other.gameObject);
        
        /*
        if (other.tag == "tnt")
        {
            Destroy(other.gameObject);
            main.inst.gameControl("tnt", other.gameObject);
        }
        else if (other.tag == "igli")
        {
            main.inst.gameControl("igli", other.gameObject);
        }
        else if (other.tag == "water")
        {
            main.inst.gameControl("water", other.gameObject);
        }
        else if (other.tag == "jump")
        {
            main.inst.gameControl("jump", other.gameObject);
        }
        else if (other.tag == "propan")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
            main.inst.gameControl("propan", other.gameObject);
        }
        else
        {
            //Debug.Log(other.tag + "- NOTtnt");
        }
        */
    }
}
