using UnityEngine;
using System.Collections;

public class RocketController2 : MonoBehaviour {

    private Transform firePoint;

    public bool hasMaxDistance;
    public float maxDistance;

    
    private float distanceTraveled = 0f;


    void Awake()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint2").transform;
    }

	void OnEnable()
    {
        distanceTraveled = 0;
        transform.position = firePoint.position;
    }

   void Update()
    {
        if (hasMaxDistance)
        {
            distanceTraveled += 1;

            if (Mathf.Abs(distanceTraveled) >= maxDistance)
            {
                gameObject.SetActive(false);
            }
        }
    }

   void OnTriggerEnter2D(Collider2D other)
   {
       if (CharacterMovemenetController.toggle.isOn) SoundManager.instance.PlaySound("bang");
       gameObject.SetActive(false);
   }
}
