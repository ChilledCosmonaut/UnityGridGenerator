using System;
using TilePathfinding;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Test Instantiate", menuName = "Instantiation / Standard")]
public class StandardInstantiateBehaviour : InstantiationBehaviour
{
    public override GameObject Instantiate(Tile tile, TilePreset content)
    {
        var instantiatedContent = Object.Instantiate(content.presetObject, tile.transform);
        instantiatedContent.transform.localPosition = content.presetPosition;
        instantiatedContent.transform.Rotate(content.presetRotation);
        instantiatedContent.transform.localScale = content.presetScale;
        instantiatedContent.name = ((Object)this).name;
        return instantiatedContent;
    }
}