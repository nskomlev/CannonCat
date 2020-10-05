using UnityEngine;
using System.Collections;

public class dulo : MonoBehaviour
{
    public static dulo inst;
    //Public Vars
    public Camera cameraT;
    public float speed;

    //Private Vars
    private Vector3 mousePosition;
    private Vector3 direction;
    private float distanceFromObject;
    private Vector3 trigTrns;
    private float tmpAngl=-45;
    private float realAngl = -45;
    // Use this for initialization
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
    }

    void FixedUpdate()
    {
        trigTrns = transform.Find("markpos").gameObject.GetComponent<Transform>().transform.position;

        if (Input.GetButton("Fire2"))
        {

            //Grab the current mouse position on the screen
            mousePosition = cameraT.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cameraT.transform.position.z));
            tmpAngl = Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg - 90;

            if (tmpAngl > -75 && tmpAngl < -10)
            {
                realAngl = tmpAngl;
                //Rotates toward the mouse
                GetComponent<Rigidbody2D>().transform.eulerAngles = new Vector3(0, 0, realAngl);
                //Judge the distance from the object and the mouse
                distanceFromObject = (Input.mousePosition - cameraT.WorldToScreenPoint(transform.position)).magnitude;
                //Move towards the mouse
                GetComponent<Rigidbody2D>().AddForce(direction * speed * distanceFromObject * Time.deltaTime);


            }
        }//End Move Towards If Case

    }//End Fire3 If case

    public Vector3 getDuloTrigger()
    {
        return trigTrns;
    }
    public float getDuloAngel()
    {
        return realAngl;
    }
}
     
