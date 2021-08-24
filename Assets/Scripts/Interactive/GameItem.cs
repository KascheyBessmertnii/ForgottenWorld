using UnityEngine;

public class GameItem : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    [SerializeField] private int count;

    public ItemSO Item => item;
    public int Count => count;
}
