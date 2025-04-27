using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    private int HP = 100;

    public int ID {  get; set; }
    public Slider healthBar;

    public Animator animator;

    public GameObject fireBall;
    public Transform fireBallPoint;

    private void Start()
    {
        ID = 0;
    }
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
            EnemyKillTracker.AddKill();

            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            Invoke("DestroyObject", 10f);
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

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
