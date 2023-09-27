using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public GameObject player;
    public bool Scene1 = true;
    // Start is called before the first frame update
    private DialogueTrigger MC;
    public static StoreManager instance;

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
    private void Start()
    {
        MC = player.GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Scene1){
            MC.TriggerDialogue();
            Scene1 = false;
        }
    }
}
