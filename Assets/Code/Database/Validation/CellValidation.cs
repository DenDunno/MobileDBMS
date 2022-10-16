using System;
using System.Collections.Generic;

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

    public void TrySaveValue(object value, string column)
    {
        IValidation validation = _validations[column];

        if (value.ToString() == string.Empty)
            return;
        
        try
        {
            validation.Apply(value);
        }
        catch (Exception exception)
        {
            ErrorPanel.Instance.ShowError(exception.Message);
        }
    }
}