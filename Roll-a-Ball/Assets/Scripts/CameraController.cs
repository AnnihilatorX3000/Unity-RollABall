using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    //For follow cameras, procedural animation, and gathering last-known states, it's best to use this insead of every frame.
    //Guaranteed to run after all items have been processed in update
    // (so when we update the camera, we know absolutely that player has moved for that frame)
    void LateUpdate()
    {
        //Update camera position based on player position
        transform.position = player.transform.position + offset;
    }
}
