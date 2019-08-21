using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juego : MonoBehaviour
{

    void Start()
    {
        int h = Random.Range(10, 21);
        for (int i = 0; i < h; i++)
        {
            int n = Random.Range(1, 3);
            GameObject objec = GameObject.CreatePrimitive(PrimitiveType.Cube);
            objec.AddComponent<Rigidbody>();
            Vector3 v = new Vector3();
            v.x = Random.Range(5, 50);
            v.z = Random.Range(5, 50);
            objec.transform.position = v;
            if (i == 0)
            {
                objec.AddComponent(typeof(Hero));
            }
            else
            {
                switch (n)
                {
                    case 1:
                        objec.AddComponent(typeof(Enemigo));
                        break;
                    case 2:
                        objec.AddComponent(typeof(Npc));
                        break;
                }
            }
        }

    }

}
