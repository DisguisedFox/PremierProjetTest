using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] private Transform[] gunsTransformList;
    [SerializeField] private float time2Fire = 2.0f;
    [SerializeField] private float bulletVelocity = 8.0f;
    [SerializeField] private GameObject bulletPrefab;

    private float life = 3;

    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {

    }

    private IEnumerator Fire()
    {
        while(true)
        {
            yield return new WaitForSeconds(time2Fire);
            foreach(Transform t in gunsTransformList)
            {
                GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
                Destroy(bullet, 5);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            life--;
            if (life == 0)
            {
                Destroy(this);
            }
        }
    }
}
