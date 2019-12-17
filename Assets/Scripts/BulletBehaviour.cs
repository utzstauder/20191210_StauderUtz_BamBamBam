using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;
    Collider[] colliders;

    public int damageAmount = 1;

    public float initialVelocity = 10f;
    public float lifeTime = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        colliders = GetComponentsInChildren<Collider>();

        // Quatsch
        for (int i = 0; i < 10000; i++)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<SpaceshipController>();
            float distance = Vector3.Distance(Camera.main.transform.position, player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damageReceiver = collision.gameObject.GetComponentInParent<IDamagable>();

        if (damageReceiver != null)
        {
            damageReceiver.DoDamage(damageAmount);
        }

        DisableSelf();
    }
    
    public void Fire(Vector3 inheritedVelocity, int layerId)
    {
        rb.velocity = inheritedVelocity + transform.forward * initialVelocity;

        // change bullet layer
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.layer = layerId;
        }

        Invoke("DisableSelf", lifeTime);
    }

    void DisableSelf()
    {
        CancelInvoke("DisableSelf");
        gameObject.SetActive(false);
    }
}
