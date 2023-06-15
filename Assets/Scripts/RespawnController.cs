using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnController : MonoBehaviour {

    public RespawnableObject[] respawnableObjects;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   


    public void resetGame()
    {
        foreach (RespawnableObject respawnableObject in respawnableObjects)
        {
            respawnableObject.respawn();
        }
    }
}
