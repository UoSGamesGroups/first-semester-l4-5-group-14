using UnityEngine;
using System.Collections;

public class homing_mite : MonoBehaviour
{

    public Transform Books;
    public float speed = 12;
    public float moveSpeed = 2;

    public float maxDistance = 2;


    void Start() {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    void Update(){
        //if (scr_gameManager.GameManager.isDragging)
        //    Books = GetComponent<mouseClick>().raycastHit;
        //else
            Books = GameObject.FindWithTag("book").transform;

      //  if (Vector3.Distance(transform.position, Books.position) > maxDistance)
        //    transform.position += (Books.position - transform.position).normalized * moveSpeed * Time.deltaTime;
       // else if (Books == null)
            transform.position += new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime;
       // else
            return;
    }

    void OnTriggerEnter(Collider others)
    {
       if (others.gameObject.layer != 8)
        {
            Destroy(others.gameObject);
            Destroy(gameObject);
        }
    }
}


