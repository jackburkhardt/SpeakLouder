using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

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
    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
