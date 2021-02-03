using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public Inventory inventory;

    public GameObject blockerPrefab;
    public GameObject teleporterPrefab;
    public GameObject empowerPrefab;

    [SerializeField]
    private int _blockerCount;
    [SerializeField]
    private int _teleporterCount;
    [SerializeField]
    private int _empowerCount;

    private InventoryItem selectedItem;

    public void Start()
    {
        inventory = new Inventory(_blockerCount, _teleporterCount, _empowerCount);
    }

    public void Update()
    {
        
    }


    public void SelectItem()
    {
        
    }

    public void DragItem()
    {

    }
}
