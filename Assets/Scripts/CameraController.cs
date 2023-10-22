using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontalValue;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * speed * Time.deltaTime * horizontalValue);
    }
}
