using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float lifeTime = 3.0f;
    public float speed = 10.0f;
    public int damage = 1;

    private float moveDistance;

	void Start ()
    {
        Destroy(gameObject, lifeTime);
        moveDistance = speed * Time.deltaTime;
	}

	void Update ()
    {
        transform.Translate(Vector3.forward * moveDistance);
	}

    void OnTriggerEnter(Collider other)
    {
        Damageable unit = other.GetComponent<Damageable>();
        if(unit != null)
        {
            unit.Hurt(damage);
        }
        Destroy(gameObject);
    }
}
