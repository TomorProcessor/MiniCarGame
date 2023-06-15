using UnityEngine;
using System.Collections;

public class CharacterMovemenetController : MonoBehaviour {

	private Rigidbody2D rigidboy;
	public float maxSpeed = 10f;
    public static bool launcherVisible = false;
    private bool launcherCanMove = true;
    public Transform fallDeathCheck;
    public static int lives = 3;
    public static int hp = 100;
    private Animator animationController;
    private ParticleSystem.EmissionModule flames;
    private bool speedChanged1 = true;
    private bool speedChanged2 = false;
    private bool isPlayingEngine = false;
    private bool isPlayingEngine_idle = false;
    public static UnityEngine.UI.Toggle toggle;

	// Use this for initialization
	void Start () {
		this.rigidboy = gameObject.GetComponent<Rigidbody2D>();
        animationController = gameObject.GetComponent<Animator>();
        this.flames = GameObject.FindGameObjectWithTag("Flames").GetComponent<ParticleSystem>().emission;
        flames.enabled = false;
        toggle = GameObject.FindGameObjectWithTag("Toggle").GetComponent<UnityEngine.UI.Toggle>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {



        float move = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            this.rigidboy.rotation += 5;
            if (this.rigidboy.rotation > 360) this.rigidboy.rotation = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            this.rigidboy.rotation -= 5;
            if (this.rigidboy.rotation < -360) this.rigidboy.rotation = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            this.rigidboy.rotation -= 5;
            if (this.rigidboy.rotation < -360) this.rigidboy.rotation = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            this.rigidboy.rotation += 5;
            if (this.rigidboy.rotation > 360) this.rigidboy.rotation = 0;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (this.launcherCanMove)
            {
                this.launcherCanMove = false;
                if (!launcherVisible)
                {
                    Debug.Log("launcherShow");
                    animationController.SetTrigger("launcherShow");
                    animationController.ResetTrigger("launcherHide");
                    launcherVisible = true;
                }
                else
                {
                    Debug.Log("launcherHide");
                    animationController.SetTrigger("launcherHide");
                    animationController.ResetTrigger("launcherShow");
                    launcherVisible = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl)) this.launcherCanMove = true;

        float carAngle = this.rigidboy.rotation / 360;

        this.rigidboy.velocity = Quaternion.Euler(0, 0, this.rigidboy.rotation - 45) * new Vector2(move * maxSpeed, move * maxSpeed);
        /*
        if (gameObject.transform.position.y <= fallDeathCheck.position.y)
        {
            respawnController.resetGame();
        }*/

        if (hp < 45)
        {
            //Debug.Log("FIRE");
            flames.enabled = true;
        }
        else
        {
            //Debug.Log("DONT FIRE");
            flames.enabled = false;
        }
        if (toggle.isOn)
        {
            if (move * maxSpeed == 0)
            {
                speedChanged1 = true;
                speedChanged2 = false;
                Debug.Log("KEYUP");
            }
            if (move * maxSpeed != 0)
            {
                speedChanged2 = true;
                speedChanged1 = false;
                Debug.Log("KEYDOWN");
            }
            if (speedChanged1)
            {
                SoundManager.instance.StopSound("engine");
                isPlayingEngine = false;
                if (!isPlayingEngine_idle)
                {
                    SoundManager.instance.PlaySound("engine_idle");
                    isPlayingEngine_idle = true;
                }
                speedChanged1 = false;

            }
            if (speedChanged2)
            {
                SoundManager.instance.StopSound("engine_idle");
                isPlayingEngine_idle = false;
                if (!isPlayingEngine)
                {
                    SoundManager.instance.PlaySound("engine");
                    isPlayingEngine = true;
                }
                speedChanged2 = false;

            }
        }
        else
        {
            SoundManager.instance.StopSound("engine_idle");
            isPlayingEngine_idle = false;
            SoundManager.instance.StopSound("engine");
            isPlayingEngine = false;
        }
	}

    
}


