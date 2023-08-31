using UnityEngine;

[System.Serializable]
public class Dialogue{
    public actor[] actors;
    public message[] messages;
}

[System.Serializable]
public class actor
{
    public string name;
    public Sprite appearance;
}

[System.Serializable]
public class message
{
    public int id;
    [TextArea(3, 10)]
    public string[] sentences;
}
