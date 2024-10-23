using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenject.TD
{
    public class EnemyBuilder : MonoBehaviour
    {
        [SerializeField]
        MeshRenderer _renderer = null;

        [SerializeField]
        Collider _collider = null;

        [SerializeField]
        Rigidbody _rigidBody = null;

        [Inject]
        public EnemyFacade Facade
        {
            get; set;
        }
        public Collider Collider
        {
            get { return _collider; }
        }

        public Rigidbody Rigidbody
        {
            get { return _rigidBody; }
        }

        public Vector3 Position
        {
            get { return _rigidBody.transform.position; }
            set { _rigidBody.transform.position = value; }
        }
    }

}