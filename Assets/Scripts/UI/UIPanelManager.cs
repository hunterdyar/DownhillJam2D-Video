using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
	private RaceState _displayedRaceState;
	[SerializeField] private RaceManager _raceManager;

	[SerializeField] private UIPanel HUDPanel;
	[SerializeField] private UIPanel TimeUpPanel;
	[SerializeField] private UIPanel FinishPanel;

	private void Awake()
	{
		HUDPanel.Initiate(this);
		TimeUpPanel.Initiate(this);
		FinishPanel.Initiate(this);
	}

	private void Update()
	{
		if (_displayedRaceState != _raceManager.GetRaceState())
		{
			UpdatePanelsToState(_raceManager.GetRaceState());
		}
	}

	void UpdatePanelsToState(RaceState displayState)
	{
		_displayedRaceState = displayState;
		HUDPanel.SetPanelActive(_raceManager.GetRaceState() == RaceState.Racing);
		TimeUpPanel.SetPanelActive(_raceManager.GetRaceState() == RaceState.TimeUp);
		FinishPanel.SetPanelActive(_raceManager.GetRaceState() == RaceState.AtFinishLine);
	}

	public RaceManager GetRaceManager()
	{
		return _raceManager;
	}
}
