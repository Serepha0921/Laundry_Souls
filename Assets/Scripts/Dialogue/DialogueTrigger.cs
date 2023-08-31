using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public DialogueManager DM;
    public Dialogue dialogue;

    private void FixedUpdate()
    {
        Trig();
    }

    public void Trig()
    {
        if (Input.GetKey(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue(){
        DM.StartDialogue(dialogue);
    }
}
