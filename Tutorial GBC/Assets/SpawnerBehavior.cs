using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    Coroutine spawning;
    public GameObject[] Obstacles;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawning = StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3 - 1.75f * Mathf.Atan(timer*.02f), 5 - 2f * Mathf.Atan(timer * .02f)));
            Instantiate(Obstacles[Random.Range(0,Obstacles.Length)], transform.position, transform.rotation);
        }
    }
}
