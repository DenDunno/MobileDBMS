using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.TableUI;

public class TableResizement : MonoBehaviour
{
    [SerializeField] private TableUI _tableUI;
    [SerializeField] private VerticalLayoutGroup _verticalLayout;

    public void AddRow()
    {
        _tableUI.Rows++;

        TMP_InputField a = _tableUI.GetInputField(_tableUI.Rows - 1, _tableUI.Columns - 1);
        a.text = "Aboba";
        RebuildLayout();
    }
    
    public void RemoveRow()
    {
        _tableUI.Rows--;
        RebuildLayout();
    }
    
    public void AddColumn()
    {
        _tableUI.Columns++;
        RebuildLayout();
    }
    
    public void RemoveColumn()
    {
        _tableUI.Columns--;
        RebuildLayout();
    }

    private void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_verticalLayout.transform as RectTransform);
    }
}