using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private ScoreManager theScore;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("IsOpen", true);
        }
        if (GameManager.isNight)
        {
            if (ScoreManager.score < 70)
            {
                animator.SetBool("IsOpen", false);
            }
            else if (ScoreManager.score > 70)
            {
                animator.SetBool("IsOpen", true);
            }
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("IsOpen",false);
        }

    }
}
