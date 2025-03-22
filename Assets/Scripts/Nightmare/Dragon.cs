using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    private int HP = 100;
    public Slider healthBar;

    public Animator animator;

    public GameObject fireBall;
    public Transform fireBallPoint;


    private void Update()
    {
        healthBar.value = HP;
    }
    /*
    public void Scream()
    {
        FindObjectOfType<AudioManager>().Play("DragonScream");
    }
    */

    /*
    public void Attack()
    {
        FindObjectOfType<AudioManager>().Play("DragonAttack");
    }
    */

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //AdudioManager.instance.Play("DragonDeath");
            // play death animation
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            //AudioManager.instance.Play("DragonDamage");
            // play get hit animation
            animator.SetTrigger("damage");
        }
    }

    public void Fire()
    {
        // FindObjectOfType<AudioManager>().Play("DragonFire");
        Rigidbody rb = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
    }

}
