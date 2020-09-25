using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//defines Kill Screen Behavior, Turns off all audio sources, activates new audio source
//Deacticates game canvas
//Sets countdown and quits game

public class KillScreen : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField, Tooltip("Time Kill Screen Stays on Screen")]
    private float finalcountdown = 10;
    
    [Header("Audio")]
    [SerializeField, Tooltip("Volume of Kill Sound")]
    private float volume = 0.5f; 
   [SerializeField, Tooltip("Attatch to Kill Screen Audio Source")]
    private AudioSource killScreen=null;
    [SerializeField, Tooltip("Attatch to Kill Sound Audio Clip")]
    private AudioClip killSound=null;
    [SerializeField, Tooltip("Attach to Game Music Audio Source")]
    private GameObject gameMusic=null;
    [SerializeField, Tooltip("Attatch to Button Sound Audio Source")]
    private GameObject buttonSound=null;

    [Header("Game Canvas")]
    [SerializeField, Tooltip("Attach to Game Canvas")]
    private GameObject gameCanvas = null;
   

    private void Start()
    {
        gameMusic.SetActive(false);
        buttonSound.SetActive(false);
        gameCanvas.SetActive(false);
        killScreen.PlayOneShot(killSound, volume);
    }
    private void Update()
    {
        if (finalcountdown >= 0)
        {
            finalcountdown -= Time.deltaTime;

        }
        else
        {
#if UNITY_EDITOR //allows function in Unity Editor Runtime to mimic application exit
            EditorApplication.ExitPlaymode();
#endif
            Application.Quit();
        }
    }


}
