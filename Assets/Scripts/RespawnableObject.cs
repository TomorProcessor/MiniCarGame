using UnityEngine;
using System.Collections;

public class RespawnableObject : MonoBehaviour {

    public Transform respawnPoint;
    private UnityEngine.UI.Text livesText;
    private UnityEngine.UI.Text HpText;
    //private ParticleSystem.EmissionModule flames;

    void Start () {
        this.livesText = GameObject.FindGameObjectWithTag("Lives").GetComponent<UnityEngine.UI.Text>();
        this.HpText = GameObject.FindGameObjectWithTag("HP").GetComponent<UnityEngine.UI.Text>();
        /*this.flames = GameObject.FindGameObjectWithTag("Flames").GetComponent<ParticleSystem>().emission;
        flames.enabled = false; */
	}
    

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Building") CharacterMovemenetController.hp -= 25; else
        if (other.tag == "Tree") CharacterMovemenetController.hp -= 15; else
        if (other.tag == "Bush") CharacterMovemenetController.hp -= 10;
        if (CharacterMovemenetController.toggle.isOn) SoundManager.instance.PlaySound("hit");

        /*
        if (CharacterMovemenetController.hp < 45)
        {
            Debug.Log("FIRE");
            flames.enabled = true;
        }
        else
        {
            Debug.Log("DONT FIRE");
            flames.enabled = false;
        }
        */
        if (CharacterMovemenetController.hp <= 0)
        {
            CharacterMovemenetController.lives -= 1;
            CharacterMovemenetController.hp = 100;
            if (CharacterMovemenetController.lives == 0)
            {
                CharacterMovemenetController.hp = 0;
                Debug.Log("DEAD");
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                //Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
            else
            {
                this.respawn();
            }
        }
        Debug.Log("lives: " + CharacterMovemenetController.lives + ", hp: " + CharacterMovemenetController.hp);
        this.livesText.text = "Lives: " + CharacterMovemenetController.lives;
        this.HpText.text = "HP: " + CharacterMovemenetController.hp;
    }

	public void respawn()
    {
        gameObject.transform.position = respawnPoint.position;
    }
}
