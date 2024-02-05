using UnityEngine;

public class PlayerBoomTNT : MonoBehaviour
{
    private bool _isBoom;

    public bool Boom()
    {
        return _isBoom;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TNT tnt))
        {
            _isBoom = true;
            //this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TNT tnt))
        {
            _isBoom = false;
        }
    }
}
