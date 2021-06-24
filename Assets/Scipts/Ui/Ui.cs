using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This class has useful functions to UI.
/// </summary>
public class Ui : MonoBehaviour
{
    public void ActivateUi(UnityEngine.GameObject Ui)
    {
        Ui.SetActive(true);
    }
    public void DeactivateUi(UnityEngine.GameObject Ui)
    {
        Ui.SetActive(false);
    }
    public void ChangeScene(string Scenename)
    {
        SceneManager.LoadScene(Scenename);
    }

}
