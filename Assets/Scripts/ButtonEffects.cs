using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEffects : MonoBehaviour
{
    [SerializeField,Tooltip("")]
    private Playa playa;
    [SerializeField, Tooltip("")]
    private Animator samFace;

    #region Buttons
    [Header("Buttons")]
    [SerializeField, Tooltip("")]
    private Button cat=null;
    [SerializeField, Tooltip("")]
    private Button bag=null;
    [SerializeField, Tooltip("")]
    private Button smack=null;
    [SerializeField, Tooltip("")]
    private Button spoon=null;
    #endregion

    private void Start()
    {
        cat.onClick.AddListener(CatPress);
        bag.onClick.AddListener(BagPress);
        smack.onClick.AddListener(SmackPress);
        spoon.onClick.AddListener(SpoonPress);
    }

    void CatPress()
    {

    }
    void BagPress()
    {

    }
    void SmackPress()
    {

    }
    void SpoonPress()
    {

    }
}
