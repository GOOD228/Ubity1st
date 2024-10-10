using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHero : MonoBehaviour
{
    public GameObject snowBallCloneTemplate;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            print("Could not find Animator Component");
        else
            print("Animator Component found");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", false);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newSnowballGO = Instantiate(snowBallCloneTemplate , transform.position + transform.forward + Vector3.up, Quaternion.identity);
            SnowballScript myNewSnowball = newSnowballGO.GetComponent<SnowballScript>();
            myNewSnowball.throwSnowball(transform);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 6 * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += transform.up * 10 * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(Vector3.up, -50*Time.deltaTime);
       
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }



    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);


      
        footballScript myFootball = collision.gameObject.GetComponent<footballScript>();
        if (myFootball != null)
        {
            myFootball.Kick();
        }

    }
}
