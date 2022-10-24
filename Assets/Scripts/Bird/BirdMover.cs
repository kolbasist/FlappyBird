using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapforce;

    private Rigidbody2D _rigidbody;

    private void Start()
    { 
        _rigidbody = GetComponent<Rigidbody2D>();
        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            _rigidbody.AddForce(Vector2.up * _tapforce, ForceMode2D.Force);
        }
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}
