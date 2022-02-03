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
    [SerializeField] private VideoPlayer player1;
    [SerializeField] private VideoPlayer player2;
    [SerializeField] private VideoPlayer player3;

    [Header("Primary Looping Clip")]
    [SerializeField] private VideoClip primaryClip1;
    [SerializeField] private VideoClip primaryClip2;
    [SerializeField] private VideoClip primaryClip3;

    [Header("Special Event Clip")]
    [SerializeField] private VideoClip eventClip1;
    [SerializeField] private VideoClip eventClip2;
    [SerializeField] private VideoClip eventClip3;

    [SerializeField] private Image blackScreen;
    [SerializeField] private float fadeSpeed;
    
    // Start is called before the first frame update
    void Awake()
    {
        
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
        Color black = new Color(0, 0, 0, 0.0001f);
        bool peaked = false;
        while (black.a != 0)
        {
            black.a += peaked ? -1 * fadeSpeed : 1 * fadeSpeed;
            blackScreen.color = black;
            yield return new WaitForFixedUpdate();
            if (black.a >= 255) peaked = true;
        }
    }
    
}
