using TMPro;
using UnityEngine;
using UnityEngine.UI.TableUI;

public class ColumnAddingPanel : Panel
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TableUI _tableUI;
    [SerializeField] private UI _ui;
    [SerializeField] private TMP_Dropdown _dropdown;
    
    public void TryAccept()
    {
        if (_inputField.text == string.Empty)
        {
            ErrorPanel.Instance.ShowError("Column name cannot be empty");
        }
        else
        {
            AddColumn();
            _inputField.text = string.Empty;
            _ui.ShowPanel<TablePanel>();
        }
    }

    private void AddColumn()
    {
        _tableUI.Columns++;
        TMP_InputField inputField = _tableUI.GetInputField(0, _tableUI.Columns - 1);
        inputField.text = _inputField.text + " {" + _dropdown.options[_dropdown.value].text + "}";
    }
}