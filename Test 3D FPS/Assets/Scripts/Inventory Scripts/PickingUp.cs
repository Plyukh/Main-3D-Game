using UnityEngine;

public class PickingUp : MonoBehaviour
{
    private Inventory inventory;

    private GameObject objectItem;
    [SerializeField] private GameObject PickUpImage;

    private void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2, LayerMask.GetMask("Items")))
        {
            objectItem = hit.collider.gameObject;
        }
        else
        {
            objectItem = null;
        }
    }

    private void Update()
    {
        if (objectItem != null)
        {
            PickUpImage.SetActive(true);
        }
        else
        {
            PickUpImage.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && objectItem != null)
        {
            inventory.AddLoot(objectItem.GetComponent<Loot>().Item);
            if (!inventory.inventory_is_Full)
            {
                GetComponent<AudioSource>().Play();
                Destroy(objectItem);
            }
            else
            {
                print("Full");
            }
        }
    }
}
