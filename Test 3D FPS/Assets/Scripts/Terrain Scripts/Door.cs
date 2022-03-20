using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] private bool invert;
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private bool x, y, z;
    private float openTime = 0;
    private bool open;
    [SerializeField] private bool canInteract;
    private bool _canInteract;

    public bool CanInteract
    {
        get
        {
            return _canInteract;
        }
    }

    private void Update()
    {
        if (canInteract)
        {
            if (openTime == 0)
            {
                _canInteract = true;
            }
            else
            {
                _canInteract = false;
            }
        }
    }

    public void OpenDoor(GameObject Door)
    {
        if (GetComponent<AudioSource>())
        {
            Door.GetComponent<AudioSource>().clip = Door.GetComponent<Door>().clips[0];
            Door.GetComponent<AudioSource>().Play();
        }
        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(0);
        openTime += 0.03f;
        if (open == false)
        {
            if (openTime >= 1)
            {
                openTime = 0;
                open = true;
                StopCoroutine(Open());
            }
            else if (invert)
            {
                if (x)
                {
                    transform.Rotate(-3, 0, 0, Space.World);
                }
                else if (y)
                {
                    transform.Rotate(0, -3, 0, Space.World);
                }
                else if (z)
                {
                    transform.Rotate(0, 0, -3, Space.World);
                }
                StartCoroutine(Open());
            }
            else
            {
                if (x)
                {
                    transform.Rotate(3, 0, 0, Space.World);
                }
                else if (y)
                {
                    transform.Rotate(0, 3, 0, Space.World);
                }
                else if (z)
                {
                    transform.Rotate(0, 0, 3, Space.World);
                }
                StartCoroutine(Open());
            }
        }
        else
        {
            if (openTime >= 1)
            {
                open = false;
                if (GetComponent<AudioSource>())
                {
                    GetComponent<AudioSource>().clip = clips[1];
                    GetComponent<AudioSource>().Play();
                }
                openTime = 0;
                StopCoroutine(Open());
            }
            else if (invert)
            {
                if (x)
                {
                    transform.Rotate(3, 0, 0, Space.World);
                }
                else if (y)
                {
                    transform.Rotate(0, 3, 0, Space.World);
                }
                else if (z)
                {
                    transform.Rotate(0, 0, 3, Space.World);
                }
                StartCoroutine(Open());
            }
            else
            {
                if (x)
                {
                    transform.Rotate(-3, 0, 0, Space.World);
                }
                else if (y)
                {
                    transform.Rotate(0, -3, 0, Space.World);
                }
                else if (z)
                {
                    transform.Rotate(0, 0, -3, Space.World);
                }
                StartCoroutine(Open());
            }
        }
    }
}