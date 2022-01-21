using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof((Rigidbody)))]
public class PlayerControler : MonoBehaviour {
    
    
    [Range(0,10)]
public float speed;
private Rigidbody _rigidbody;
private float verticalInput, horizontalInput;
public bool usePhysicsEngine;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
  
        horizontalInput=Input.GetAxis("Horizontal");
        verticalInput=Input.GetAxis("Vertical");
        MovePlayer();
        KeepPlayerInBounds();
    }

    void MovePlayer()
    {
      _rigidbody.AddForce(Vector3.forward*Time.deltaTime*speed*verticalInput,ForceMode.Force); 
      _rigidbody.AddTorque(Vector3.up*horizontalInput*Time.deltaTime*speed,ForceMode.Force);
        
    }

    void KeepPlayerInBounds() {
        //TODO: Refactorizar todo el metodo 
        if (Mathf.Abs(transform.position.x )>= 24||Mathf.Abs(transform.position.z )>= 24) {
        _rigidbody.velocity = Vector3.zero;
        //*
        if (transform.position.x > 24)
        {
            transform.position = new Vector3(24,transform.position.y,transform.position.z);
        }
        if (transform.position.x < -24)
        {
            transform.position = new Vector3(-24,transform.position.y,transform.position.z);
        }
        //*
        if (transform.position.z > 24)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,24);
        }
        if (transform.position.z < -24)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,-24);
        }
    }  
    }
}
