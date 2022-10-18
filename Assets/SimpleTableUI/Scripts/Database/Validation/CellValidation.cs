using System;
using System.Collections.Generic;
using TMPro;

public class CellValidation
{
    private readonly Dictionary<string, IValidation> _validations = new Dictionary<string, IValidation>()
    {
        {DatabaseTypesName.STRING, new StringValidation()},
        {DatabaseTypesName.INT, new IntValidation()},
        {DatabaseTypesName.CHAR, new CharValidation()},
        {DatabaseTypesName.REAL, new RealValidation()},
        {DatabaseTypesName.COLOR, new ColorValidation()},
        {DatabaseTypesName.DATE, new DateValidation()},
    };

    public void TrySaveValue(TMP_InputField inputField, string column)
    {
        IValidation validation = _validations[column];

        if (inputField.text == string.Empty)
            return;
        
        try
        {
            validation.Apply(inputField.text);
        }
        catch (Exception exception)
        {
            inputField.text = string.Empty;
            ErrorPanel.Instance.ShowError(exception.Message);
        }
    }
}