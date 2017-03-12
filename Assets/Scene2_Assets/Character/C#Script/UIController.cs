using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Text enemyNum;
    [SerializeField]
    private Text playerHealth;

    private GameObject spawner;
    private GameObject player;
    Spawner access;
    Damageable playerAccess;

    void Start()
    {
        if (!spawner)
        {
            spawner = GameObject.FindWithTag("Spawner");
            access = spawner.GetComponent<Spawner>();
        }

        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            playerAccess = player.GetComponent<Damageable>();
        }
    }

    void Update()
    {
        enemyNum.text = access.currentAlive.ToString();
        playerHealth.text = playerAccess.health.ToString();
    }
}
