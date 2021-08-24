using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInterractable
{
    public virtual void Interract()
    {
        TryGetComponent(out GameItem item);

        if(GameEvents.OnGetItem != null)
        {
            if (GameEvents.OnGetItem.Invoke(item))
            {
                Destroy(gameObject);
            }
        }
    }
}
