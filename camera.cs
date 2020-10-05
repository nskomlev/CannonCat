using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player;

    private float pX;
    private float pY;

    private Vector2 curVel;

    public float smoothX;
    public float smoothY;

    // Use this for initialization
    void Awake () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(player !=null)
        SmoothCamera();
    }

    void SmoothCamera()
    { 
        pX = Mathf.SmoothDamp(transform.position.x,player.transform.position.x, ref curVel.x,smoothX);
        pY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref curVel.y, smoothY);
        pY = 0;
        if(pX>0)
        transform.position = new Vector3(pX, pY, transform.position.z);
    }
}
