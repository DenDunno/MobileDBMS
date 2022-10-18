using UnityEngine;
using UnityEngine.UI;

public class TablePanel : Panel
{
    [SerializeField] private TableSetting _tableSetting;
    [SerializeField] private Button _databasePreviewButton;
    [SerializeField] private UI _ui;

    private void OnEnable()
    {
        _databasePreviewButton.onClick.AddListener(ShowDatabasePreviewPanel);
    }

    private void OnDisable()
    {
        _databasePreviewButton.onClick.RemoveListener(ShowDatabasePreviewPanel);
    }

    private void ShowDatabasePreviewPanel()
    {
        _tableSetting.ReadTable();
        _ui.ShowPanel<DatabasePreviewPanel>();
    }
}
