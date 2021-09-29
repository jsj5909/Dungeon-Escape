using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    public int value { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //check for player
        //add value of diamond to player
        if(other.tag == "Player")
        {
            Debug.Log("Player picking up " + value + " diamonds!");
            
            other.GetComponent<Player>().diamonds += value;
            Destroy(this.gameObject);
            Debug.Log("Player has " + other.GetComponent<Player>().diamonds + " diamonds");
            
        }


    }

}
