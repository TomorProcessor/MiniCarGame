using UnityEngine;
using System.Collections;

public class InstantDeath : MonoBehaviour {

    public Collider2D coll;
    private GameObject gameManager;
    private RespawnController respawnController;
    

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        respawnController = gameManager.GetComponent<RespawnController>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        CharacterMovemenetController.lives -= 1;
        CharacterMovemenetController.hp = 100;
        if (CharacterMovemenetController.lives == 0)
        {
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
            Debug.Log("DEAD");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            respawnController.resetGame();
        }
    }

    
}
