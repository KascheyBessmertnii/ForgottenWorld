using UnityEngine;

public class GameItem : MonoBehaviour, IInterractable
{
    public void Get()
    {
        Debug.Log("Getting item");
    }

    public void ShowInfo()
    {
        Debug.Log("it`s item");
    }

    public void Use()
    {
        Debug.LogWarning("Cannot use this item");
    }
}
