using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody bulletRigidbody;
    public int damageAmount = 20;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.linearVelocity = transform.forward * speed;
        //Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(transform.GetComponent<Rigidbody>());
        Destroy(gameObject);

        /* if(other.tag == "Dragon")
        {
            other.GetComponent<Dragon>().TakeDamage(damageAmount);
        }
        */
        
        if (other.GetComponent<BulletTarget>() != null || other.tag == "Dragon") {
            // Hit target
            transform.parent = other.transform;
            other.GetComponent<Dragon>().TakeDamage(damageAmount);
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        } else {
            // Hit something else
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        
    }

}