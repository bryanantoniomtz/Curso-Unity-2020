using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
     public GameObject player;        
     private Vector3 offset;           
  
      void Start () 
      {
          offset = transform.position - player.transform.position;
      }
  
      // LateUpdate is called after Update each frame
      void LateUpdate () 
      {
          // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
          transform.position = player.transform.position + offset;
      }
}
