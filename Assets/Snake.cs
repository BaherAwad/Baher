//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;


public class Snake : MonoBehaviour {

    public GameObject body , GameOver;
    public float speed = 5;
    public UnityEngine.UI.Text score;
    int Direction ,Timer ,count = 0;
    List<GameObject> Linked;
    List<Vector3> pos;
    public static bool NewPic;
    Vector3 curpos, oldpos;

    // Use this for initialization

    void Start () {
        //Instantiate(body, new Vector3(1 * 1.0f, 0, 0), Quaternion.identity);
        Linked = new List<GameObject>();
        pos = new List<Vector3>();
        //body2 = Instantiate(body, new Vector3(1 * 1.0f, 0, 0), Quaternion.identity);
        Linked.Add(this.gameObject);
        pos.Add(this.transform.position);
        //pos.Add(body.transform.position);
        AddingParts();
        AddingParts();
        Direction = (int) (UnityEngine.Random.value * 3) ;
    }
    

    void OnTriggerEnter(Collider x)
    {
        if (x.gameObject.tag.Contains("PIC"))
        {
            //x.gameObject.SetActive(false);
            score.text = "Score = " + ++count;
            AddingParts();
            NewPic = true;
        }

        if (x.gameObject.tag.Equals("wall"))
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }

        if (x.gameObject.tag.Equals("B"))
        {
            if (Linked.Count > 3)
            {
                Time.timeScale = 0;
                GameOver.SetActive(true);
            }
           // Debug.Log(x.gameObject.name);
        }

    }
    void OnCollisionEnter(Collision x)
    {
        
    }
    
    // Update is called once per frame
    void Update() {
        float step = speed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.UpArrow) && Direction!=1 ) Direction = 0;
        else if (Input.GetKey(KeyCode.DownArrow) && Direction != 0) Direction = 1;
        else if (Input.GetKey(KeyCode.RightArrow) && Direction != 3) Direction = 2;
        else if (Input.GetKey(KeyCode.LeftArrow) && Direction != 2) Direction = 3;
        
        if (Direction == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, step);
        }
        else if (Direction == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.forward, step);
        }
        else if (Direction == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, step);
        }
        else if (Direction == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.right, step);
        }
        curpos = transform.position;
        if(Vector3.Distance(curpos, oldpos) > 1)
        {
            oldpos = curpos;
            pos.Insert(0,curpos);
            pos.RemoveAt(pos.Count - 1);
            
        }
        MovingParts();

        // body2.transform.position = Vector3.MoveTowards(body2.transform.position, this.transform.position, step );
        if (Input.GetKeyUp(KeyCode.Escape)) Application.Quit();
    }

    private void AddingParts()
    {
        Linked.Add(Instantiate(body, Linked[Linked.Count-1].transform.position, body.transform.rotation));
        pos.Add(Linked[Linked.Count - 1].transform.position);
    }

    void MovingParts()
    {

        for( int i = 1;i < Linked.Count ;i++)
        {
            float distance;
            distance = Vector3.Distance(Linked[i].transform.position, Linked[i-1].transform.position);
            //Linked[i].transform.position
            //if(distance > 1)
            //{
                //Linked[i].transform.position = Vector3.MoveTowards(Linked[i].transform.position, Linked[i - 1].transform.position, speed * Time.deltaTime);
                Linked[i].transform.position = Vector3.MoveTowards(Linked[i].transform.position, pos[i-1], speed * Time.deltaTime);
           // }
        }
        
    }

    
}
