using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseOpenButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _button;
    private DatabaseManagementSystem _databaseManagementSystem;

    public void Init(string databaseName, DatabaseManagementSystem databaseManagementSystem)
    {
        _name.text = databaseName;
        _databaseManagementSystem = databaseManagementSystem;
    }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(OpenDatabase);
    }
    
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenDatabase);
    }
    
    private void OpenDatabase()
    {
        _databaseManagementSystem.OpenDatabase(_name.text);
    }
}