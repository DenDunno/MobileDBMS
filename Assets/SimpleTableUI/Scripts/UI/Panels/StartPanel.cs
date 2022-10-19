using UnityEngine;
using UnityEngine.UI;

public class StartPanel : Panel
{
    [SerializeField] private Button _createDatabaseButton;
    [SerializeField] private Button _openDatabaseButton;
    [SerializeField] private UI _ui;
    
    private void OnEnable()
    {
        _createDatabaseButton.onClick.AddListener(ShowDatabaseCreationPanel);
        _openDatabaseButton.onClick.AddListener(ShowDatabaseOpeningPanel);
    }
    
    private void OnDisable()
    {
        _createDatabaseButton.onClick.RemoveListener(ShowDatabaseCreationPanel);
        _openDatabaseButton.onClick.RemoveListener(ShowDatabaseOpeningPanel);
    }

    private void ShowDatabaseOpeningPanel()
    {
        _ui.ShowPanel<DatabaseOpeningPanel>();
    }

    private void ShowDatabaseCreationPanel()
    {
        _ui.ShowPanel<DatabaseCreationPanel>();
    }
}