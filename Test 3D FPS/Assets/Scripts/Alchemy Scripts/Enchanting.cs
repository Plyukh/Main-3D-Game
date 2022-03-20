using UnityEngine;
using UnityEngine.UI;
using GestureRecognizer;
using System;

public class Enchanting : MonoBehaviour 
{
	[SerializeField] private ScrollManager scrollManager;

    private void Update()
    {
		if(scrollManager.ScrollSlot.Item.id != 0)
        {
			if (!scrollManager.ScrollSlot.Item.scroll.scrollDone)
			{
				GetComponent<Image>().raycastTarget = true;
			}
			else
			{
				GetComponent<Image>().raycastTarget = false;
			}
		}
        else
        {
			GetComponent<Image>().raycastTarget = false;
		}
    }
	private bool Alpha1(GameObject gameObject)
    {
		return gameObject.GetComponent<CanvasGroup>().alpha == 1;
    }
    public void OnRecognize(RecognitionResult result)
	{
		if (result != RecognitionResult.Empty)
		{
			print(result.gesture.id);
			if (!scrollManager.ScrollSlot.Item.scroll.scrollDone)
            {
				for (int j = 0; j < scrollManager.elements.Length; j++)
				{
					if (result.gesture.id == scrollManager.elements[j].name)
					{
						if (scrollManager.elements[j].GetComponent<CanvasGroup>().alpha < 1)
						{
							scrollManager.elements[j].GetComponent<AudioSource>().Play();
							scrollManager.elements[j].GetComponent<CanvasGroup>().alpha = 1;
							for (int k = 0; k < scrollManager.elements[j].transform.childCount; k++)
							{
								scrollManager.elements[j].transform.GetChild(k).GetComponent<ParticleSystem>().Play();
							}
							break;
						}
					}
				}
				if(Array.TrueForAll(scrollManager.elements, Alpha1))
                {
					scrollManager.skills.AddXP(scrollManager.CurrentScroll.GetComponent<AddXP>().NameSkill, 10);
					scrollManager.CompleteScroll();
					scrollManager.ScrollSlot.Item.scroll.scrollDone = true;
				}
			}
		}
		else
		{
			print("?");
		}
		gameObject.GetComponent<DrawDetector>().ClearLines();
	}
}
