using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "EffectSound", menuName = "ScriptableObjects/EffectSound", order = 4)]

public class EffectsSO : ScriptableObject
{
    [SerializeField] AudioClip myAudio;
    [SerializeField] AudioMixerGroup myGroup;

    public void StartSoundSelection() 
    {
        GameObject audioGameObject = new GameObject(); 
        AudioSource myAudioSource = audioGameObject.AddComponent<AudioSource>(); 

        myAudioSource.outputAudioMixerGroup = myGroup; 
        myAudioSource.PlayOneShot(myAudio); 
        Destroy(audioGameObject, 0.5f);

    }
}