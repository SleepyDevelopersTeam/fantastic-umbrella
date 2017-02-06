using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO
public enum GUIType { Game, Inventory, Loot, Pause, Shop }

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public Pool EnemyPool, BulletPool;
    public GameObject LevelRoot;

    // TODO:
    // public Joystick PlayerMover;
    // public DropdownButton AbilityButton, InventoryItemButton;
    // public Button PauseButton, OpenInventoryButton;
    // private Canvas CurrentGUI;

    public void OpenGUI(GUIType which) { }

    public GameController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
