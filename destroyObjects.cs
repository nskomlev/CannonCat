using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObjects : MonoBehaviour {

    // private GameObject transformObj;
    private Transform trans;
    // Use this for initialization
    void Start () {
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {

       // Debug.Log(main.inst.cat.GetComponent<Transform>().position.x);

        if (trans.position.x+ 10F < Cat.inst.GetComponent<Transform>().position.x)
        {
           // Debug.Log("Destroy");
            Destroy(gameObject);
        }
	}
}
