using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casino : MonoBehaviour
{
    [SerializeField] private Door door;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioSource audioRoll;
    [SerializeField] private AudioClip[] clips;
    public GameObject enterObject;
    private bool roll;
    [SerializeField] private bool canInteract;
    private bool _canInteract;
    private Inventory inventory;

    public bool CanInteract
    {
        get
        {
            return _canInteract;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (canInteract)
        {
            if (enterObject != null && roll == false)
            {
                _canInteract = true;
            }
            else
            {
                _canInteract = false;
            }
        }
    }

    public void Roll()
    {
        inventory.TakeEweyLoot(10, ref roll);
        if(roll == true)
        {
            audioSource.clip = clips[0];
            audioSource.Play();

            animator.SetBool("Roll", true);

            int number;
            number = Random.Range(0, 100);
            print(number);

            if (number <= 25)
            {
                print("25");
                animator.SetTrigger("25");
            }
            else if (number <= 50)
            {
                print("50");
                animator.SetTrigger("50");
            }
            else if (number <= 90)
            {
                print("90");
                animator.SetTrigger("90");
            }
            else
            {
                print("100");
                animator.SetTrigger("100");
            }
        }
    }

    void Stop_Roll()
    {
        roll = false;
    }
    void Roll_False()
    {
        animator.SetBool("Roll", false);
    }

    void Roll_Audio()
    {
        audioRoll.Play();
    }

    void Win()
    {
        inventory.AddLoot(GetComponent<Loot>().Item);
        audioSource.clip = clips[1];
        audioSource.Play();
        canInteract = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enterObject == null)
        {
            if (other.tag == "Player")
            {
                enterObject = other.gameObject;
                door.OpenDoor(door.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (enterObject != null)
        {
            if (other.tag == "Player")
            {
                enterObject = null;
                door.OpenDoor(door.gameObject);
            }
        }
    }
}
