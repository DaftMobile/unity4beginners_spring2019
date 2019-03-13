using UnityEngine;


    public class CorutinSingleton :MonoBehaviour
    {
        public static CorutinSingleton instance;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

    }
