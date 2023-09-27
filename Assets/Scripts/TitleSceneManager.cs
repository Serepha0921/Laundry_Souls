using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene{
    public static int scenetoLoad = 0;
}
public class TitleSceneManager : MonoBehaviour
{
    [Header("Background")]
    public GameObject Night_1;
    public GameObject Night_2;
    public GameObject Shadow;

    [Space]
    [Tooltip("Smaller Number = Faster")]
    public float FadeTime;
    private float time = 0f;

    [Space]
    public bool isPlaying = false;

    private SpriteRenderer n_1;
    private SpriteRenderer n_2;

    private void Awake()
    {
        n_1 = Night_1.GetComponent<SpriteRenderer>();
        n_2 = Night_2.GetComponent<SpriteRenderer>();
        Shadow.SetActive(false);
    }

    public void GameStartButton() {
        if (isPlaying)
        {
            return;
        }
        Debug.Log("Clicked");
        StartCoroutine("Fade");
    }

    public void OptionButton() {
        if (isPlaying)
        {
            return;
        }
        Debug.Log("Open_Option");
    }

    public void ContinueButton()
    {
        if (isPlaying)
        {
            return;
        }
        Debug.Log("Continue");
    }

    public void QuitButton() {
        if (isPlaying)
        {
            return;
        }
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BlinkOn(GameObject light)
    {
        light.SetActive(true);
    }

    public void BlinkOff(GameObject light)
    {
        light.SetActive(false);
    }

    IEnumerator Fade() {

        isPlaying = true;

        Color fade1 = n_1.color;
        Color fade2 = n_2.color;

        time = 0f;

        while (fade1.a > 0 && fade2.a >0)
        {
            time += Time.deltaTime / FadeTime;

            fade1.a = Mathf.Lerp(1, 0, time);
            fade2.a = Mathf.Lerp(1, 0, time);
            yield return new WaitForSeconds(0.1f);
            n_1.color = fade1;
            n_2.color = fade2;
        }

        Shadow.SetActive(true);
        Night_1.SetActive(false);
        Night_2.SetActive(false);

        yield return new WaitForSeconds(0.75f);

        isPlaying = true;

        Debug.Log("Move_To_nextScene");
        nextScene.scenetoLoad = 3;
        SceneManager.LoadScene(2);

        yield return null;
    }
}
