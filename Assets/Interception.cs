using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interception : MonoBehaviour
{
    public GameObject prey,redPoint;
    private Rigidbody2D rig;
    public float speed;
    Vector3 u;
    // Start is called before the first frame update
    void Start()
    {
        //开始先给个初速度，这个算法要先有个初速度才可以运行
        rig = this.GetComponent<Rigidbody2D>();
        transform.up = prey.GetComponent<PreyMovement>().orientation.normalized;
        rig.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void Intercept()
    {
        Vector2 Vr, Sr,S12;
        float Tc;
        Vector3 distance,St;


        //这一部分是像让飞机和书上给的实例demo那样，转一圈的，但没成功
        S12 =  prey.transform.position- this.transform.position ;
        u = transform.InverseTransformVector(S12);
        Debug.DrawRay(this.transform.position, u, Color.red);
        if (u.y<0)
        {
            transform.up = transform.right*5.0f;
            rig.velocity = transform.up * speed;
            return;
        }

      //主要内容
        Vr =  prey.GetComponent<Rigidbody2D>().velocity- rig.velocity ;
        Sr =   prey.transform.position- this.transform.position;
        Tc = Sr.magnitude /Vr.magnitude ;
        distance = prey.GetComponent<Rigidbody2D>().velocity * Tc;
        St = prey.transform.position+ distance;
        u = St- this.transform.position ;



        transform.up = u.normalized;
        rig.velocity = transform.up * speed;
       
        Debug.DrawRay(this.transform.position, St, Color.black);


        //拦截点
        redPoint.transform.position = St;
        
    }
}
