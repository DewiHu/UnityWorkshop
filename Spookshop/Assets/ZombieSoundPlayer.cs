using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundPlayer : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(RandomSoundTimer());
    }

    private IEnumerator RandomSoundTimer()
    {
        while(true)
        {
            PlaySound();
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
