using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableView : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _button;
    [SerializeField] private Button _deleteButton;
    private DatabaseManagementSystem _databaseManagementSystem;
    private TableSetting _tableSetting;
    private Table _table;
    private UI _ui;

    public void Init(TableSetting tableSetting, Table table, UI ui, DatabaseManagementSystem databaseManagementSystem)
    {
        _tableSetting = tableSetting;
        _table = table;
        _ui = ui;
        _name.text = table.Name;
        _databaseManagementSystem = databaseManagementSystem;
        
        _deleteButton.gameObject.SetActive(User.IsAdmin);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenTable);
        _deleteButton.onClick.AddListener(RemoveTable);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenTable);
        _deleteButton.onClick.RemoveListener(RemoveTable);
    }

    private void OpenTable()
    {
        _tableSetting.SetUpTable(_table);
        _ui.ShowPanel<TablePanel>();
    }

    private void RemoveTable()
    {
        _databaseManagementSystem.RemoveTable(_table.Name);
        Destroy(gameObject);
    }
}