using System;
using System.Collections.Generic;

[Serializable]
public class Table
{
    public string Name { get; set; } = string.Empty;
    public List<string> Fields { get; set; } = new List<string>();
    public List<List<string>> Data { get; set; } = new List<List<string>>();
}