using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footallScript : MonoBehaviour
{
    Rigidbody body;
    internal void Kick()
    {
        print("I've have been kicked");
        body.AddExplosionForce(200, transform.position + new Vector3(0, -1, -1), 2);
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
