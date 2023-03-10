using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Determines where player moves where the camera rotates

    //Rigidbody = player moving
    private Rigidbody playerRb;
    //player moves wit the camera
    private GameObject focalPoint;
    //power up activate
    private float powerupStrength = 15.0f;
    public float speed = 5.0f;
    //see if have powerup or not
    public bool hasPowerup;
    // for power pyshical power up indicator
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //player moves with the camera
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //getting the player to move vertically (up and down)
        float forwardInput = Input.GetAxis("Vertical");
        //player moves with the camera
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    //indicates when powerup is picked up
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup= true;
            Destroy(other.gameObject);
            //makes potion timer limited
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    //limited time for potion power up

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //more power activation stuff, makes enemy push far away
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
