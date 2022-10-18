using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public Dictionary<string, Database> Databases { get; set; } = new Dictionary<string, Database>();
}