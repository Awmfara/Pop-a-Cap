using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class Playa : MonoBehaviour
{
    
    [Header("Buttons")]
    public Button cap;
    
    [Header("Playa Settings")]
    private float playaLevel = 0;
    [SerializeField]
    private float playaXp = 0;
    [SerializeField]
    private float clickAmount = 0;
    private float initCaps = 0;
    public Rect audiorect;

 

    public AudioSource buttonSound;
    public AudioClip xylo;
    public float volume = 0.5f;
    private void Start()
    {
        audiorect = new Rect(20, 20, 100, 20);
        cap.onClick.AddListener(butPress);
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
  buttonSound.PlayOneShot(xylo, volume);
        }
 
        if (clickAmount>=10)
        {
            playaXp++;
            clickAmount = 0;

        }
    }
    void butPress()
    {
      
        clickAmount++;
      

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        DrawRect(audiorect);
    }
    private void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
   
}
