using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Texture Loader Data", menuName="Texture Loader Data")]
public class TextureLoaderData : ScriptableObject
{
    public TexturesToLoad[] texsToLoad;
}

[System.Serializable]
public class TexturesToLoad
{
    public Material matToChange;
    public string texName;
}