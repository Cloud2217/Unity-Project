using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

private Rigidbody enemyRb;
private GameObject player;
public int health;
public int attack; 
public float speed;

void Start() {

 enemyRb = GetComponent<Rigidbody>();

 player = GameObject.Find("Player"); }

void Update() {


  Vector3 lookDirection = (player.transform.position -
transform.position).normalized;

 enemyRb.AddForce(lookDirection * speed); 



	}



}
