using UnityEngine;

public class InterractiveObject : MonoBehaviour, IInterractable
{
    public void Get()
    {
        Debug.LogWarning("Cannot get this object");
    }

    public void ShowInfo()
    {
        Debug.Log("This is intrective object");
    }

    public void Use()
    {
        Debug.Log("Use object");
    }
}
