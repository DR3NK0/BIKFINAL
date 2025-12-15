using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public string url = "https://mksafenet.mk/";

    public void OpenURL() => Application.OpenURL(url);
}
