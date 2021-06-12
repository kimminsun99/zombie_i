using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{

    
    public Transform target;
    public bool isChase;

    public int maxHelath;
    public int curHealth;

    public AudioSource audioSource;

    public int scoreValue = 1;



    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator anim;
    
    private  void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Invoke("ChaseStart", 2);


    }

    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }

    void Update()
    {
        if (isChase)
            nav.SetDestination(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            CloseWeapon isAxe = other.GetComponent<CloseWeapon>();
            curHealth -= isAxe.damage;
           

            StartCoroutine(OnDamage());
            
        }
    }

    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            
            isChase = false;
            nav.enabled = false;


            anim.SetTrigger("doDie");
            audioSource.Play();
            ScoreManager.score += scoreValue;
            Destroy(gameObject, 2f);
           


        }
    }
}
