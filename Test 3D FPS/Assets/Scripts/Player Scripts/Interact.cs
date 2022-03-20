using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject interactObject;
    [SerializeField] private GameObject IntractableImage;
    private OpenUI openUI;

    private void Awake()
    {
        openUI = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenUI>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, LayerMask.GetMask("Interact")))
        {
            if (hit.collider.GetComponent<Door>())
            {
                if (hit.collider.GetComponent<Door>().CanInteract)
                {
                    interactObject = hit.collider.gameObject;
                }
                else
                {
                    interactObject = null;
                }
            }
            else if (hit.collider.GetComponent<Teleport>())
            {
                if (hit.collider.GetComponent<Teleport>().CanInteract)
                {
                    interactObject = hit.collider.gameObject;
                }
                else
                {
                    interactObject = null;
                }
            }
            else if (hit.collider.GetComponent<Quest>())
            {
                if (hit.collider.GetComponent<Quest>().CanInteract)
                {
                    interactObject = hit.collider.gameObject;
                }
                else
                {
                    interactObject = null;
                }
            }
            else if (hit.collider.GetComponent<Casino>())
            {
                if (hit.collider.GetComponent<Casino>().CanInteract)
                {
                    interactObject = hit.collider.gameObject;
                }
                else
                {
                    interactObject = null;
                }
            }
        }
        else
        {
            interactObject = null;
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
    }

    private void Update()
    {
        if (interactObject != null)
        {
            if(interactObject.GetComponent<Door>())
            {
                IntractableImage.SetActive(true);
            }
            else if (interactObject.GetComponent<Teleport>())
            {
                IntractableImage.SetActive(true);
            }
            else if (interactObject.GetComponent<Quest>())
            {
                IntractableImage.SetActive(true);
            }
            else if (interactObject.GetComponent<Casino>())
            {
                IntractableImage.SetActive(true);
            }
            //Press E
            if (Input.GetKeyDown(KeyCode.E) && !openUI.InventoryOpen())
            {
                if (interactObject.GetComponent<Teleport>())
                {
                    interactObject.GetComponent<Teleport>().TeleportOn();
                }
                else if (interactObject.GetComponent<Door>())
                {
                    interactObject.GetComponent<Door>().OpenDoor(interactObject);
                }
                else if (interactObject.GetComponent<Quest>())
                {
                    interactObject.GetComponent<Quest>().TakeBook();
                }
                else if (interactObject.GetComponent<Casino>())
                {
                    interactObject.GetComponent<Casino>().Roll();
                }
            }
        }
        else
        {
            IntractableImage.SetActive(false);
        }
    }
}
