using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Dialogue;

    private Queue<string> sentences;

    private actor[] current_actor;
    private message[] current_message;
    private int active_dialogue = 0;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartDialogue(Dialogue dialogue){
        current_actor = dialogue.actors;
        current_message = dialogue.messages;


        Name.text = current_actor[active_dialogue].name;
        sentences.Clear();

        foreach (string sentence in current_message[active_dialogue].sentences){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    //Put it in button or event trigger
    public void DisplayNextSentence(){
        if (sentences.Count == 0)
        {
            return;
        }
        string sentence = sentences.Dequeue();
        Dialogue.text = sentence;
        StopAllCoroutines();
        StartCoroutine(typing(sentence));
    }

    IEnumerator typing (string sentence){
        Dialogue.text = "";
        foreach(char letter in sentence.ToCharArray()){
            Dialogue.text += letter;
            yield return null;
        }
    }
}
