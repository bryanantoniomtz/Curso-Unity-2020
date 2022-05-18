
#if UNITY_IOS || UNITY_ANDROID
    #define USING_MOBILE

#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

public float speed=7;
private Rigidbody _rigidbody;

/// para el salto

public float thrust=1;
bool m_isGrounded=true;
///

// para el ataque

 public GameObject[] atacks;
   
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)){
        Invoke ("SpawnAtack", 0);
      }
    }
    
    public void SpawnAtack(){
          Vector3 spawnPos = new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z+3);
          Instantiate(atacks[0],
          spawnPos,
          atacks[0].transform.rotation);
            
     }
          
          
    public void Jump(){
      m_isGrounded=false;
      _rigidbody.AddForce(0,thrust,0,ForceMode.Impulse);
    }
    
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Ground")){
           m_isGrounded=true;
            Debug.Log("m_isGrounded=true");
        }
    }
    
    
         
    void FixedUpdate()
    {
    
    ///  MOVERSE
#if USING_MOBILE
              float horizontal=Input.GetAxis("Mouse X");
              float vertical=Input.GetAxis("Mouse Y");
              if(Input.touchCount>0){
                 horizontal=Input.touches[0].deltaPosition.x;
                 vertical=Input.touches[0].deltaPosition.y;
              }
              
#else
       
#endif
        Transform camTransform = Camera.main.transform;
        Vector3 camPosition = new Vector3(camTransform.position.x, transform.position.y, camTransform.position.z);
        Vector3 direction = (transform.position - camPosition).normalized;
        //Vector3 forwardMovement = direction * Input.GetAxis("Vertical");
        Vector3 forwardMovement = new Vector3(0,0,0);
        Vector3 horizontalMovement = camTransform.right * Input.GetAxis("Horizontal");
        Vector3 movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    ///  SALTAR
        if((Input.GetAxis("Vertical")>0)&&m_isGrounded==true){
              Jump();
        }
    }
}  
