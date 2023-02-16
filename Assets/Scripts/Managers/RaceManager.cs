using System;
using Managers;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
	[SerializeField] private float startingRaceTime;
	
	private RaceState _state;
	private Timer _timer;
	private void Awake()
	{
		_timer = new Timer();
		_state = RaceState.Countdown;
	}

	private void Start()
	{
		StartRace();
	}

	private void StartRace()
	{
		_state = RaceState.Racing;
		_timer.InitTimer(startingRaceTime);
	}

	private void Update()
	{
		if (_state == RaceState.Racing)
		{
			_timer.TickTimer();
			if (_timer.TimeIsUp())
			{
				OutOfTime();
			}
		}
	}

	private void OutOfTime()
	{
		if (_state == RaceState.Racing)
		{
			Debug.Log("out of time!");
			_state = RaceState.TimeUp;
		}
	}

	public void AtFinishLine()
	{
		//if we are still in the "racing" state.
		if (_state == RaceState.Racing)
		{
			Debug.Log("Made it!");
			_state = RaceState.AtFinishLine;
		}
	}

	public void AddTimeToTimer(float timeToAdd)
	{
		if (_state == RaceState.Racing)
		{
			_timer.AddTime(timeToAdd);
		}
	}

	public RaceState GetRaceState()
	{
		return _state;
	}

	/// <summary>
	/// True when the gameplay state is racing, and not win/lose/countdown/etc.
	/// </summary>
	public bool IsRaceActive()
	{
		return _state == RaceState.Racing;
	}
}
