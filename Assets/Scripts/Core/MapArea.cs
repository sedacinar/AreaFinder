using UnityEngine;
using SedaCinar.AreaFinder.UI;
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
        #endregion
        #region Unity Methods
        void Start () 
        {
            mapLayout = GetComponent<MapLayout>();
            mapCreator = FindObjectOfType<MapCreator>();
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
        void AddElement()
        {
            for(int widthIndex = 0; widthIndex < width; widthIndex++)
            {
                for(int heightIndex = 0; heightIndex < height; heightIndex++)
                {
                    var element = Instantiate(elementPrefab, transform);
                    var mapElement = element.GetComponent<MapElement>();
                    mapElement.Initialize();
                    mapElement.SetLocation(widthIndex, heightIndex);
                }
            }
        }
        #endregion
        #region Public Methods
        public void GenerateMap()
        {
            MapElementSize();
            AddElement();
        }
        #endregion

    }
}
