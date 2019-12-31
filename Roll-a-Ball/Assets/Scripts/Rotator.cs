using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rotator : MonoBehaviour
{ 
    private Vector3 rotAxis; 
    
    void Start()
    {
        rotAxis = GetRandomDir();
    }
 
    void Update()
    {
        //Random rotation
        transform.Rotate(rotAxis , 50 * Time.deltaTime);
    }

    //Get vector pointing to random point on sphere (Source: https://answers.unity.com/questions/36506/random-direction.html)
     public static Vector3 GetRandomDir()
     {
         double x0 = -1.0 + Random.value*2.0;
         double x1 = -1.0 + Random.value*2.0; 
         double x2 = -1.0 + Random.value*2.0;
         double x3 = -1.0 + Random.value*2.0; 

         while(x0*x0 + x1*x1 + x2*x2 + x3*x3 >= 1)
         {
             x0 = -1.0 + Random.value*2.0;
             x1 = -1.0 + Random.value*2.0; 
             x2 = -1.0 + Random.value*2.0;
             x3 = -1.0 + Random.value*2.0;
         } 

         double a = x0*x0 + x1*x1 + x2*x2 + x3*x3;
         double x = 2*(x1*x3 + x0*x2)/a;    
         double y = 2*(x2*x3-x0*x1)/a;    
         double z = (x0*x0 + x3*x3 - x1*x1 - x2*x2)/a;

         return new Vector3((float)x, (float)y, (float)z);
     }
}