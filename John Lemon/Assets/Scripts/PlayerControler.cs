#if UNITY_IOS || UNITY_ANDROID
    #define USING_MOBILE

#endif


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Vector3 movement;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    
    private Quaternion rotation=Quaternion.identity;
    [SerializeField]
    private float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _animator=GetComponent<Animator>();
        _rigidbody=GetComponent<Rigidbody>();
        _audioSource=GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
    
    #if USING_MOBILE
      float horizontal=Input.GetAxis("Mouse X");
      float vertical=Input.GetAxis("Mouse Y");
      if(Input.touchCount>0){
         horizontal=Input.touches[0].deltaPosition.x;
         vertical=Input.touches[0].deltaPosition.y;
      }
      
    #else
       float horizontal=Input.GetAxis("Horizontal");
       float vertical=Input.GetAxis("Vertical");
    #endif
    
       
        movement.Set(horizontal,0,vertical);
        movement.Normalize();
        
        bool hasHorizontalInput= !Mathf.Approximately(horizontal,0);
        bool hasVerticalInput= !Mathf.Approximately(vertical,0);
        bool isWalking=hasHorizontalInput||hasVerticalInput;
        
        _animator.SetBool("isWalking",isWalking);
        if(isWalking)
        {
           if(!_audioSource.isPlaying)
           {
             _audioSource.Play();
           }
           }
           else
           {
            _audioSource.Stop();
           }
        
                
        Vector3 desiredForward= Vector3.RotateTowards(transform.forward,movement,turnSpeed*Time.fixedDeltaTime,0f);
        
        rotation=Quaternion.LookRotation(desiredForward);
    }
    
    private void OnAnimatorMove(){
       _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
       _rigidbody.MoveRotation(rotation);
    
    }    
}
