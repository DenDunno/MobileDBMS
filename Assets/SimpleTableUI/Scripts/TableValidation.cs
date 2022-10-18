using TMPro;
using UnityEngine;

public class TableValidation : MonoBehaviour
{
    private readonly CellValidation _cellValidation = new CellValidation();
    
    public void Validate(TMP_InputField inputField, string type)
    {
        _cellValidation.TrySaveValue(inputField, type);
    }
}