using UnityEngine;
namespace Zenject.TD
{
	public class BuildManager : MonoBehaviour
	{

		public static BuildManager instance;

		void Awake()
		{
			if (instance != null)
			{
				Debug.LogError("More than one BuildManager in scene!");
				return;
			}
			instance = this;
		}

		private Turret turretToBuild;
		private Node selectedNode;


		public bool CanBuild { get { return turretToBuild != null; } }

		public void SelectNode(Node node)
		{
			if (selectedNode == node)
			{
				DeselectNode();
				return;
			}

			selectedNode = node;
			turretToBuild = null;

		}

		public void DeselectNode()
		{
			selectedNode = null;
		}

		public void SelectTurretToBuild(Turret turret)
		{
			turretToBuild = turret;
			DeselectNode();
		}

		public Turret GetTurretToBuild()
		{
			return turretToBuild;
		}

	}
}