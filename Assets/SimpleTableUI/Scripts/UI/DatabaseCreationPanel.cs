using TMPro;
using UnityEngine;

public class DatabaseCreationPanel : Panel
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private UI _ui;
    [SerializeField] private DatabaseManagementSystem _databaseManagementSystem;
    
    public void TryAccept()
    {
        if (_inputField.text == string.Empty)
        {
            ErrorPanel.Instance.ShowError("Database name cannot be empty");
        }
        else
        {
            _databaseManagementSystem.CreateDatabase(_inputField.text);
            _ui.ShowPanel<DatabasePreviewPanel>();
            _inputField.text = string.Empty;
        }
    }
}