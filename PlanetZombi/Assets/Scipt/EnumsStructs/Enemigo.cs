using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{//declaracion de variables
    public DatoZombis datos; //Variable estruc para guardar los datos
    public int rotarcion;
    public float veloci = 2f;
    public string gusto;
    void Start()
    {
        gusto = ZombiHable();
        gameObject.transform.tag = "Zombi";

        int color = Random.Range(1, 4);
        switch (color)
        {
            case 1:
                this.GetComponent<Renderer>().material.color = Color.cyan;
                break;
            case 2:
                this.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                this.GetComponent<Renderer>().material.color = Color.magenta;
                break;
        }
        StartCoroutine(rutina());
    }
    // Corutina para indicar el mobimiento del Zombi que es estar quieto o caminar
    IEnumerator rutina()
    {
        while (true)
        {
            int accion = Random.Range(0, 2);
            switch (accion)
            {
                case 0:
                    datos.mover = Accion.Idle;
                    break;
                case 1:
                    datos.mover = Accion.Moving;
                    break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
    // Mensaje que retornara a la clase Hero para ser impreso con el gusto del Zombi
    public string ZombiHable ()
    {
        datos.gustos = Random.Range(0, 5);
        datos.gusto = (Gustos)datos.gustos;
        return "Waaaarrrr quieroooo comeeer " + datos.gusto;
    }
    public void Update()
    {
        if (datos.mover == Accion.Moving)
            transform.position += transform.forward * veloci * Time.deltaTime;
    }
}
//Estrus que almacena los datos del Zombi
public struct DatoZombis
{
    public Gustos gusto;
    public Accion mover;
    public int gustos;
}
// Gusto que pueden tener los Zombis
public enum Gustos
{
    Pierna,
    Cesos,
    Corazon,
    Braso,
    Manos,
    Last
}
//Indicadior que ace mover al Zombi los cuales son: Idle => Quieto y Moving => Mover
public enum Accion {Idle, Moving}