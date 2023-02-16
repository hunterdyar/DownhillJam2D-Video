using UnityEngine;

public class FinishLine : Interactable
{
	[SerializeField] private RaceManager _raceManager;
	public override void FirstInteraction()
	{
		_raceManager.AtFinishLine();
	}
}
