using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEngine;
//using System.Collections;
public class Pic : MonoBehaviour {

	
    Vector3 v3 = new Vector3(2 , 2, 2);
    UnityEngine.Random rnd;
    bool checkFree, coll, coll2, count;
    //int counter;

    void start()
    {
        rnd = new UnityEngine.Random();
    }
    void Update()
    {
        transform.Rotate(v3);
        if (Snake.NewPic || coll)
        {
            //rnd.Next(1, 11);
            //gameObject.SetActive(true);
            // Debug.Log(transform.position+"    "+ rnd.Next(1, 40));
            //int x = rnd.
            gameObject.transform.position = new Vector3((UnityEngine.Random.value*38)+1, 0, (UnityEngine.Random.value * 38) + 1);
            //Debug.Log(transform.position);
            count = true;
            coll = false;
            Snake.NewPic = false;
        }
        
    }
    void OnCollisionEnter(Collision x)
    {
        Debug.Log("Here Man");
          coll = true;
    }
    void OnTriggerEnter(Collider x)
    {
        Debug.Log("Here Man22");
         coll = true;
    }


}
