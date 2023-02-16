using UnityEngine;

public class Checkpoint : Interactable
{
	[SerializeField] private float timeToAdd;
	[SerializeField] private RaceManager _raceManager;
	public override void FirstInteraction()
	{
		_raceManager.AddTimeToTimer(timeToAdd);
	}
}
