using UnityEngine;
using UnityEngine.Rendering;


public class UIPanel : MonoBehaviour
{
	protected UIPanelManager _panelManager;

	public void Initiate(UIPanelManager manager)
	{
		_panelManager = manager;
	}
	public virtual void SetPanelActive(bool active)
	{
		gameObject.SetActive(active);
	}
}
