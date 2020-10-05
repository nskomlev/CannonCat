using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class body : MonoBehaviour {
    public static body inst;
    static float t = 0.0f;
    public float curPower;

    [Header("Unity Stuff")]
    public Image powerBar;
    public float speed= 2f;
    public float minimum = 0.0F;
    public float maximum = 1.0F;

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


    // Update is called once per frame
    void Update () {

        if (main.inst.GAME_STATE==main.gameState.begin) {
            // animate the position of the game object...
            powerBar.fillAmount = Mathf.Lerp(minimum, maximum, t);

            // .. and increase the t interpolater
            t += speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.

            curPower = powerBar.fillAmount;
           // Debug.Log(curPower);

            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.0f;
            }

            
        }
    }

    public float getCurPow()
    {
        float cp = 1;

        if (curPower<=0.15F)
        {
            cp = 0.15f;
        }
        return cp;
    }
}
