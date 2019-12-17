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
        BulletBehaviour newBullet = bulletPool.GetObjectFromPool();
        newBullet.transform.SetPositionAndRotation(cannonTransform.position, cannonTransform.rotation);

        // TODO: apply ship velocity to bullet?
        newBullet.Init(Vector3.zero);

        // change bullet layer
        // TODO: optimize
        Collider[] colliders = newBullet.GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].gameObject.layer = bulletLayerId;
        }

        newBullet.gameObject.SetActive(true);
    }
}
