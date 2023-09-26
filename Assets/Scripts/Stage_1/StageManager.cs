using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float Countingtime = 0f;
    //time: 5min
    public const float StartingTime = 300.0f;// 300 second

    public static StageManager instance;
    [Header("Manager")]
    public CustomerManager CM;

    [Header("Objects")]
    public GameObject Clock;
    public GameObject Paper;
    private Vector3 OriginalPaperPosition;

    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Countingtime = StartingTime;
        CM.turn = true;
        OriginalPaperPosition = Paper.transform.position;
        Paper.SetActive(false);
    }

    public void Laundry_Button(){
        Debug.Log("Laundry Button");
        PrintPaper();
    }
    public void DryClean_Button(){
        PrintPaper();
    }
    public void HouseHold_Button(){
        PrintPaper();
    }

    public void PrintPaper(){
        Paper.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Countingtime > 0)
            Countingtime -= 1f * Time.deltaTime;

        if(CM.turn){
            Paper.transform.position = OriginalPaperPosition;
            Paper.SetActive(false);
        }
    }
}
