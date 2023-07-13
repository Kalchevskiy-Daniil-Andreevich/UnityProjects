using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Moving : MonoBehaviour
{
    public Transform Tower;			        //объектная переменная для управления башней
    public Transform TankBarrel; 			//объектная переменная для управления стволом
    public float TankMoveSpeed = 0.2f;      //для регулирования скорости движения танка
    float TowerRotateSpeed = 1f; 	        //для регулирования скорости вращения башни
    float MinTowerRotation = -40f;	        //минимальный угол поворота ствола
    float MaxTowerRotation = 40f;           //максимальный угол поворота ствола
    public float TankRotateSpeed = 0.3f;    //Скорость поворота танка
    float MinBarrelRotation = -30f;         //Минимальный угол поворота дула
    float MaxBarrelRotation = 12f;          //Максимальный угол поворота дула
    bool isPlaying = false;                 //Проигрывается ли музыка движения танка
 
    void Update()
    {
        float TowerAngle = Tower.localEulerAngles.y;    //получение угла поворота башни.
        if (TowerAngle > 180)                           //проверка и корректировка угла поворота башни.
            TowerAngle = -(360 - TowerAngle);           
        float BarrelAngle = TankBarrel.eulerAngles.x;   //получение угла поворота дула.
        if (BarrelAngle > 180)
            BarrelAngle = -(360 - BarrelAngle);         //проверка и корректировка угла поворота дула.


        float x = Input.GetAxis("Horizontal") * TankRotateSpeed; //получение значения оси горизонтального движения танка.
        float z = Input.GetAxis("Vertical") * TankMoveSpeed;     //получение значения оси вертикального движения танка.
        if ((x > 0 || z > 0) && !isPlaying)//проверка проигрывается ли музыка движения танка.
         //{
        //    gameObject.GetComponent<AudioSource>().Play();
        //    isPlaying = true;
        //}
        //else if(x == 0 && z == 0)
        //{
        //    gameObject.GetComponent<AudioSource>().Stop();
        //    isPlaying = false;
        //}
        if (x != 0)                                              //поворот танка по оси Y.
            transform.Rotate(0f, x, 0f);
        if (z != 0)                                              //перемещение танка по оси Z.
            transform.Translate(0, 0, z);
        
        float h = Input.GetAxis("Mouse X");                      //получение значения оси X мыши.
        if (h != 0 && TowerAngle > MinTowerRotation && TowerAngle < MaxTowerRotation) //проверка возможности поворота башни.
        {
            Tower.Rotate(0f, h * TowerRotateSpeed, 0f); //поворот башни по оси Y.
            TowerAngle = Tower.localEulerAngles.y;
            if (TowerAngle > 180)
                TowerAngle = -(360 - TowerAngle);
            if (TowerAngle > MaxTowerRotation)         //проверка и корректировка угла поворота башни.
                Tower.localEulerAngles = new Vector3(.0f, MaxTowerRotation - 0.01f, .0f);
            else if(TowerAngle < MinTowerRotation)    //проверка и корректировка угла поворота башни.
                Tower.localEulerAngles = new Vector3(.0f, MinTowerRotation + 0.01f, .0f);
        }

        float v = Input.GetAxis("Mouse Y");            // получение значения оси Y мыши.
        if (v != 0 && BarrelAngle > MinBarrelRotation && BarrelAngle < MaxBarrelRotation) //- проверка возможности поворота дула.
        { 
            TankBarrel.Rotate(v * TowerRotateSpeed, 0f, 0f); //поворот дула по оси X.
            BarrelAngle = TankBarrel.localEulerAngles.x;
            if (BarrelAngle > 180)
                BarrelAngle = -(360 - BarrelAngle);
            if (BarrelAngle > MaxBarrelRotation)
                TankBarrel.localEulerAngles = new Vector3(MaxBarrelRotation - 0.01f, .0f, .0f);
            if (BarrelAngle < MinBarrelRotation)
                TankBarrel.localEulerAngles = new Vector3(MinBarrelRotation + 0.01f, .0f, .0f);
        }
    }
}