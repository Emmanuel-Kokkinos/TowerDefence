using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;

    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRound = 1;

    int currentHealth = 0;

    Enemy enemy;

    // OnEnable is what is called when a gameobject is enabled in the inspector
    // In this case: When an enemy is 'spawned'
    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            enemy.RewardGold();
            maxHealth += difficultyRound;
            gameObject.SetActive(false);
        }
    }
}
