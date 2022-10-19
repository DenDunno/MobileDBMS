using Newtonsoft.Json;
using UnityEngine;

public class DatabaseManagementSystem  : MonoBehaviour
{
    private SaveData _saveData = new SaveData();
    
    public Database Database { get; private set; } 
    
    public bool TryCreateDatabase(string databaseName)
    {
        if (_saveData.Databases.ContainsKey(databaseName))
        {
            ErrorPanel.Instance.ShowError("Database with such name already exists");
            return false;
        }

        Database = new Database()
        {
            Name = databaseName
        };

        _saveData.Databases.Add(databaseName, Database);
        
        return true;
    }

    public bool TryAddTable(string tableName)
    {
        bool success = Database.Tables.ContainsKey(tableName) == false;
        
        if (success)
        {
            Database.Tables.Add(tableName, new Table()
            {
                Name = tableName
            });
        }
        else
        {
            ErrorPanel.Instance.ShowError("Table with such name already exists");
        }

        return success;
    }

    public void Save()
    {
        _saveData.Databases[Database.Name] = Database;
        SaveData();
    }

    public void OpenDatabase(string databaseName)
    {
        _saveData = JsonConvert.DeserializeObject<SaveData>(PlayerPrefs.GetString("Save"));
        Database = _saveData.Databases[databaseName];
    }

    public void RemoveDatabase(string databaseName)
    {
        if (_saveData.Databases.ContainsKey(databaseName))
        {
            _saveData.Databases.Remove(databaseName);
            SaveData();
        }
    }

    public void RemoveTable(string tableName)
    {
        if (Database.Tables.ContainsKey(tableName))
        {
            Database.Tables.Remove(tableName);
            _saveData.Databases[Database.Name] = Database;
            SaveData();
        }
    }

    private void SaveData()
    {
        string json = JsonConvert.SerializeObject(_saveData);

        PlayerPrefs.SetString("Save", json);
    }
}