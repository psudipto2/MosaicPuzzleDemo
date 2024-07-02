//Importing necessary namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Declaring the class for the pooling mechanism
public class ObjectPooler : MonoBehaviour
{
    GameObject m_objectPrefab; //Reference of the object to be instantiated 
    int m_initialPoolSize; //Integer to indicate an initial size for the pool
    Transform m_parentTransform; //Reference to the transform of the object which will store the pooled objects
    List<GameObject> m_objectPool; //A list which will store the reference to all the pooled objects

    /// <summary>
    /// Constructor to initialize the member variables, whenever an instance of the class is created
    /// </summary>
    /// <param name="objectPrefab"></param>
    /// <param name="initialPoolSize"></param>
    /// <param name="parentTransform"></param>

    public ObjectPooler(GameObject objectPrefab, int initialPoolSize, Transform parentTransform)
    {
        m_objectPrefab = objectPrefab;
        m_initialPoolSize = initialPoolSize;
        m_parentTransform = parentTransform;
        m_objectPool = new List<GameObject>();
        CreatePool(); //Call the method to create the pool
    }

    /// <summary>
    /// This method will actually create the pool
    /// </summary>

    void CreatePool()
    {
        /// Creating a local variable and using it to store the reference of a newly instantiated game object, temporarily before it goes to the pool 
        /// in order to avoid garbage collection
        GameObject gameObject;

        //Looping to instantiate a new object, then deactivating it and adding it to the pool
        for (int i = 0; i < m_initialPoolSize; i++)
        {
            gameObject = Instantiate(m_objectPrefab, m_parentTransform);
            gameObject.SetActive(false);
            m_objectPool.Add(gameObject);

            //Resetting the variable before using it in the next iteration
            gameObject = null;
        }
    }

    /// <summary>
    /// This method will fetch an inactive object from the pool and return it so that it can be used
    /// If no objects are available in the pool, then it'll create a new object, add it to the pool and return it
    /// </summary>
    /// <returns></returns>

    public GameObject GetObjectFromPool()
    {
        //Caching some variables to avoid garbage collection
        GameObject pooledObject;
        int poolSize = m_objectPool.Count;

        //Looping through the pool and looking for an inactive object, then returning it if found
        for (int i = 0; i < poolSize; i++)
        {
            pooledObject = m_objectPool[i];

            if (!pooledObject.activeInHierarchy)
            {
                pooledObject.SetActive(true);
                return pooledObject;
            }
            pooledObject = null;
        }

        //No active objects found in the pool, creating a new one
        pooledObject = Instantiate(m_objectPrefab, m_parentTransform);
        m_objectPool.Add(pooledObject);
        return pooledObject;
    }

    /// <summary>
    /// This method will deactivate the object after it has fulfilled its purpose and is no longer needed
    /// so that the object could be used again later
    /// </summary>
    /// <param name="gameObject"></param>

    public void ReturnObjectBackToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}