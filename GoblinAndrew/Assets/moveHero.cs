using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHero : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            print("Couldnt find the animator");
        else
            print("Component found");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime;

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }

       


    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        footallScript myFootball = collision.gameObject.GetComponent<footallScript>();
        if (myFootball != null)
        {
            myFootball.Kick();
        }
    }
}
