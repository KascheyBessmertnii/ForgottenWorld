using UnityEngine;

[RequireComponent(typeof(OpenCloseSM))]
public class OpeningObject : InteractiveObject
{
    private OpenCloseSM stateMashine;
    private void OnEnable()
    {
        TryGetComponent(out stateMashine);
    }

    public override void Interract()
    {
        if (stateMashine == null) return;

        if (stateMashine.currentState == stateMashine.open)
            stateMashine.SetState(stateMashine.close);
        if (stateMashine.currentState == stateMashine.close)
            stateMashine.SetState(stateMashine.open);
    }
}
