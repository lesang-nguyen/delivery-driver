using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32( 1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32( 1,1,1,1);

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collistion something");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && !hasPackage) {
            Debug.Log("Trigger Package");   
            Destroy(other.gameObject, destroyDelay);
            hasPackage = true;

            spriteRenderer.color = hasPackageColor;
        }
        if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Trigger Customer");
            hasPackage = false;
             spriteRenderer.color = noPackageColor;
        }
    }
}
