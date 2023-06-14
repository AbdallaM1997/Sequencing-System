using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Common Refrance")]
    [SerializeField] Animator animator;
    AudioSource audioSource;

    [Header("Sequents Action")]
    [SerializeField] SequanceData[] sequanceEvents;

    public void Start()
    {
        //animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();  
    }
    public void StartTheSequenc()
    {
        StartCoroutine(StarTheSequenc());
    }
    private IEnumerator StarTheSequenc()
    {
        for (int i = 0; i < sequanceEvents.Length; i++)
        {
            sequanceEvents[i].actionNeedToDo.Invoke();
            if (sequanceEvents[i].animtionName != "")
            {
                animator.Play(sequanceEvents[i].animtionName);
                yield return new WaitForSeconds(sequanceEvents[i].currentAnimtionClip.length);
            }
            if (sequanceEvents[i].clip != null)
            {
                audioSource.clip = sequanceEvents[i].clip;
                audioSource.Play();
                yield return new WaitForSeconds(sequanceEvents[i].clip.length);
            }
        }
    }

}
[Serializable]
public class SequanceData
{
    public string name;
    public string animtionName;
    public AnimationClip currentAnimtionClip;
    public AudioClip clip;
    [Space]
    public UnityEvent @actionNeedToDo;
}
