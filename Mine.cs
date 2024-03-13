using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mine : MonoBehaviour
{
    public GameObject Arm1;
    public GameObject Arm2;
    public GameObject Arm3;

    public GameObject mine;

    public GameObject explosionPrefab;

    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, Random.Range(45, 180) * Time.deltaTime);

        Arm1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.black * 10, Color.yellow * 10, Time.deltaTime));
        Arm2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.black * 10, Color.yellow * 10, Time.deltaTime));
        Arm3.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.black * 10, Color.yellow * 10, Time.deltaTime));
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship")
        {
            Destroy(this.gameObject, .1f);
            Destroy(Arm1, .1f);
            Destroy(Arm2, .1f);
            Destroy(Arm3, .1f);

        }

        GameObject boom = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(boom, 2);

        if (other.tag == "Ship")
        {
            other.gameObject.GetComponent<Movement>().mined();
        }
    }
}
