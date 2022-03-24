using System;
using TilePathfinding;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Test Instantiate", menuName = "Instantiation / Standard")]
public class StandardInstantiateBehaviour : InstantiationBehaviour
{
    public override GameObject Instantiate(Tile tile, TilePreset content)
    {
        var instantiatedContent = Object.Instantiate(content.presetObject[0], tile.transform);
        instantiatedContent.transform.localPosition = content.presetPosition[0];
        instantiatedContent.transform.Rotate(content.presetRotation[0]);
        instantiatedContent.transform.localScale = content.presetScale[0];
        instantiatedContent.name = name;
        return instantiatedContent;
    }
}