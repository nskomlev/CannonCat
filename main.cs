using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  УПРАВЛЕНИЯ ТАЧЕМ
 */


public class main : MonoBehaviour {


    public static main inst;

    public float scrollSpeed = 0.5f;
    public float heightTMP = 3.2F; // FIX THEN

    public float currentHeight = 0;
    public float currentDistance = 0;
    public float maxHeight = 0;
    public Rigidbody2D catRb;
    public Transform catTrns;

    public enum gameState
    {
        menu,
        begin,
        fly,
        dead,
        stop
    }

    public gameState GAME_STATE = gameState.menu;

    public GameObject cannon;
    public GameObject tnt;
    public GameObject igli;
    public GameObject jump;
    public GameObject stolbObj;
    public GameObject birdObj;
    public GameObject cat;
    public GameObject water;
    public GameObject bonus;

    private int placeObjectInt = 5; //первое вхождение
    public  int placeObjectRast = 10; //интревал

    private int placeStolbInt = 20; //первое вхождение
    public  int placeStolbRast = 20; //интревал


    public int freeRukzakBombs = 3;
    public int currentRukzakBombs = 0;


    Dictionary<string, int> STAT = new Dictionary<string, int>();


    // Use this for initialization
    void Awake () {
        if (inst == null)
        {
            inst = this;
        }else if(inst != null)
        {
            Destroy(gameObject);
        }

        catTrns = cat.GetComponent<Transform>();
        catRb = cat.GetComponent<Rigidbody2D>();



        // ЗАГРУЖАЕМ ВЗРЫВЧАТКУ В РЮКЗАК
        currentRukzakBombs = PlayerPrefs.GetInt("freeRukzakBombs", freeRukzakBombs);
        currentRukzakBombs = freeRukzakBombs;
        // TODO: если будем за деньги
        /*
        if (currentRukzakBombs < freeRukzakBombs)
            currentRukzakBombs = freeRukzakBombs;
        */
        if (currentRukzakBombs > 0)
            cat.GetComponent<Cat>().RukzakToggle(true);

        Uiingame.inst.setRukzakUiCount(currentRukzakBombs);
        // ЗАГРУЖАЕМ ВЗРЫВЧАТКУ В РЮКЗАК

        STAT.Add("igli",0);
        STAT.Add("jump", 0);
        STAT.Add("tnt", 0);
        STAT.Add("water", 0);
        STAT.Add("birdObj", 0);
        STAT.Add("bonus", 0);
    }

    // Update is called once per frame
    void Update () {
        currentHeight = catTrns.position.y;
        currentDistance = catTrns.position.x;

        //считаем самую высокую высотоу
        if(maxHeight< currentHeight)
        maxHeight = currentHeight;
        /*
        if (Input.GetMouseButtonDown(0))
        {
            
             if (GAME_STATE == gameState.begin)
                 gameControl("fire",cannon);
             else 

            if (GAME_STATE == gameState.fly)
                gameControl("rukzak", cat); 
    }
    */
   if (Input.GetKeyDown(KeyCode.Escape)) 
    Application.Quit(); 
        //Genetate objects
        if (currentDistance > placeObjectInt)
            placeObject(currentDistance + placeObjectRast);

        //creat stolb
        if (currentDistance > placeStolbInt)
            placeStolb(currentDistance + placeStolbRast);
    }

    public void ButtonPress()
    {
        if (GAME_STATE == gameState.begin)
            gameControl("fire", cannon);
        else if (GAME_STATE == gameState.fly)
            gameControl("rukzak", cat);
    }
    public void placeStolb(float posX)
    {
        placeStolbInt += placeStolbRast;
        GameObject tmpStolb = Instantiate(stolbObj, new Vector3(posX, -0.22F, 0), Quaternion.identity);
        stolb tmpScrpt = tmpStolb.GetComponent<stolb>();
        tmpScrpt.Init((currentDistance + placeStolbRast )* 10);
    }
    public void placeObject(float posX)
    {

        // Debug.Log("NEW OBJECT");
        placeObjectInt += placeObjectRast;
        int tmpRand = Random.Range(1, 10);
        int tmpRand2 = Random.Range(1, 4);

        if (tmpRand== 1 || tmpRand == 2 || tmpRand == 3)
        {
            Instantiate(tnt, new Vector3(posX, -0.45F, 0), Quaternion.identity); STAT["tnt"] += 1;
        }
        else if(tmpRand == 7)
        {
            Instantiate(igli, new Vector3(posX, -0.2F, 0), Quaternion.identity); STAT["igli"] += 1;
        }
        else if (tmpRand == 4 || tmpRand == 5|| tmpRand == 6)
        {
            Instantiate(jump, new Vector3(posX, -0.55F, 0), Quaternion.identity); STAT["jump"] += 1;
        }
        else if (tmpRand == 8)
        {
            Instantiate(water, new Vector3(posX, -0.45F, 0), Quaternion.identity); STAT["water"] += 1;
        }
        else if (tmpRand == 9)
        {
            Instantiate(bonus, new Vector3(posX, -0.1F, 0), Quaternion.identity); STAT["bonus"] += 1;
        }

        if (tmpRand2 == 3)
        {
            Instantiate(birdObj, new Vector3(posX, 0.5F, 0), Quaternion.identity); STAT["birdObj"] += 1;
        }

        //Debug.Log("PLACE");
    }

    public void gameControl(string type, GameObject obj=null)
    {

        switch (type)
        {
            case "igli":
                GAME_STATE = gameState.stop;
                catRb.constraints = RigidbodyConstraints2D.FreezeAll;
                catTrns.position = obj.GetComponent<Transform>().position;
                fxController.inst.playFx("fxBlood");
                fxController.inst.PlaySingle(fxController.inst.igli,1,0.7F);
                StartCoroutine(ui.inst.setResults());
                break;
            case "water":
                GAME_STATE = gameState.stop;
                catRb.constraints = RigidbodyConstraints2D.FreezeAll;
                catTrns.position = obj.GetComponent<Transform>().position;
                fxController.inst.playFx("fxWater");
                fxController.inst.PlaySingle(fxController.inst.water);
                //catTrns.position = new Vector3(-1000F,-1000F,0F);
                cat.SetActive(false);
                StartCoroutine(ui.inst.setResults());
                break;
            case "speed":
                GAME_STATE = gameState.stop;
                catRb.constraints = RigidbodyConstraints2D.FreezeAll;
                StartCoroutine(ui.inst.setResults());
                break;
            case "rukzak":
                if (GAME_STATE == gameState.fly)
                {
                    if (currentRukzakBombs > 0)
                    {
                        fxController.inst.playFx("fxTntExplosive", obj);
                        fxController.inst.PlaySingle(fxController.inst.tnt);
                        catRb.AddForce(new Vector2(4F, 4F), ForceMode2D.Impulse);
                        currentRukzakBombs--;
                        PlayerPrefs.SetInt("freeRukzakBombs", currentRukzakBombs);
                        if (currentRukzakBombs <= 0)
                            cat.GetComponent<Cat>().RukzakToggle(false);

                        Uiingame.inst.setRukzakUiCount(currentRukzakBombs);
                    }
                    else
                    {
                        Uiingame.inst.setRukzakUiCount(currentRukzakBombs);
                    }
                }
                break;
            case "fire":
                if (GAME_STATE == gameState.begin)
                {
                    Uiingame.inst.setButtonType("rukzak");
                    catTrns.position = dulo.inst.getDuloTrigger();
                    fxController.inst.playFx("fxDuloSmoke");
                    fxController.inst.playFx("fxDuloFire");
                    fxController.inst.PlaySingle(fxController.inst.canon);
                    fxController.inst.PlaySingle(fxController.inst.cat,2);
                    catShadow.inst.ShowShadow();
                    cat.SetActive(true);
                    GAME_STATE = gameState.fly;
                    var tmpdir = (Vector2)(Quaternion.Euler(0, 0, dulo.inst.getDuloAngel()) * Vector2.up);
                    catRb.AddForce(tmpdir*5* body.inst.getCurPow(), ForceMode2D.Impulse);
                }
                break;
            case "tnt":
                Destroy(obj);
                fxController.inst.playFx("fxTntExplosive", obj);
                fxController.inst.PlaySingle(fxController.inst.tnt);
                catRb.AddForce(new Vector2(4F, 4F), ForceMode2D.Impulse);
                break;
            case "propan":
                Destroy(obj.transform.parent.gameObject);
                fxController.inst.PlaySingle(fxController.inst.gas,1,0.7F);
                fxController.inst.playFx("fxTntExplosive", obj);
                catRb.AddForce(new Vector2(6F, 5F), ForceMode2D.Impulse);
                break;
            case "jump":
                fxController.inst.PlaySingle(fxController.inst.jump);
                var animatorjump = obj.GetComponent<Animator>();

                if (animatorjump.gameObject.activeSelf) 
                    animatorjump.Play("jumpAnim"); // animatorjump.SetTrigger("jumpTrigger");

                catRb.AddForce(new Vector2(1.5F, 3F), ForceMode2D.Impulse);
                break;
            case "ground":
                int tmpRand = Random.Range(1, 5);
                if(tmpRand==3)
                fxController.inst.PlaySingle(fxController.inst.cat, 2);
                else
                fxController.inst.PlaySingle(fxController.inst.tap, 2);
                break;
            case "bonus":
                Destroy(obj);
                fxController.inst.PlaySingle(fxController.inst.bonus, 1);
                currentRukzakBombs+=2;
                PlayerPrefs.SetInt("freeRukzakBombs", currentRukzakBombs);
                if (currentRukzakBombs >= 0)
                    cat.GetComponent<Cat>().RukzakToggle(true);

                Uiingame.inst.setRukzakUiCount(currentRukzakBombs);
                break;
        }

       // Debug.Log(STAT);
       /*
        Debug.Log("igli:"       + STAT["igli"]);
        Debug.Log("jump:"       + STAT["jump"]);
        Debug.Log("tnt:"        + STAT["tnt"]);
        Debug.Log("water:"      + STAT["water"]);
        Debug.Log("birdObj:"    + STAT["birdObj"]);
        */
        Debug.Log("GAME CONTROL "+ type);
    }
}
