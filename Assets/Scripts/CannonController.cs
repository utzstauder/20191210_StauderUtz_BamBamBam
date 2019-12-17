using UnityEngine;

public class CannonController : MonoBehaviour
{
    public BulletPool bulletPool;
    public Transform cannonTransform;

    public int bulletLayerId;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newBullet = bulletPool.GetObjectFromPool();
        newBullet.transform.SetPositionAndRotation(cannonTransform.position, cannonTransform.rotation);

        // change bullet layer
        // TODO: optimize
        Collider[] colliders = newBullet.GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.layer = bulletLayerId;
        }

        newBullet.SetActive(true);

        // TODO: apply ship velocity to bullet?
    }
}
