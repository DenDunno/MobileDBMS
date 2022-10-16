using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class Cell : MonoBehaviour
{
    private TableUI _tableUI;
    private TableValidation _tableValidation;
    private int _column;
    
    public void Init(int column, TableUI tableUI, TableValidation tableValidation)
    {
        _column = column;
        _tableUI = tableUI;
        _tableValidation = tableValidation;
    }

    public void OnEndEdit(string input)
    {
        if (_column == 0)
            return;
        
        var regex = new Regex("{.*}");
        TMP_InputField temp = _tableUI.GetInputField(0, _column); 
        Match match = regex.Match(temp.text);
        string type = match.Value.Substring(1, match.Value.Length - 2);
        
        _tableValidation.Validate(type, input);
    }
}