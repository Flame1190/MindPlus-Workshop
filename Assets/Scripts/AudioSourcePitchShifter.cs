using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePitchShifter : MonoBehaviour
{
    public float Min;
    public float Max;
    private void Awake()
    {
        GetComponent<AudioSource>().pitch = Random.Range(Min, Max);
    }
}
