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
    }

    // Update is called once per frame
    void Update()
    {
        if(Countingtime > 0)
            Countingtime -= 1f * Time.deltaTime;
    }
}
