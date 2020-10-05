using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    public static Cat inst;
    public GameObject rukzak;
    private Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        if (inst == null)
        { inst = this; }
        else if (inst != null)
        { Destroy(gameObject); }
    }

    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        //rukzak.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        var vel = rb.velocity;      //to get a Vector3 representation of the velocity
        speed = vel.magnitude;             // to get magnitude

        if (speed <= 0.02F && main.inst.GAME_STATE== main.gameState.fly)
        {
            main.inst.gameControl("speed");
        }
    }

    public void RukzakToggle(bool toggle)
    {
        Debug.Log("RUKXAK");
        rukzak.SetActive(toggle);
    }

}

