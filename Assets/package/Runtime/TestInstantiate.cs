using UnityEngine;

namespace TilePathfinding
{
    [CreateAssetMenu(fileName = "Test Instantiate", menuName = "Instantiation / Test")]
    public class TestInstantiate : InstantiationBehaviour
    {
        public override GameObject Instantiate(Tile tile, TilePreset content)
        {
            return null;
        }
    }
}