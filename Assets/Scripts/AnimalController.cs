using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

   public GameObject player;
 
     // Direction of movement
     Vector3 speedUp;
     Vector3 speedDown;
     Vector3 speedLeft;
     Vector3 speedRight;
 
     // For making code easier to read
     Rigidbody playerGetRigidbody;
 
     float playerSpeed = 3.0f;
     
     void Start () {
         playerGetRigidbody = player.GetComponent<Rigidbody>();
         
         speedUp    = new Vector3( 0, 0, 3);
         speedDown  = new Vector3( 0, 0,-3);
         speedLeft  = new Vector3(-3, 0, 0);
         speedRight = new Vector3( 3, 0, 0);
     }
     
     void Update () {
	 }
}