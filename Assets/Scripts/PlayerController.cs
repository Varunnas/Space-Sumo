using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 5.0f;
    private Rigidbody playerRB;
    private float verticalValue;
    private GameObject focalpoint;
    public bool hasPower = false;
       public GameObject powerIndicator;
    
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        verticalValue = Input.GetAxis("Vertical");
        playerRB.AddForce(focalpoint.transform.forward * speed * verticalValue);
        powerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
         
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerIndicator.SetActive(true);
            hasPower = true;
        }

        

    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPower = false;
        powerIndicator.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPower) 
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemypos = collision.gameObject.transform.position - transform.position;
            rb.AddForce(enemypos * 15, ForceMode.Impulse);
            Debug.Log("The playe has collided with " + collision.gameObject.name + "and has power is set to : " + hasPower);
        }
    }




}




