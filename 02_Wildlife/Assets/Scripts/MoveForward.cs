using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10f;
    
    /*  private void OnTriggerEnter(Collider other){
                Debug.Log("GAME OVER!!!!");
          
                if(other.gameObject.CompareTag("Atack")){
                Debug.Log("GAME OVER2!!!!");
                  Destroy(this.gameObject);
                }
     }*/
    
    void Update()
    {
      if(this.gameObject.CompareTag("Enemy")){
          transform.Translate(Vector3.forward*speed*Time.deltaTime);
      }else{
          transform.Translate(Vector3.backward*speed*Time.deltaTime);
      }      
    }
    
   /*   private void OnTriggerEnter(Collider other)
              {
                 Debug.Log(other.name + " entered the trigger " + name);
                     if(other.gameObject.CompareTag("Enemy")){
                            Destroy(other.gameObject);
                     }
              }
      */
  
                      
    
}
