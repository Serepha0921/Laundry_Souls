using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public DialogueManager DM;
    public Dialogue dialogue;

    public void TriggerDialogue(){
        DM.StartDialogue(dialogue);
    }
}
