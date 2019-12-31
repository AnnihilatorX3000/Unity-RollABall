using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherRevController : MonoBehaviour
{
    //Boundaries of movement
    public float max, min;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = min - 4;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position =new Vector3(-Mathf.PingPong(Time.time*2 , min-max) + min, transform.position.y, transform.position.z);
    }
}
