using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatabasePreviewPanel : Panel
{
    [SerializeField] private TMP_Text _databaseName;
    [SerializeField] private GridLayoutGroup _grid;
    [SerializeField] private DatabaseManagementSystem _databaseManagementSystem;
    [SerializeField] private TableView _tableViewPrefab;
    [SerializeField] private Button _tableCreationButton;
    [SerializeField] private UI _ui;
    [SerializeField] private TableSetting _tableSetting;
    
    private void OnEnable()
    {
        _tableCreationButton.onClick.AddListener(ShowTableCreationPanel);
    }

    private void OnDisable()
    {
        _tableCreationButton.onClick.RemoveListener(ShowTableCreationPanel);
    }

    private void ShowTableCreationPanel()
    {
        _ui.ShowPanel<TableCreationPanel>();
    }

    protected override void OnShow()
    {
        Database database = _databaseManagementSystem.Database;
        
        _databaseName.text = database.Name;
        
        _grid.transform.DestroyChildren();
        
        foreach (Table table in database.Tables.Values)
        {
            TableView tableView = Instantiate(_tableViewPrefab, _grid.transform);
            tableView.Init(_tableSetting, table, _ui, _databaseManagementSystem);
        }
    }
}