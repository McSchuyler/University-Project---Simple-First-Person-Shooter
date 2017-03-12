using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {
    public enum Type { playerType, enemyType};
    public Type type;

    public float health;

	void Start()
    {
        if(transform.tag == "Player")
        {
            type = Type.playerType;
            health = 10.0f;
        }

        if(transform.tag == "Enemy")
        {
            type = Type.enemyType;
            health = 2.0f;
        }
    }

    void Update()
    {
        CheckHealth();
    }

    public void Hurt(int damage)
    {
        health -= damage;
    }

    void CheckHealth()
    {
        if(health <= 0)
        {
            if(type == Type.enemyType)
            {
                EnemyBehaviour enemy = GetComponent<EnemyBehaviour>();
                enemy.currentState = EnemyBehaviour.State.Death;
            }
           if(type == Type.playerType)
            {
                PlayerStatus player = GetComponent<PlayerStatus>();
                player.currentState = PlayerStatus.State.Death;
            }
        }
    }
}
