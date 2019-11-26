using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        // Setting up the references.
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {

            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {

        if (other.gameObject == player)
        {

            playerInRange = false;
        }
    }


    void Update()
    {

        timer += Time.deltaTime;


        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }


        if (playerHealth.currentHealth <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


    void Attack()
    {

        timer = 0f;


        if (playerHealth.currentHealth > 0)
        {

            playerHealth.TakeDamage(attackDamage);
        }
    }
}