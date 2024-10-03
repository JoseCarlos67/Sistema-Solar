using System;

[Serializable]
public class ConfigModel
{
    public Resolution Resolution { get; set; }
    public bool Vsinc { get; set; }
    public bool WindowMode { get; set; }
}
[Serializable]
public class Resolution
{
    public int width { get; set; }
    public int height { get; set; }
}
