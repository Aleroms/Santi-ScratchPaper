using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectScheduler
{
	public class AddPanel_Anim : MonoBehaviour
	{
		private Animator m_animator;
		private bool m_panelToggle = false;
		private void Start()
		{
			m_animator = GetComponent<Animator>();
		}
		public void ChangePanelState()
		{
			m_panelToggle = !m_panelToggle;
			m_animator.SetBool("isOpen", m_panelToggle);
		}
	}
}
