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
        _tableUI.ScaleRow(_tableUI.Rows - 1);
        RebuildLayout();
    }
    
    public void RemoveRow()
    {
        _tableUI.Rows--;
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