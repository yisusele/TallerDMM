using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class nivel2 : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision){

   if(collision.gameObject.tag == "Player"){
SceneManager.LoadScene(1);

   }
   }
}
