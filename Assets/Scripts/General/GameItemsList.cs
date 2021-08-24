using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameItemsList : MonoBehaviour
{
    public static GameItemsList Instance { get; private set; }

    [SerializeField] private List<ItemSO> items;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public ItemSO GetItemByID(int id)
    {
        return items.FirstOrDefault(x => x.id == id);
    }
}
