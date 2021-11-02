using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMove : MonoBehaviour
    {
        [SerializeField, Range(10, 35)]
        private float _speed = 25f;

        [SerializeField, AttentionField]
        private Rigidbody2D _rigidbody;

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.up * _speed;
        }
    }
}
