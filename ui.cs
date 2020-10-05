using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour {

    public Text height;
    public Text distance;
    public GameObject recordPlateALL;
    public GameObject recordPlateDD;
    public GameObject recordPlateHH;
    public Button restart;
    public Animator animatorRecord;
    public Animator animator;
    // Use this for initialization
    public static ui inst;


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

        restart.onClick.AddListener(restartF);
        gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
       // height.text     =   main.inst.currentHeight.ToString();
       // distance.text   =   main.inst.currentDistance.ToString();
    }


    public IEnumerator setResults()  // ПО СУТИ game over
    {

        yield return new WaitForSeconds(0.5F);

        gameObject.SetActive(true);
        recordPlateDD.SetActive(false);
        recordPlateHH.SetActive(false);
        recordPlateALL.SetActive(false);

        int hh = Mathf.RoundToInt(main.inst.maxHeight * 10);
        int dd = Mathf.RoundToInt(main.inst.currentDistance * 10);

        int maxhh = PlayerPrefs.GetInt("maxheight", 0);
        int maxdd = PlayerPrefs.GetInt("maxdistance", 0);

        if (maxhh < hh)
        { PlayerPrefs.SetInt("maxheight", hh);
            recordPlateHH.SetActive(true);
        }

        if (maxdd < dd)
        { PlayerPrefs.SetInt("maxdistance", dd);
            recordPlateDD.SetActive(true);
        }

        if (maxhh < hh || maxdd < dd)
        {
            recordPlateALL.SetActive(true);
            fxController.inst.PlaySingle(fxController.inst.record, 2, 0.5F);
            StartCoroutine(showRecord());
        }

        

        height.text     = hh.ToString() + " (record: " + maxhh + ")";
        distance.text   = dd.ToString() + " (record: " + maxdd + ")";
    }

    public IEnumerator showRecord()
    {
        yield return new WaitForSeconds(0.5F);
        animatorRecord.Play("runrecord");
    }

        void restartF()
    {
        gameObject.SetActive(false);
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("game", LoadSceneMode.Additive);
    }
}
