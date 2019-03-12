using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ItemFuncionality script. Destroys the items after beind spawned.
/// </summary>
public class ItemFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAfterSeconds(3));
    }

    IEnumerator DestroyAfterSeconds(float s)
    {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }
}
