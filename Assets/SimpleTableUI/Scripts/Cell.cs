using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class Cell : MonoBehaviour
{
    private TableUI _tableUI;
    private TableValidation _tableValidation;
    private int _column;
    private int _row;
    
    public void Init(int column, int row, TableUI tableUI, TableValidation tableValidation)
    {
        _column = column;
        _row = row;
        _tableUI = tableUI;
        _tableValidation = tableValidation;
    }

    public void OnEndEdit(string input)
    {
        if (_column == 0)
            return;
        
        var regex = new Regex("{.*}");
        TMP_InputField inputField = _tableUI.GetInputField(0, _column); 
        Match match = regex.Match(inputField.text);

        string type = match.Value.Substring(1, match.Value.Length - 2);
        
        _tableValidation.Validate(_tableUI.GetInputField(_row, _column), type);
    }
}