using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 55.0f;

    private float lowerBound = -10.0f;
    
    // Update is called once per frame
    void Update()
    {
        //AND x && y => se debe cumplir x e y a la vez
        //OR  x || y => se debe cumplir x o y, uno u otro (o los dos)
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }
        
        if (this.transform.position.z < lowerBound)
        {
           // Debug.Log("GAME OVER!!!!");
            Destroy(this.gameObject);

           // Time.timeScale = 0;
        }
    }
}
