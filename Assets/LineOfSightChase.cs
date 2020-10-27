using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightChase : MonoBehaviour
{
    public GameObject  pray;
    private Rigidbody2D rig;
    public float speed;
    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //StartRun();
    }

  private void DoLineOfSightChase()
    {
       
        distance =  pray.transform.position-transform.position  ;
        
    }

    private void Run()
    {
        transform.up = distance.normalized;
        rig.velocity = transform.up * speed;
        //this.transform.localPosition = u * speed;
        // transform.Translate(Vector3.up * speed );
        Debug.DrawRay(this.transform.position, distance, Color.black);
    }
    public void StartRun()
    {
        DoLineOfSightChase();
        Run();
    }
}
