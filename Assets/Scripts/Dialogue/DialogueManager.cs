using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

    public GameObject UI;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Dialogue;

    private Queue<string> sentences;

    private actor[] current_actor;
    private message[] current_message;
    private int active_dialogue = 0;

    public static DialogueManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	

    public void StartDialogue(Dialogue dialogue){
        UI.SetActive(true);
        current_actor = dialogue.actors;
        current_message = dialogue.messages;
        active_dialogue = 0;
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
            active_dialogue += 1;
            if (current_message.Length - 1 < active_dialogue){
                UI.SetActive(false);
                return;
            }
            foreach (string mess in current_message[active_dialogue].sentences){
                sentences.Enqueue(mess);
            }
        }
        string sentence = sentences.Dequeue();
        Name.text = current_actor[current_message[active_dialogue].id].name;
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
