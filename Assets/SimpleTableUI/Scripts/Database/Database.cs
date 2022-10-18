using System;
using System.Collections.Generic;

[Serializable]
public class Database
{
    public string Name { get; set; } = string.Empty;
    public Dictionary<string, Table> Tables { get; set; } = new Dictionary<string, Table>();
}