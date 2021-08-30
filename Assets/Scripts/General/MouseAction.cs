using UnityEngine;

public static class MouseAction
{
    public static void Interract(int mouseBtn, LayerMask layer)
    {
        if (Input.GetMouseButtonDown(mouseBtn))
        {
            Utilits.GetSceneClickPoint(layer, 100f).transform?.GetComponent<IInterractable>().Interract();
        }
    }

    public static Vector3 Move(LayerMask layer, float distance = 100f)
    {
        return Utilits.GetSceneClickPoint(layer, distance).point;        
    }
}
