using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    public GameObject blockerPrefab;
    public GameObject teleporterPrefab;
    public GameObject empowerPrefab;

    public TextMeshProUGUI blockerCount;
    public TextMeshProUGUI teleportCount;
    public TextMeshProUGUI empowerCount;

    public GameObject droppers;
    public Inventory inventory;

    [SerializeField]
    private int _blockerCount;
    [SerializeField]
    private int _teleporterCount;
    [SerializeField]
    private int _empowerCount;

    private InventoryItem selectedItem;
    private Camera mainCamera;

    public void Awake()
    {
        if (Instance != this)
            Instance = this;
    }

    public void Start()
    {
        mainCamera = Camera.main;
        inventory = new Inventory(_blockerCount, _teleporterCount, _empowerCount);
        blockerCount.text = _blockerCount.ToString();
        teleportCount.text = _teleporterCount.ToString();
        empowerCount.text = _empowerCount.ToString();
    }

    public void AddItem(ItemType itemType)
    {
        inventory.AddToInventory(itemType);

        switch (itemType)
        {
            case ItemType.Blocker:
                blockerCount.text = inventory.GetItemCount(itemType).ToString();
                break;
            case ItemType.Teleporter:
                teleportCount.text = inventory.GetItemCount(itemType).ToString();
                break;
            case ItemType.Empower:
                empowerCount.text = inventory.GetItemCount(itemType).ToString();
                break;
        }
    }

    public void SpawnPrefab(int typeIndex)
    {
        var item = inventory.TakeFromInventory((ItemType)typeIndex);
        if (item == null)
            return;

        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        switch ((ItemType)typeIndex)
        {
            case ItemType.Blocker:
                {
                    var dropper = Instantiate(blockerPrefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                    dropper.GetComponent<DragAndDrop>().onCreated.Invoke();
                    blockerCount.text = inventory.GetItemCount((ItemType)typeIndex).ToString();
                    break;
                }
            case ItemType.Teleporter:
                {
                    var dropper = Instantiate(teleporterPrefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                    dropper.GetComponent<DragAndDrop>().onCreated.Invoke();
                    teleportCount.text = inventory.GetItemCount((ItemType)typeIndex).ToString();
                    break;
                }
            case ItemType.Empower:
                {
                    var dropper = Instantiate(empowerPrefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
                    dropper.GetComponent<DragAndDrop>().onCreated.Invoke();
                    empowerCount.text = inventory.GetItemCount((ItemType)typeIndex).ToString();
                    break;
                }
            default:
                break;
        }
    }
}
