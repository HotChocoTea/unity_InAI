using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public Vector2 orientation;
    public int index;
    public float rotSpeed = 1.0f;
   
    // Start is called before the first frame update
    void Awake()
    {
        rig = this.GetComponent<Rigidbody2D>();
       orientation= new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void Run()
    {
        //transform.up是物体的局部坐标，不用下面哪些方法是因为，在2d上移动的上下左右对应的是xy但换位旋转的话还是xyz，所以不行
        transform.up = Vector3.Slerp(transform.up, orientation.normalized, Mathf.Clamp01(rotSpeed * Time.deltaTime));
        rig.velocity = orientation.normalized * speed;

        Debug.DrawRay(this.transform.position, this.transform.up, Color.black);
        //transform.up = orientation.normalized;

        //float angle = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(rotSpeed * Time.deltaTime));

        //this.transform.LookAt(orientation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name== "Predator")
        {
            collision.GetComponent<LineOfSightChase>().speed = 5;
            Debug.Log("5");
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Predator")
            collision.GetComponent<LineOfSightChase>().speed = 10;
        Debug.Log("10");
    }

}
