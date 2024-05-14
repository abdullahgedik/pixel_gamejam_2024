using System.Collections;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform projectileParent;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Gun Rotation Settings")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotation;
    [SerializeField] private float maxRotation;

    [Header("Gun Fire Settings")]
    [SerializeField] private float fireForce;
    [SerializeField] private float fireRate;

    [Header("Gun Ammunation Settings")]
    [SerializeField] private float maxAmmo;
    [SerializeField] private float reloadCooldown;

    //Rotation
    private Vector3 currentRotation;
    private float gunRotation;

    //Fire
    private float nextTimeToFire;
    private float shootTime;

    //Projectile
    private GameObject projectile;

    //Ammo
    private float currentAmmo;

    private void Start()
    {
        nextTimeToFire = 1 / fireRate;
        shootTime = 0;
        currentAmmo = maxAmmo;

        currentRotation = transform.localEulerAngles;
        gunRotation = rotationSpeed * Time.deltaTime;
    }

    private void Update()
    {
        shootTime += Time.deltaTime;

        currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);

        transform.localEulerAngles = currentRotation;
    }

    public void RotateRight()
    {
        currentRotation.z += gunRotation;
    }
    public void RotateLeft()
    {
        currentRotation.z -= gunRotation;
    }
    public void Fire()
    {
        if (shootTime >= nextTimeToFire && currentAmmo > 0)
        {
            //Create Projectile and Add Force
            projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * -fireForce, ForceMode2D.Impulse);
            projectile.transform.parent = projectileParent;
            Destroy(projectile, 3f);

            //Decrease Ammo
            currentAmmo--;
            if (currentAmmo <= 0)
            {
                StartCoroutine(ReloadAmmo());
            }

            //Reset Shoot Time
            shootTime = 0;
        }
    }

    private IEnumerator ReloadAmmo()
    {
        yield return new WaitForSeconds(reloadCooldown);
        currentAmmo = maxAmmo;
    }
}
