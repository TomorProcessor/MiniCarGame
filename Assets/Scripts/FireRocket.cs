using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireRocket : MonoBehaviour {

	public GameObject rocket; //reference to rocket, set it from editor
	public float speed = 10f; //we're making it public, so we can test other values from the editor
	public Transform firePoint;

    private List<GameObject> rocketPool = new List<GameObject>();
    public int rocketPoolSize;

    private bool canFire = true;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < rocketPoolSize; i++)
        {
            
            GameObject newRocket = Instantiate(rocket, firePoint.position, rocket.transform.rotation) as GameObject;
            newRocket.transform.localScale = new Vector3((float)-0.1,(float)0.1,(float)0.1);

            newRocket.SetActive(false);
            rocketPool.Add(newRocket);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (CharacterMovemenetController.launcherVisible)
            {
                if (canFire)
                {
                    canFire = false;
                    fireRocket();
                    if (CharacterMovemenetController.toggle.isOn) SoundManager.instance.PlaySound("shoot");
                }
            }
		}
        if (Input.GetKeyUp(KeyCode.Space)) canFire = true;
	}
	
	private void fireRocket() {
		//float newRotationAngle = CharacterMovemenetController.facingRight ? 90 : 270;
		//Rigidbody2D rocketClone = (Rigidbody2D) Instantiate(rocket, firePoint.position, Quaternion.Euler(0, 0, newRotationAngle));
        
        foreach (GameObject rocketClone in rocketPool)
        {
            if (!rocketClone.activeSelf)
            {
                rocketClone.SetActive(true);
                rocketClone.GetComponent<Rigidbody2D>().rotation = gameObject.GetComponent<Rigidbody2D>().rotation;
                //Vector3 force = CharacterMovemenetController.facingRight ? transform.right : transform.right * -1;
                rocketClone.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, gameObject.GetComponent<Rigidbody2D>().rotation - 45) * new Vector2(speed, speed);
                break;
            }
        }
	}
}
