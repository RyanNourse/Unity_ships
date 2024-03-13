using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0;
    public GameObject cap;
    public List<GameObject> shipParts;
    private float HP = 100;
    public GameObject explosionPrefab;
    public static bool isDead = false;
    public static Transform target;

    public Camera shipCam;
    // Start is called before the first frame update
    void Start()
    {
        target = cap.transform;
    }

    // Update is called once per frame
    void Update()
    {

        
        //rotate
        if (Input.GetKey(KeyCode.A))
        {
            cap.transform.localRotation = cap.transform.localRotation * Quaternion.Euler(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cap.transform.localRotation = cap.transform.localRotation * Quaternion.Euler(0, 0, -1);
        }

        //move forward based on speed.
        if (Input.GetKey(KeyCode.W))
        {
            speed++;
            if(speed > 10)
            {
                speed = 10;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            speed--;
            if(speed <0)
            {
                speed = 0;
            }
        }

        if(isDead == true)
        {
            shipCam.enabled = false;
        }
        transform.position += cap.transform.up * speed * Time.deltaTime;
    }

    public void mined()
    {
        HP -= 10;
        int index;
        if (shipParts.Count > 0)
        {
            if (shipParts.Count > 1)
            {
                index = Random.Range(0, shipParts.Count - 1);
            }
            else
            {
                index = 0;
            }
            GameObject go = shipParts[index];
            shipParts.Remove(go);
            go.transform.parent = null;
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().AddForce(Random.Range(-1000, 1000), Random.Range(0, 1000), Random.Range(-1000, 1000));
        }
        cap.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.green * 10, Color.red * 10, 1 - HP / 100));
        if (HP == 0)
        {
            Destroy(gameObject);
            GameObject boom = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(boom, 2);
            isDead = true;
        }

    }
}
