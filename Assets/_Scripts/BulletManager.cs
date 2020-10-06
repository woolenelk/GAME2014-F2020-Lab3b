using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int maxBullets;

    private Queue<GameObject> m_bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        _buildBulletPool();
    }

    // Update is called once per frame


    private void _buildBulletPool()
    {
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count ++)
        {
            Debug.Log("bullet made");
            var tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = gameObject.transform;
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject getBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void AddBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        m_bulletPool.Enqueue(bullet);
    }

}
