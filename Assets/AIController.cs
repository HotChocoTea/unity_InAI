using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    /// <summary>
    /// 管理器，管理两个飞机的
    /// </summary>
    public GameObject prey, predator;
    public GameObject[] points;
    private int index = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (index==1)
        {
            predator.GetComponent<LineOfSightChase>().StartRun();
        }
        else if (index==2)
        {
            predator.GetComponent<Interception>().Intercept();
        }
    }

    private void FixedUpdate()
    {
        prey.GetComponent<PreyMovement>().Run();
     
       
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Prey")
        {
            int temp = Random.Range(0, points.Length);
            while (temp == collision.gameObject.GetComponent<PreyMovement>().index)//这个随机点和前一个随机点不能相同，如果相同的话，就会直接出边界了。
            {
                temp = Random.Range(0, points.Length);
            }
            collision.gameObject.GetComponent<PreyMovement>().orientation = points[temp].transform.position - collision.transform.position;
            collision.gameObject.GetComponent<PreyMovement>().index = temp;

        }
            
    }


    public void DoBasicChase()
    {
        index = 1;
    }
    public void DoInterception()
    {
        index = 2;
    }

}
