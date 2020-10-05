using UnityEngine;
using UnityEngine.UI; // обязательно добавляем библиотеку пользовательского интерфейса, без нее кино не будет
using System.Collections;

public class bgParalax : MonoBehaviour
{

    public float speed = 0; //эта публичная переменная отобразится в инспекторе, там же мы ее можем и менять. Это очень удобно, чтобы настроить скорость разным слоям картинки
    public float autospeed = 0;

    float pos = 0; //переменная для позиции картинки
    private RawImage image; //создаем объект нашей картинки
    private Rigidbody2D rbCat;
    private Vector3 v3Velocity;


    void Start()
    {
        rbCat = main.inst.catRb;
        v3Velocity = rbCat.velocity;
        image = GetComponent<RawImage>();//в старте получаем ссылку на картинку
        speed = speed / 20000F;
        autospeed = autospeed / 20000F;
    }

    void Update()
    {
        v3Velocity = rbCat.velocity;
        //в апдейте прописываем как, с какой скоростью и куда мы будем двигать нашу картинку
        pos += speed*(v3Velocity.x)+ autospeed;

       // Debug.Log();

        if (pos > 1.0F)
            pos -= 1.0F;

        image.uvRect = new Rect(pos, 0, 1, 1);

    }
}