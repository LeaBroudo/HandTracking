using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMouseFollow : MonoBehaviour
{

    public ConfigurableJoint myJoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        myJoint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit1;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit1, 1000f))
        {
            print(hit1.collider.gameObject.name);
        }
        /*   if (Input.GetMouseButtonUp(0))
       {
           RaycastHit hit;
           if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f))
           {
               print(hit.collider.gameObject.name);
               ConfigurableJoint bodyJoint = hit.collider.GetComponent<ConfigurableJoint>();
               if (bodyJoint != null)
               {
                   myJoint.connectedBody = null;
                   this.transform.position = bodyJoint.transform.position;
                   myJoint.connectedBody = bodyJoint.GetComponent<Rigidbody>();
               }
           }
       }*/
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            Debug.Log("mouse clicked");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Player clicked " + hit.transform.name);
     
            }
        }

    }
}
