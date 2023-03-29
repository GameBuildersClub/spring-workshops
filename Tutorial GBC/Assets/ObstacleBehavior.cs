using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    private Rigidbody2D rbody;
    public GameObject spwner;
    private SpawnerBehavior spwnerBhv;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spwner = GameObject.Find("Spawner");
        spwnerBhv = spwner.GetComponent<SpawnerBehavior>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbody.velocity = new Vector2(-5 - Mathf.Log10(spwnerBhv.timer) * 3f, 0);
        if(transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
