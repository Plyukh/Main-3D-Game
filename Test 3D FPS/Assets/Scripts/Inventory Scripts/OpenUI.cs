using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private bool inventoryOpen;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool InventoryOpen()
    {
        return inventoryOpen;
    }

    private void Start()
    {
        inventoryOpen = false;
        inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryOpen)
            {
                audioSource.clip = clips[0];
                audioSource.Play();

                inventoryOpen = true;
                inventory.SetActive(true);

                inventory.GetComponentInChildren<Bookmarks>().SelectChapter(0);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                audioSource.clip = clips[1];
                audioSource.Play();

                inventoryOpen = false;
                inventory.GetComponent<DragAndDrop>().EndDrag();
                inventory.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
