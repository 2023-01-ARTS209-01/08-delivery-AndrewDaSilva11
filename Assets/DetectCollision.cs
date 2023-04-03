using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
private bool hasPackage = false;

 SpriteRenderer spriteRenderer;
[SerializeField] Color hasPackageColor;
[SerializeField] Color doesNotHavePackageColor;

private void Start()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
}
    
private void OnCollisionEnter2D(Collision2D collision)
{

Debug.Log("We hit something! - " + collision.gameObject.name);

}

private void OnTriggerEnter2D(Collider2D trigger)
{
    //Debug.Log("We went though a TRIGGER! - " + trigger.gameObject.name);

    if (trigger.gameObject.CompareTag("Package") && !hasPackage)
    {
        Debug.Log("Picked up package!");
        hasPackage = true;
        spriteRenderer.color = hasPackageColor;
        Destroy (trigger.gameObject, 0.5f);
    }
    if (trigger.gameObject.CompareTag("Customer") && hasPackage)
    {
     Debug.Log("Delivered the package!!");
     spriteRenderer.color = doesNotHavePackageColor;
     hasPackage = false;
    }
}

}
