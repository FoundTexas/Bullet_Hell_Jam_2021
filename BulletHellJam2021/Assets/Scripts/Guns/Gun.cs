using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public CameraShake cameraShake;
    public ParticleSystem shootParticle;
    public Animator weaponAnim;
    private bool isReloading = false;
    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime = 3f;
    public Animator RifleAnim;
    public Animator ShotgunAnim;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float startGunTimer = 1f;
    private float gunTimer;
    string currentGunName;

    void Start() {
        gunTimer = 0f;
        currentGunName = gameObject.name.Substring(0, name.IndexOf("_"));
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload(currentGunName));
        }

        if(isReloading) {
            return;
        }

        if(currentAmmo <= 0) {
            StartCoroutine(Reload(currentGunName));
            return;
        }

        gunTimer -= Time.deltaTime;
        
        if(Input.GetButtonDown("Fire1") && gunTimer <= 0) {
            cameraShake.ShakeCamera(2.8f, .1f);
            Shoot(currentGunName);
            gunTimer = startGunTimer;
        }
    }

    void Shoot(string gunName) {
        currentAmmo--;

        if(gunName == "Rifle") {
            RifleAnim.SetTrigger("Shoot");
            Instantiate(shootParticle, firePoint.position, firePoint.rotation);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<SoundManager>().Play("AKShot");
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(-120f, 120f), 0f));
        }

        if(gunName == "Shotgun") {
            ShotgunAnim.SetTrigger("Shoot");
            FindObjectOfType<SoundManager>().Play("ShotgunShot");
            Instantiate(shootParticle, firePoint.position, firePoint.rotation);
            for( int i = 0; i <= 4; i++) {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

                switch(i) {
                    case 0:
                        bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(-150f, -120f), 0f));
                        break;
                    case 1:
                        bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(-120f, -90f), 0f));
                        break;
                    case 2:
                        bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(-50f, 50f), 0f));
                        break;
                    case 3:
                        bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(90f, 120f), 0f));
                        break;
                    case 4:
                        bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(120f, 150f), 0f));
                        break;
                }

            }
        }
    }

    IEnumerator Reload(string gun) {
        isReloading = true;
        if(gun == "Rifle"){
            FindObjectOfType<SoundManager>().Play("AKReload");
        } else if(gun == "Shotgun") {
            FindObjectOfType<SoundManager>().Play("ShotgunReload");
        }

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void OnEnable() {
        isReloading = false;
    }
}
