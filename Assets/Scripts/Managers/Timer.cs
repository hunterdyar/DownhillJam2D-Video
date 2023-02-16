using UnityEngine;

namespace Managers
{
	public class Timer
	{
		private float _timer;

		public void InitTimer(float seconds)
		{
			_timer = seconds;
		}

		public void TickTimer()
		{
			_timer = _timer - Time.deltaTime;
		}

		public bool TimeIsUp()
		{
			return _timer <= 0;
		}

		public void AddTime(float secondsToAdd)
		{
			secondsToAdd = Mathf.Max(secondsToAdd, 0);
			_timer += secondsToAdd;
		}

		public string GetTimeLeftInSeconds()
		{
			return Mathf.Ceil(_timer).ToString();
		}
	}
}