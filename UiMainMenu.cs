using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiMainMenu : MonoBehaviour
{

    public Button start;
    public Button about;
    public Button cloaseabout;

    public GameObject mainmenu;
    public GameObject aboutmenu;

    public Animator animator;

    // Use this for initialization


    public static UiMainMenu inst;
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

        start.onClick.AddListener(StartF);
        about.onClick.AddListener(AboutF);
        cloaseabout.onClick.AddListener(CloseAboutF);
        aboutmenu.SetActive(false);
        mainmenu.SetActive(true);
        // animator = GetComponent<Animator>();
        // gameObject.SetActive(false);

        // distance.text = dd.ToString() + " (record: " + maxdd + ")";

    }

    // Update is called once per frame
    void Update()
    {
        // height.text     =   main.inst.currentHeight.ToString();
        // distance.text   =   main.inst.currentDistance.ToString();
    }

    void CloseAboutF()
    {
        aboutmenu.SetActive(false);
        mainmenu.SetActive(true);
    }
    void StartF()
    {
        animator.Play("mainmenuui");
        Uiingame.inst.tnt.gameObject.SetActive(true);
        //gameObject.SetActive(false);
        main.inst.GAME_STATE = main.gameState.begin;
       // Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene("game", LoadSceneMode.Additive);
    }
    void AboutF()
    {
        aboutmenu.SetActive(true);
        mainmenu.SetActive(false);
        // PlayerPrefs.SetInt("maxheight", 0);
        // PlayerPrefs.SetInt("maxdistance", 0);
    }
}
