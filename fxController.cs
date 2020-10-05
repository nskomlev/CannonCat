using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxController : MonoBehaviour {
    public static fxController inst;

    public GameObject fxBlood;
    public GameObject fxWater;
    public GameObject fxDuloSmoke;
    public GameObject fxDuloFire;
    public GameObject fxTntExplosive;
     
    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;
    public AudioSource efxSourceSecond; 

    public AudioClip canon;
    public AudioClip gas;
    public AudioClip igli;
    public AudioClip jump;
    public AudioClip tnt;
    public AudioClip water;
    public AudioClip record;
    public AudioClip cat;
    public AudioClip tap;
    public AudioClip bonus;

    // об землю
    // мяуканье
    // аплодисменты
    // кнока/конец

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

       //DontDestroyOnLoad(gameObject);
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip,int audioCH=1, float volume=1.0F)
    {
        AudioSource tmpCH= efxSource;

        switch (audioCH)
        {
            case 1: tmpCH = efxSource; break;
            case 2: tmpCH = efxSourceSecond; break;
        }
        
        tmpCH.clip = clip;
        tmpCH.volume = volume;
        tmpCH.Play();
    }

    public void playFx(string type, GameObject obj = null)
    {
        switch (type)
        {
            case "fxWater":
                fxWater.transform.position = Cat.inst.transform.position;
                fxWater.GetComponent<ParticleSystem>().Play();
                break;
            case "fxBlood":
                fxBlood.transform.position = Cat.inst.transform.position;
                fxBlood.GetComponent<ParticleSystem>().Play();
                break;
            case "fxDuloSmoke":
                fxDuloSmoke.GetComponent<ParticleSystem>().Play();
                break;
            case "fxDuloFire":
                fxDuloFire.GetComponent<ParticleSystem>().Play();
                break;
            case "fxTntExplosive":
                GameObject tmpObj = Instantiate(fxTntExplosive, obj.GetComponent<Transform>().position, Quaternion.identity);
                tmpObj.GetComponent<ParticleSystem>().Play();
                break;
        }
    }
}
