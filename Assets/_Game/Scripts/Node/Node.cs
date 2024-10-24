using UnityEngine.EventSystems;
using UnityEngine;

namespace Zenject.TD
{
	using UnityEngine;

	public class Node : MonoBehaviour
	{

		public Color hoverColor;
		public Color notEnoughMoneyColor;
		public Vector3 positionOffset;

		[HideInInspector]
		public GameObject turret;
		[HideInInspector]
		public Turret turretBlueprint;
		[HideInInspector]
		public bool isUpgraded = false;

		private Renderer rend;
		private Color startColor;

		BuildManager buildManager;

		void Start()
		{
			rend = GetComponent<Renderer>();
			startColor = rend.material.color;

			buildManager = BuildManager.instance;
		}

		public Vector3 GetBuildPosition()
		{
			return transform.position + positionOffset;
		}

		void OnMouseDown()
		{
			if (EventSystem.current.IsPointerOverGameObject())
				return;

			if (turret != null)
			{
				buildManager.SelectNode(this);
				return;
			}

			if (!buildManager.CanBuild)
				return;

			BuildTurret(buildManager.GetTurretToBuild());
		}

		void BuildTurret(Turret blueprint)
		{
			

			GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;

			turretBlueprint = blueprint;


			Debug.Log("Turret build!");
		}

		public void UpgradeTurret()
		{
		

			//Get rid of the old turret
			Destroy(turret);

			//Build a new one
			GameObject _turret = (GameObject)Instantiate(turretBlueprint.prefab, GetBuildPosition(), Quaternion.identity);
			turret = _turret;

			isUpgraded = true;

			Debug.Log("Turret upgraded!");
		}

		
		void OnMouseEnter()
		{
			if (EventSystem.current.IsPointerOverGameObject())
				return;

			if (!buildManager.CanBuild)
				return;


		}

		void OnMouseExit()
		{
			rend.material.color = startColor;
		}

	}

}