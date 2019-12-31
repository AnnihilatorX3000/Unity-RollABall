using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherController : MonoBehaviour
{   
    //Boundaries of movement
    public float max, min;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = min + 4;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position =new Vector3(Mathf.PingPong(Time.time*2 , max-min) + min, transform.position.y, transform.position.z);
    }
}
