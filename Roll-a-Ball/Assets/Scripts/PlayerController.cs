using System.Collections;
using UnityEngine;

//Required to use UI toolset
using UnityEngine.UI;
using UnityEngine.Video;

//Check every frame for player input and apply input to obj as movement
public class PlayerController : MonoBehaviour
{
    //Just sort of copying code from the documentation
    public float speed;      //Note: Public variables will show up in the inspector in Unity as an editable property
                                   //      So, we can edit this value within Unity!
    private Rigidbody rb;          //      Private variables will not show up in inspector. They may only be used in code here.
    private int count;
    public Text countText;     //Holds reference to UI text component on UI text game obj
    public Text winText;
    public Image winImg;
    public AudioSource winSound;
    public AudioSource sanicSound;
    public AudioSource michaelSound;
    public AudioSource coinSound;
    public VideoPlayer video;
    public AudioSource strikeSound;

    //This function is often the very first frame of the game
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = GameObject.FindGameObjectsWithTag("Pickup").Length;
        SetCountText();
        winText.text = "";
        winImg.enabled = false;
    }

    //void Update() { ... } called before rendering a frame. Not included in this case

    //Called just before performing any physics calculations
    void FixedUpdate()
    {
        //Move ball by applying forces to rigid body
        /*  To find out more on what input we need, look at scripting reference documentation page for "input"
            (https://docs.unity3d.com/ScriptReference/index.html)
            Look at description to learn how to use the class. 
            We also have a list of class variables ("Static Variables") and class functions ("Static Functions")
            In this case, we'll be using the GetAxis (or "Input.GetAxis") function and Rigidbody.AddForce
            Click on its link to see the function signature, description and example code in Javascript and C#, respectively.
        */

        //Holds input from player keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");        //Note "vertical" here refers to the z-dir

        //Note that in documentation, we have two signatures for Rigidbody.AddForce (scroll down in doc to see second one)
        //See on top of code to see rb definition, added based on the code provided in the docs
        //We keep y = 0 in the Vector3 since we don't want to move in the y-dir
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);      //Multiplying by some speed just to increase force on ball, hence make it move faster

        //NOTE: AFTER CREATING YOUR SCRIPT, CHECK THE FOOTER-REGION FOR CONSOLE ERRORS. IF THERE ARE NONE, YOU'RE GOOD TO GO
    }

    //Entry Triggers
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Pickup"))
        {
            col.gameObject.SetActive(false);
            coinSound.Play();
            count--;
            SetCountText();
        }
        else if(col.gameObject.CompareTag("SpeedBoost"))
        {
            sanicSound.Play();
        }
        else if(col.gameObject.CompareTag("TV"))
        {
            video.Play();
        }
        else if(col.gameObject.CompareTag("Wall") && rb.velocity.z > 0.2)
        {
            strikeSound.Play();
        }
    }

    //Stay Triggers
      void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("SpeedBoost"))
        {
            rb.AddForce(rb.velocity * 5);
        }
    }

    void SetCountText()
    {
        countText.text = "Pickups left: " + count.ToString();
        if (count == 0)
        {
            winText.text = "You're Winner!";
            winImg.enabled = true;
            winSound.Play();
        }
    }

    void LateUpdate()
    {
        //Respawn + Reset Momentum
        if (transform.position.y < -15)
        {
            rb.velocity = Vector3.zero;
            transform.position = new Vector3 (0, 1, 0);
            
            //Random Michael - 10%
            if (Random.value < 0.1)
            {
                michaelSound.Play();
            }
        }
    }
}
