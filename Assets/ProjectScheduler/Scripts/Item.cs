using UnityEngine;

namespace ProjectScheduler
{

	[System.Serializable]
	public class Item
	{
		public string name, description;
		public int hours, minutes;

		public void Test() { Debug.Log(name + description + hours); }
		

	}
}
