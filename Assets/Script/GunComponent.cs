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

    if (Input.GetButtonDown("Fire1")) {
        isCharging = true;
        chargeTime = 0f;
    }
    
    if (Input.GetButton("Fire1") && isCharging) {
        chargeTime += Time.deltaTime;
        chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
    }

    if (Input.GetButtonUp("Fire1") && isCharging) {
        ShootBullet();
        isCharging = false;
        chargeTime = 0f;
    }

   }

   void ShootBullet()
{
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
       
        // Scale bullet force based on charge time
        float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }

}
