using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Zenject.TD
{
    public class TurretManager : MonoBehaviour
    {
        readonly TurretSpawner _turretSpawner;
        readonly TurretFacade.Factory _turretFactory;
        Transform p;
        [SerializeField] Vector3 clickPosition;


        

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;

                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _turretFactory.Create(clickPosition, p);

            }

        }
    }
}