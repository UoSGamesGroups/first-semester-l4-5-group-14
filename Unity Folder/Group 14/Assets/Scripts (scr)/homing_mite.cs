using UnityEngine;
using System.Collections;

public class homing_mite : MonoBehaviour
{

    public Transform Books;
    public float speed = 12;
    public float moveSpeed = 2;

    public float maxDistance = 2;


    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Books = GameObject.FindWithTag("book").transform;

    }
    void Update()
    {
        if (Vector3.Distance(transform.position, Books.position) > maxDistance)
        {
            transform.position += (Books.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }

        {
            //Destroy(gameObject, 3.0f);
        }
    }

    void OnTriggerEnter(Collider others)
    {
        Destroy(others.gameObject);
        Destroy(gameObject);
    }
}


