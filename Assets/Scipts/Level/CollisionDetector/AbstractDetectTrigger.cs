using UnityEngine;

/// <summary>
/// Responsible for detects collision with a object and does something.
/// </summary>
public abstract class AbstractDetectTrigger : MonoBehaviour
{
    [SerializeField]
    protected string collisionTagName;// Used to identify the tag of object in the (OnTriggerEnter2D).

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(collisionTagName))
        {
            Execute(collision.gameObject);
        }
    }
    protected abstract void Execute(UnityEngine.GameObject collisionObject);
}
