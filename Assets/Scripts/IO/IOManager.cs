using System;
using System.IO;
using UnityEngine;
using SedaCinar.AreaFinder.Core;
using SedaCinar.AreaFinder.Model;
namespace SedaCinar.AreaFinder.IO
{
    public class IOManager : MonoBehaviour
    {
        #region Events
        public delegate void MapLoadEventHandler(MapContent loadedMap);
        event MapLoadEventHandler mapOnLoad;
        #endregion
        #region Fields
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        [SerializeField, Tooltip("Name of the dashboard. It is also used while saving the dashboard layout.")]
        private string _name = "Default";
        MapCreator mapCreator;
        FileManager fileManager;
        NewtonsoftSerializer serializer;
       
        #endregion
        #region Unity Methods
        private void Start()
        {
            fileManager = new FileManager();
            serializer = new NewtonsoftSerializer();
            mapCreator = FindObjectOfType<MapCreator>();
            Load();
        }
        #endregion
        #region Public Methods
        public void Save()
        {
            string fileName = $"Map_{Name}.json";
            string path = Path.Combine(Application.dataPath, "Resources/Map", fileName);
            MapContent mapContent = new MapContent();
            mapCreator.GetContent(out mapContent);
            string serializedContent = serializer.Serialize(mapContent);
            bool result = fileManager.Save(path, serializedContent);

            if (result)
                Debug.Log($"Saving the map {Name} is successful");
            else
                Debug.LogWarning($"Saving the map {Name} has failed!");
        }
        public void Load() 
        {
            string fileName = $"Map_{Name}.json";
            string path = Path.Combine(Application.dataPath, "Resources/Map", fileName);

            try
            {
                string serializedContent = fileManager.Load(path);

                if (string.IsNullOrEmpty(serializedContent))
                {
                    Debug.LogWarning($"Map {Name} has not been saved previously.");
                    return;
                }

                MapContent mapContent = serializer.Deserialize<MapContent>(serializedContent);
                mapCreator.SetContent(mapContent);
                mapOnLoad?.Invoke(mapContent);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Map load has failed. Reason: {ex.ToString()}");
            }
        }
        public void BindOnMapLoad(MapLoadEventHandler mapOnLoad)
        {
            if(mapOnLoad != null ) 
            {
                this.mapOnLoad += mapOnLoad;
            }
        }
        public void UnBindOnMapLoad(MapLoadEventHandler mapOnLoad)
        {
            if (this.mapOnLoad == null || mapOnLoad == null)
                return;

            this.mapOnLoad -= mapOnLoad;
        }
        #endregion
    }
}