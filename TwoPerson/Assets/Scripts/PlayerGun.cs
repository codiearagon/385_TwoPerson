using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float cooldown = 0.2f;
    private float fireRate = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time > cooldown)
        {
            Shoot();
            cooldown = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Vector2 targetDir = MouseToWorld() - transform.position;
        float bulletAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        Quaternion bulletRot = Quaternion.Euler(0, 0, bulletAngle - 90);
        GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletRot);
    }

    Vector3 MouseToWorld()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
