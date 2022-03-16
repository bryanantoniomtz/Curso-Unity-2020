using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

public float fadeDuration=1f;
public float displayImageDuration=1f;
public GameObject player;
private bool isPlayerAtExit;
private bool isPlayerCaught;
public CanvasGroup exitBackgroundImageCanvasGroup;
public CanvasGroup caughtBackgroundImageCanvasGroup;
private float timer;

  private void OnTriggerEnter(Collider other){
      if(other.gameObject==player){
         isPlayerAtExit=true;
      }
  }
  
  private void Update(){
    if(isPlayerAtExit){
       EndLevel(exitBackgroundImageCanvasGroup,false);
    }else if(isPlayerCaught)
    {
       EndLevel(caughtBackgroundImageCanvasGroup,true); 
    }
  }
  ///<sumary>
  ///Lanza la imagen de fin de la partida 
 ///</sumary>
 ///<param name="imageCanvasGroup">Imagen de fin de partida correspondiente</param>

  void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart){

      timer+= Time.deltaTime; 
      imageCanvasGroup.alpha=timer/fadeDuration;
      
       if(timer>fadeDuration+displayImageDuration){
          
           if(doRestart)
           {
              SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           }
           else
           {
             Application.Quit();
           }
 
       }
   
  }
  public void CatchPlayer()
  {
    isPlayerCaught=true;
  } 
}
