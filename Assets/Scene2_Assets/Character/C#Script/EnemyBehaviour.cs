using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public enum State { Alive, Death};
    public State currentState;

    public float speed = 5.0f;
    public float reactRange = 5.0f;
    public float detectionRange = 10.0f;

    private GameObject spawner;

    [SerializeField]
    private GameObject bulletPrefab;
    private GameObject bullet;

    private GameObject player;
    private bool findingPlayer = false;


    void Start()
    {
        currentState = State.Alive;

        if (!spawner)
        {
            spawner = GameObject.FindWithTag("Spawner");
        }

        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    void Update()
    {
        if(currentState == State.Alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray collisionRay = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(collisionRay, 0.75f, out hit))
            {
                if(hit.distance <= reactRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
            if (player != null && findingPlayer == false)
            {
                StartCoroutine(ShootPlayer());
                findingPlayer = true;
            }
        }  
        if(currentState == State.Death)
        {
            Spawner access;
            access = spawner.GetComponent<Spawner>();
            access.EnemyKilled();
            Destroy(gameObject);
        }
    }

    IEnumerator ShootPlayer()
    {
        float refreshRate = 1.0f;
        Vector3 direction;

        while (player != null)
        {
            if(currentState == State.Alive)
            {
                direction = (player.transform.position - transform.position).normalized;
                Ray detectionRay = new Ray(transform.position, direction);
                RaycastHit playerHit;
                if (Physics.Raycast(detectionRay, out playerHit,detectionRange))
                {
                    if (playerHit.distance < detectionRange && playerHit.transform.tag == "Player")
                    {
                        bullet = Instantiate(bulletPrefab) as GameObject;
                        bullet.transform.position = transform.position + direction*2;
                        bullet.transform.LookAt(player.transform.position);
                    }
                }
            }
            yield return new WaitForSeconds(refreshRate);
        }      
    }
}
