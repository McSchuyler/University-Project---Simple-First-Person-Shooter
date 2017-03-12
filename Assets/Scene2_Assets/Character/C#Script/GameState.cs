using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

    public GameObject background;
    public GameObject winText;
    public GameObject loseText;

    private GameObject spawner;
    Spawner access;

    private GameObject player;
    PlayerStatus accessHealth;

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
            accessHealth = player.GetComponent<PlayerStatus>();
        }
    }

    void Update()
    {
        if(access.allDead == true)
        {
            background.SetActive(true);
            winText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(accessHealth.currentState == PlayerStatus.State.Death)
        {
            background.SetActive(true);
            loseText.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
