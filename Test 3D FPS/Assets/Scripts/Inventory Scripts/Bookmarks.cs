using UnityEngine;
using UnityEngine.UI;

public class Bookmarks : MonoBehaviour
{
    [SerializeField] private Button[] bookmarks;
    [SerializeField] private GameObject[] chapters;
    [SerializeField] private GameObject inventory;
    [SerializeField] private ScrollManager scrollManager;
    private Vector2 selectPosition = new Vector2(15, 0);

    public void SelectChapter(Button bookmark)
    {
        for (int i = 0; i < bookmarks.Length; i++)
        {
            if (bookmarks[i].interactable == false)
            {
                bookmarks[i].GetComponent<RectTransform>().anchoredPosition += selectPosition;
            }

            if (bookmarks[i].name == bookmark.name)
            {
                if(i == 0 || i == 2)
                {
                    inventory.SetActive(true);
                    scrollManager.ReleaseSlots();
                }
                else
                {
                    inventory.SetActive(false);
                }

                chapters[i].SetActive(true);
                bookmarks[i].GetComponent<RectTransform>().anchoredPosition -= selectPosition;
                bookmarks[i].interactable = false;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                chapters[i].SetActive(false);
                bookmarks[i].interactable = true;
            }
        }
    }

    public void SelectChapter(int bookmarkIndex)
    {
        for (int i = 0; i < bookmarks.Length; i++)
        {
            if (bookmarks[i].interactable == false)
            {
                bookmarks[i].GetComponent<RectTransform>().anchoredPosition += selectPosition;
            }

            if (i == bookmarkIndex)
            {
                if (i == 0 || i == 2)
                {
                    inventory.SetActive(true);
                    scrollManager.ReleaseSlots();
                }
                else
                {
                    inventory.SetActive(false);
                }

                chapters[i].SetActive(true);
                bookmarks[i].GetComponent<RectTransform>().anchoredPosition -= selectPosition;
                bookmarks[i].interactable = false;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                chapters[i].SetActive(false);
                bookmarks[i].interactable = true;
            }
        }
    }
}
