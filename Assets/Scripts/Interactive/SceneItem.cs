public class SceneItem : InteractiveObject
{
    public override void Interract()
    {
        TryGetComponent(out GameItem item);

        if (GameEvents.OnGetItem == null) return;

        if (GameEvents.OnGetItem.Invoke(item))
        {
            Destroy(gameObject);
        }
    }
}
