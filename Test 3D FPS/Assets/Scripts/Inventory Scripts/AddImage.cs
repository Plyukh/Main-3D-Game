using UnityEngine;
using UnityEngine.UI;

public class AddImage : MonoBehaviour
{
    private GameObject itemImagePrefab;
    private GameObject takeEweyItemImagePrefab;
    private GameObject xpImagePrefab;
    [SerializeField] private GameObject[] images;
    [SerializeField] private float y;

    private void Awake()
    {
        itemImagePrefab = Resources.Load<GameObject>("Image Prefabs/AddItem Image");
        takeEweyItemImagePrefab = Resources.Load<GameObject>("Image Prefabs/TakeEweyItem Image");
        xpImagePrefab = Resources.Load<GameObject>("Image Prefabs/AddXP Image");
    }

    void Update()
    {
        ClearImages();
    }

    void ClearImages()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i] != null)
            {
                images[i].GetComponent<CanvasGroup>().alpha -= 0.005f;
                if (images[i].GetComponent<CanvasGroup>().alpha <= 0)
                {
                    Destroy(images[i]);
                    images[i] = null;

                    for (int j = 0; j < images.Length; j++)
                    {
                        if (j + 1 < images.Length)
                        {
                            if (images[j + 1] != null)
                            {
                                images[j] = images[j + 1];
                                images[j].transform.position = new Vector2(images[j].transform.position.x, images[j + 1].transform.position.y - y);
                                images[j + 1] = null;
                            }
                        }
                    }
                }
            }
        }
    }

    void Overflow(Item loot)
    {
        Destroy(images[0]);
        images[0] = null;

        for (int j = 0; j < images.Length; j++)
        {
            if (j + 1 < images.Length)
            {
                if (images[j + 1] != null)
                {
                    images[j] = images[j + 1];
                    images[j].transform.position = new Vector2(images[j].transform.position.x, images[j + 1].transform.position.y - y);
                    images[j + 1] = null;
                }
            }
        }
        AddLootImage(loot);
    }
    void Overflow(Image skillImage, float xp)
    {
        Destroy(images[0]);
        images[0] = null;

        for (int j = 0; j < images.Length; j++)
        {
            if (j + 1 < images.Length)
            {
                if (images[j + 1] != null)
                {
                    images[j] = images[j + 1];
                    images[j].transform.position = new Vector2(images[j].transform.position.x, images[j + 1].transform.position.y - y);
                    images[j + 1] = null;
                }
            }
        }
        AddXPImage(skillImage, xp);
    }

    public void AddLootImage(Item loot)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if(images[i] == null)
            {
                Instantiate(itemImagePrefab, gameObject.transform);
                images[i] = GameObject.FindGameObjectWithTag("AddImage").gameObject;
                images[i].gameObject.tag = "Untagged";

                images[i].transform.GetChild(0).GetComponent<Image>().sprite = loot.itemSprite;
                images[i].transform.GetChild(0).GetComponentInChildren<Text>().text = loot.name;

                if (i > 0)
                {
                    if (images[i - 1] != null)
                    {
                        images[i].transform.position = new Vector2(images[i].transform.position.x, images[i - 1].transform.position.y + y);
                    }
                }
                break;
            }
            else if (images[images.Length - 1] != null)
            {
                print("!");
                Overflow(loot);
                break;
            }
        }
    }

    public void TakeEweyLootImage(int id)
    {
        Instantiate(takeEweyItemImagePrefab, gameObject.transform);
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i] == null)
            {
                images[i] = GameObject.FindGameObjectWithTag("AddImage").gameObject;
                images[i].gameObject.tag = "Untagged";

                images[i].transform.GetChild(0).GetComponent<Image>().sprite = Database.itemList[id].itemSprite;
                images[i].transform.GetChild(0).GetComponentInChildren<Text>().text = Database.itemList[id].name;

                if (i > 0)
                {
                    if (images[i - 1] != null)
                    {
                        images[i].transform.position = new Vector2(images[i].transform.position.x, images[i - 1].transform.position.y + y);
                    }
                }
                break;
            }
            else if (images[images.Length - 1] != null)
            {
                print("!");
                Overflow(Database.itemList[id]);
                break;
            }
        }
    }

    public void AddXPImage(Image skillImage, float xp)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (images[i] == null)
            {
                Instantiate(xpImagePrefab, gameObject.transform);
                images[i] = GameObject.FindGameObjectWithTag("AddImage").gameObject;
                images[i].gameObject.tag = "Untagged";

                images[i].transform.GetChild(0).GetComponent<Image>().sprite = skillImage.transform.GetChild(0).GetComponent<Image>().sprite;
                images[i].transform.GetChild(0).GetComponent<Image>().color = skillImage.transform.GetChild(0).GetComponent<Image>().color;
                images[i].transform.GetChild(0).GetComponentInChildren<Text>().text += xp.ToString();

                if (i > 0)
                {
                    if (images[i - 1] != null)
                    {
                        images[i].transform.position = new Vector2(images[i].transform.position.x, images[i - 1].transform.position.y + y);
                    }
                }
                break;
            }
            else if (images[images.Length - 1] != null)
            {
                print("!");
                Overflow(skillImage, xp);
                break;
            }
        }
    }
}
