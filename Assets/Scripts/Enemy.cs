using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody playerRb;
    private GameObject player;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddForce((player.transform.position - transform.position).normalized * speed);
        
        if (transform.position.y < -17.0f)
        {
            Destroy(gameObject);
        }

    }
}
