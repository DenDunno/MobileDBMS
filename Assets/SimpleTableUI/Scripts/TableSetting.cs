using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class TableSetting : MonoBehaviour
{
    [SerializeField] private TableUI _tableUI;
    private Table _table;
    
    public void ReadTable()
    {
        _table.Data.Clear();
        _table.Fields.Clear();

        for (int i = 1; i < _tableUI.Columns; ++i)
        {
            _table.Fields.Add(_tableUI.GetInputField(0, i).text);
        }
        
        for (int i = 1; i < _tableUI.Rows; ++i)
        {
            var temp = new List<string>();
            
            for (int j = 1; j < _tableUI.Columns; ++j)
            {
                temp.Add(_tableUI.GetInputField(i, j).text);
            }
            
            _table.Data.Add(temp);
        }
    }
    
    public void SetUpTable(Table table)
    {
        _table = table;
        ResizeTable(table);
        FillTableWithValues(table);
        FillFields(table);
    }

    private void ResizeTable(Table table)
    {
        _tableUI.Columns = table.Fields.Count + 1;
        _tableUI.Rows = table.Data.Count + 1;
    }

    private void FillTableWithValues(Table table)
    {
        for (int i = 1; i < _tableUI.Rows; ++i)
        {
            for (int j = 1; j < _tableUI.Columns; ++j)
            {
                TMP_InputField inputField = _tableUI.GetInputField(i, j);
                inputField.text = table.Data[i - 1][j - 1];
            }
        }
    }

    private void FillFields(Table table)
    {
        for (int i = 1; i < _tableUI.Columns; ++i)
        {
            _tableUI.GetInputField(0, i).text = table.Fields[i - 1];
        }
    }
}