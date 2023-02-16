using UnityEngine;

public class UITimeUpPanel : UIPanel
{
	private Animator _animator;
	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	public override void SetPanelActive(bool active)
	{
		_animator.SetBool("isVisible",active);
	}
}
