using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    //private GameObject player;
    //public bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
            Destroy(other.gameObject);
    }
}
