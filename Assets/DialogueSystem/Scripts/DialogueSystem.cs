using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


namespace DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;

        public Animator animator;

        private Queue<string> sentences;
        public static DialogueSystem Instance;

		private void Awake()
		{
            if (Instance == null)
                Instance = this;
			else
			{
                Destroy(gameObject);
                return;
			}
		}

		void Start()
        {
            sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            animator.SetBool("isOpen", true);

            sentences.Clear();
            
            nameText.text = dialogue.name;

            foreach (string s in dialogue.sentences)
            {
                sentences.Enqueue(s);
            }

            DisplayNextSentence();
        }
        public void EndDialogue()
		{
            animator.SetBool("isOpen", false);
        }
        public void DisplayNextSentence()
		{

            //reached end of Q
            if(sentences.Count == 0)
			{
                EndDialogue();
                return;
			}
			else
			{
                string s = sentences.Dequeue();

                //user starts another sentence before anim is finished
                StopAllCoroutines();

                StartCoroutine(TypeEffectCoroutine(s));
			}
		}
        private IEnumerator TypeEffectCoroutine(string s)
		{
            dialogueText.text = "";

            foreach(char c in s.ToCharArray())
			{
                dialogueText.text += c;

                //wait one single frame
                yield return null;
			}
		}


    }
}
