using UnityEngine;
using SedaCinar.AreaFinder.UI;
using SedaCinar.AreaFinder.IO;
using SedaCinar.AreaFinder.Model;

namespace SedaCinar.AreaFinder.Core
{
    public class MapArea : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        GameObject elementPrefab;

        int width;
        int height;
        float elementWidth;
        float elementHeight;

        MapLayout mapLayout;
        MapCreator mapCreator;
        IOManager ioManager;
        #endregion
        #region Unity Methods
        void Awake () 
        {
            mapLayout = GetComponent<MapLayout>();
            mapCreator = FindObjectOfType<MapCreator>();
            ioManager = FindObjectOfType<IOManager>();
            ioManager.BindOnMapLoad(GenerateMap);
        }
        #endregion
        #region Private Methods
        void MapElementSize()
        {
            mapCreator.GetSize(out width, out height);
            elementWidth  = (mapLayout.Rect.rect.width - ((width - 1) * mapLayout.spacing.x))  / (width);
            elementHeight = (mapLayout.Rect.rect.height - ((height - 1) * mapLayout.spacing.y)) / (height);
            mapLayout.cellSize = new Vector2(elementWidth, elementHeight);
        }
        void AddNewElement()
        {
            mapCreator.ResetContent();
            for(int widthIndex = 0; widthIndex < width; widthIndex++)
            {
                for(int heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    var element = Instantiate(elementPrefab, transform);
                    var mapElement = element.GetComponent<MapElement>();
                    mapElement.Initialize();
                    mapElement.SetLocation(heightIndex, widthIndex);
                    mapCreator.AddElement(mapElement.GetContent());
                }
            }
            mapCreator.SetSize(width, height);
        }
        void AddLoadElement(MapContent mapContent)
        {
            for (int widthIndex = 0; widthIndex < mapContent.Width; widthIndex++)
            {
                for (int heightIndex = 0; heightIndex < mapContent.Height; heightIndex++)
                {
                    var element = Instantiate(elementPrefab, transform);
                    var mapElement = element.GetComponent<MapElement>();
                    mapElement.Initialize();
                    mapElement.SetLocation(heightIndex, widthIndex);
                    var content = mapContent.Elements.Find(x => x.Column == widthIndex && x.Row == heightIndex);
                    if(content.IsBorder)
                    {
                        mapElement.SetBorder();
                    }
                }
            }
        }
        void Clear()
        {
            var elements = GetComponentsInChildren<MapElement>();
            for (int i = 0; i < elements.Length; i++)
            {
                Destroy(elements[i].gameObject);
            }
        }
        #endregion
        #region Public Methods
        public void RedrawMap()
        {
            Clear();
            MapElementSize();
            AddNewElement();
        }
        public void GenerateMap(MapContent mapContent)
        {
            MapElementSize();
            AddLoadElement(mapContent);
        }
        #endregion

    }
}
