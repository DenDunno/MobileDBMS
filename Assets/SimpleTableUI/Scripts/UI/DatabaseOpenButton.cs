using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseOpenButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _button;
    [SerializeField] private Button _deleteButton;
    private DatabaseManagementSystem _databaseManagementSystem;
    private UI _ui;
    
    public void Init(DatabaseManagementSystem databaseManagementSystem, string databaseName, UI ui)
    {
        _databaseManagementSystem = databaseManagementSystem;
        _name.text = databaseName;
        _ui = ui;
        
        _deleteButton.gameObject.SetActive(User.IsAdmin);
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OpenDatabase);
        _deleteButton.onClick.AddListener(RemoveDatabase);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenDatabase);
        _deleteButton.onClick.RemoveListener(RemoveDatabase);
    }

    private void OpenDatabase()
    {
        _databaseManagementSystem.OpenDatabase(_name.text);
        _ui.ShowPanel<DatabasePreviewPanel>();
    }

    private void RemoveDatabase()
    {
        _databaseManagementSystem.RemoveDatabase(_name.text);
        Destroy(gameObject);
    }
}