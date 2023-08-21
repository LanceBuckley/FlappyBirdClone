using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Uses the Rigidbody2D class to give BirdScript a rigidbody field called myRigidbody. Because it is public it can be accessed outside the script
    public Rigidbody2D myRigidbody;
    public Animator wingFlap;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Searches all game objects for the first one with a matching tag then assigns that object to the LogicScript class
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wingFlap = GameObject.FindGameObjectWithTag("Wing").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // This if statement checks if an input has been made to Unity, in particular a key on the keyboard, represented by the following keycode and that birdIsAlive is true
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            // Targets the velocity property of the myRigidbody field and sets it equal to up[short hand for (0, 1)] * x
            myRigidbody.velocity = Vector2.up * flapStrength;
            // Accesses the wingFlap animator and sets the boolean value of its IsFlapping property to true
            wingFlap.SetTrigger("IsFlapping");
        }

        if (myRigidbody.transform.position.y < new Vector2(0, -16).y || myRigidbody.transform.position.y > new Vector2(0, 17).y)
        {
            logic.gameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
