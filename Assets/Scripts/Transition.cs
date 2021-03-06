using System;
using System.Collections;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Windows.Speech;

public class Transition : MonoBehaviour
{
    [Header("Video Players")]
    [SerializeField] private VideoPlayer player1, player2, player3;

    [Header("Primary Looping Clip")]
    [SerializeField] private VideoClip primaryClip1, primaryClip2, primaryClip3;

    [Header("Special Event Clip")]
    [SerializeField] private VideoClip eventClip1, eventClip2, eventClip3;

    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeDuration = 3f, eventDuration = 15, swapPause = 1;

    private bool transitioning;
    
    // Start is called before the first frame update
    void Start()
    {
        DictationMonitor.m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            if (!transitioning) StartCoroutine(DoTransition());
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Fades the screen to black and then back to normal, with speed based on fadeSpeed.
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeTransiton()
    {
        // this could be cleaned up in order to not have to deal with these dumb values
        var startTime = Time.time;
        Color black = new Color(0, 0, 0, 0.0001f);
        var peaked = false;
        while (black.a > 0)
        {
            var t = (Time.time - startTime) / fadeDuration;
            black.a = peaked ? Mathf.SmoothStep(1, 0, t) : Mathf.SmoothStep(0.0001f, 1, t);
            blackScreen.color = black;
            yield return new WaitForFixedUpdate();
            Debug.Log("a: " + black.a);
            if (black.a >= 1)
            {
                peaked = true;
                startTime = Time.time - 0.01f;
                Debug.Log("alpha value triggered");
            }
        }
    }

    IEnumerator DoTransition()
    {
        transitioning = true;   
        StartCoroutine(FadeTransiton());
        yield return new WaitForSeconds(swapPause);
        player1.clip = eventClip1;
        player2.clip = eventClip2;
        player3.clip = eventClip3;
        yield return new WaitForSeconds(eventDuration);
        StartCoroutine(FadeTransiton());
        yield return new WaitForSeconds(swapPause);
        player1.clip = primaryClip1;
        player2.clip = primaryClip2;
        player3.clip = primaryClip3;
        transitioning = false;
    }
    
}
