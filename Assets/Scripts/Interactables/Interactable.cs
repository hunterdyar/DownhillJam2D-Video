using UnityEngine;

public class Interactable : MonoBehaviour
{
	protected int timesInteractedWith = 0;
	public virtual void Interact()
	{
		if (timesInteractedWith == 0)
		{
			FirstInteraction();
		}

		timesInteractedWith++;
	}

	public virtual void FirstInteraction()
	{
		
	}
}
