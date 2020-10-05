using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

    private Transform birdTrns;
    public float birdSpeed= 0.005F;
    // Use this for initialization
    void Awake () {
        birdTrns = gameObject.GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        birdTrns.position = new Vector3(birdTrns.position.x - birdSpeed, birdTrns.position.y, 0);
    }
}
