using UnityEngine;

public static class Utilits
{
    public static Camera mainCamera = null;

    public static RaycastHit GetSceneClickPoint(LayerMask layer, float distance)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, distance, layer))
        {
            return hit;
        }

        return default;
    }
}
