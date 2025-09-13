using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

   void Update() 
   {

    if (Input.GetButtonUp("Fire1"))
    {
        ShootBullet();
    }

   }

   void ShootBullet()
   {
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    Rigidbody rb = bullet.GetComponent<Rigidbody>();

    float bulletImpulse = bulletMaxImpulse;

    rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.impulse);
   }
}
