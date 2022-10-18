using TMPro;
using UnityEngine;

public class TableCreationPanel : Panel
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private UI _ui;
    [SerializeField] private DatabaseManagementSystem _databaseManagementSystem;

    public void TryAccept()
    {
        if (_inputField.text == string.Empty)
        {
            ErrorPanel.Instance.ShowError("Table name cannot be empty");
        }
        
        else if (_databaseManagementSystem.TryAddTable(_inputField.text))
        {
            _ui.ShowPanel<DatabasePreviewPanel>();
            _inputField.text = string.Empty;
        }
    }
}