using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpeechDetection : MonoBehaviour
{
    
    // code adapted from: https://stackoverflow.com/questions/40913081/unity-microphone-check-if-silent
    
    [SerializeField] private AudioSource micAudioSource;
    [SerializeField] private float volumeThreshold;
    public static bool isSpeaking;
    [SerializeField] private string deviceName;
    private float[] clipSampleData = new float[1024];
    
    // debug
    [SerializeField] private Text micVolText;
    [SerializeField] private Text micDeviceText;

    private void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        // If device name is empty or not valid, will default to first mic in list
        deviceName = deviceName == "" || !Microphone.devices.Contains(deviceName) ? Microphone.devices[0] : deviceName;
        //Debug.Log("Audio device set to: " + deviceName);
        micDeviceText.text = "Mic Device: " + deviceName;
        
        micAudioSource.clip = Microphone.Start(deviceName, true, 60, 16000);
        while (!(Microphone.GetPosition(null) > 0)) { } // ??? what is this
        micAudioSource.Play();
    }

    private void Update()
    {
        // TODO: check audio channels and switch
        micAudioSource.GetSpectrumData(clipSampleData, 0, FFTWindow.Rectangular);
        float currentAverageVolume = clipSampleData.Average();

        if (currentAverageVolume >= volumeThreshold)
        {
            isSpeaking = true;
            micVolText.text = "Mic Volume: " + Math.Round(currentAverageVolume, 3) + " DB";
            //Debug.Log("We can hear you! " + currentAverageVolume + " DB");
        } 
        else if ( isSpeaking ){
            isSpeaking=false;
            //Debug.Log("We can no longer hear you...");
            micVolText.text = "Mic Volume: Not speaking";
            //volume below level, but user was speaking before. So user stopped speaking
        }
    }
}
