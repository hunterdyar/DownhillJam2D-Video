using TMPro;
using UnityEngine;

public class UIHUDPanel : UIPanel
{
	[SerializeField] private TMP_Text _text;

	void Update()
	{
		_text.text = _panelManager.GetRaceManager().GetRaceTimer().GetTimeLeftInSeconds();
	}
}
