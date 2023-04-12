using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerBehavior : MonoBehaviour
{
    Coroutine spawning;
    public GameObject[] Obstacles;
    public GameObject scoreBoard;
    private TextMeshProUGUI textBox;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawning = StartCoroutine(Spawn());
        textBox = scoreBoard.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textBox.text = timer.ToString("F2");
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(3 - 1.75f * Mathf.Atan(timer*.02f), 5 - 3f * Mathf.Atan(timer * .02f)));
            Instantiate(Obstacles[Random.Range(0,Obstacles.Length)], transform.position, transform.rotation);
        }
    }
}
