using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public static event Action OnFinished;

    [SerializeField]
    private ParticleSystem _finishedEffect;

    private void Start()
    {
        OnFinished += FinishLine_OnFinished;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            OnFinished();
    }

    private void FinishLine_OnFinished()
    {
        _finishedEffect.Play();
    }
}
