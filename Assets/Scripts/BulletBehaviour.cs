using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletBehaviour : MonoBehaviour
{
    Rigidbody rb;

    public int damageAmount = 1;

    public float initialSpeed = 10f;
    public float lifeTime = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Quatsch
        for (int i = 0; i < 10000; i++)
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<SpaceshipController>();
            float distance = Vector3.Distance(Camera.main.transform.position, player.transform.position);
        }
    }

    private void OnEnable()
    {
        rb.velocity = transform.forward * initialSpeed;

        Invoke("DisableSelf", lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damageReceiver = collision.gameObject.GetComponent<IDamagable>();

        if (damageReceiver != null)
        {
            damageReceiver.DoDamage(damageAmount);
        }

        DisableSelf();
    }

    void DisableSelf()
    {
        CancelInvoke("DisableSelf");
        gameObject.SetActive(false);
    }
}
