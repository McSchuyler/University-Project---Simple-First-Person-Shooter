using UnityEngine;
using System.Collections;

public class EnemyRotater : MonoBehaviour {

    private GameObject player;

    void Start()
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

	void Update()
    {
        transform.LookAt(player.transform.position);
	}
}
