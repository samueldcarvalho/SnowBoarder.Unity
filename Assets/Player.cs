using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        CrashDetector.OnCollided += _crashDetecetor_OnCollided;
        FinishLine.OnFinished += FinishLine_OnFinished;
    }

    private void Update()
    {
        float rotationAmount = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;

        _rigidbody2D.AddTorque(-rotationAmount, ForceMode2D.Force);
    }

    private void _crashDetecetor_OnCollided()
    {
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FinishLine_OnFinished()
    {
        Invoke("AdvanceScene", 3);
    }

    private void AdvanceScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
