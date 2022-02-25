using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectScheduler { 

    public class ItemsManager : MonoBehaviour
    {
        private Queue<Item> ItemsQ;
        
        [SerializeField] private GameObject itemPrefab;

        //Inputfields UI
        [SerializeField] private InputField nameInputField;
        [SerializeField] private InputField descInputField;
        [SerializeField] private InputField timeInputField;

        //temp values for receiving input
        [SerializeField] private string iname, desc;
        [SerializeField] private int time;

        private Transform m_content;

        
        private void Start()
        {
            m_content = GameObject.FindGameObjectWithTag("Content").GetComponent<Transform>();
            LoadPreviousItems();
        }
		private void Update()
		{
			if(Input.GetKeyDown(KeyCode.P))
			{
                AddItem();
			}
		}

		private void LoadPreviousItems()
		{
            ItemsQ = new Queue<Item>();

            Debug.Log("ItemsQ:" + ItemsQ.Count);
            //method for loading previous values after
            //application quit
        }
        public void Add_Name(string n) { iname = n; }
        public void Add_Desc(string d) { desc = d; }
        public void Add_Time(string h)
		{
			try	 {  time = System.Convert.ToInt32(h); }
			catch{ Debug.LogError("Format was off");  }
		}
        public void SubmitInput()
		{
            Debug.Log("I was called");
            SaveItem();
		}
        
        private void SaveItem()
		{
            //stores the input into Queue
            StoreInputHelper();

            //adds new item to list to be displayed
            AddItem();


            ResetInput();
        }
        private IEnumerator ResetInputCoroutine(float delay)
		{
            yield return new WaitForSeconds(delay);

            //reset display
            nameInputField.text = "";
            descInputField.text = "";
            timeInputField.text = "";

            Debug.Log("Coroutine");
        }
        private void ResetInput()
		{
            Debug.Log("Calling Coroutine...");

            StartCoroutine(ResetInputCoroutine(1.0f));

            //resets input variables
            iname = "";
            desc = "";
            time = -1;

            Debug.Log("End Function");
		}
        private void StoreInputHelper()
        {
            Item testValues = new Item();
            testValues.name = iname;
            testValues.description = desc;
            testValues.hours = time;

            ItemsQ.Enqueue(testValues);
        }
        private void AddItem()
		{
            GameObject newItem = Instantiate(itemPrefab);
            newItem.transform.SetParent(m_content, false);
            newItem.GetComponentInChildren<Text>().text = iname;
        }
    }
}
