using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mine;
    private int counter = 0;
    float N = 0;
    public Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter % 800 == 0 && Movement.isDead == false)
        {
            StartCoroutine(SpawnMine());
        }
        if(Movement.isDead == true)
        {
            cam.enabled = true;
        }
        counter++;
    }

    IEnumerator SpawnMine()
    {
            SpawnEnemy(mine);
            yield return new WaitForSeconds(1f);

    }
    void SpawnEnemy(GameObject mine)
    {
        Instantiate(mine, new Vector3(Random.Range(Movement.target.transform.position.x - 30f, Movement.target.transform.position.x + 30f), 0, Random.Range(Movement.target.transform.position.z - 30f, Movement.target.transform.position.z + 30f)), Quaternion.identity);
    }
}
