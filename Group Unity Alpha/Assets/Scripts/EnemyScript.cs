using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

private Rigidbody enemyRb;
private GameObject player;
//public Transform targetObj;
public int health;
public int attack; 
public float speed = 3.0f;

void Start() {

  enemyRb = GetComponent<Rigidbody>();

  player = GameObject.Find("Player"); 

 }

void Update() {
  Vector3 lookDirection = (player.transform.position -
  transform.position).normalized;

  enemyRb.AddForce(lookDirection * speed); 

    //Vector3 lookDirection = (player.transform.position - transform.position).normalized;

    //enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
    //(lookDirection * speed); 


  //transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speed * Time.deltaTime);


	}



}
