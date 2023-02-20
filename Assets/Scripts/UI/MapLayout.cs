using UnityEngine;
using UnityEngine.UI;
namespace SedaCinar.AreaFinder.UI
{
    public class MapLayout : LayoutGroup
    {
        [SerializeField] protected Vector2 m_CellSize = new Vector2(100, 100);

        /// <summary>
        /// The size to use for each cell in the grid.
        /// </summary>
        public Vector2 cellSize { get { return m_CellSize; } set { SetProperty(ref m_CellSize, value); } }

        [SerializeField] protected Vector2 m_Spacing = Vector2.zero;

        /// <summary>
        /// The spacing to use between layout elements in the grid on both axises.
        /// </summary>
        public Vector2 spacing { get { return m_Spacing; } set { SetProperty(ref m_Spacing, value); } }

        public RectTransform Rect
        {
            get { return rectTransform; }
        }

        protected MapLayout()
        { }

        /// <summary>
        /// Called by the layout system to calculate the horizontal layout size.
        /// Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            int minColumns = 1;
            int preferredColumns = Mathf.CeilToInt(Mathf.Sqrt(rectChildren.Count));
            SetLayoutInputForAxis(
                padding.horizontal + (cellSize.x + spacing.x) * minColumns - spacing.x,
                padding.horizontal + (cellSize.x + spacing.x) * preferredColumns - spacing.x,
                -1, 0);
        }

        /// <summary>
        /// Called by the layout system to calculate the vertical layout size.
        /// Also see ILayoutElement
        /// </summary>
        public override void CalculateLayoutInputVertical()
        {
            int minRows = 0;

            float width = rectTransform.rect.width;
            int cellCountX = Mathf.Max(1, Mathf.FloorToInt((width - padding.horizontal + spacing.x + 0.001f) / (cellSize.x + spacing.x)));
            minRows = Mathf.CeilToInt(rectChildren.Count / (float)cellCountX);


            float minSpace = padding.vertical + (cellSize.y + spacing.y) * minRows - spacing.y;
            SetLayoutInputForAxis(minSpace, minSpace, -1, 1);
        }

        /// <summary>
        /// Called by the layout system
        /// Also see ILayoutElement
        /// </summary>
        public override void SetLayoutHorizontal()
        {
            SetCellsAlongAxis(0);
        }

        /// <summary>
        /// Called by the layout system
        /// Also see ILayoutElement
        /// </summary>
        public override void SetLayoutVertical()
        {
            SetCellsAlongAxis(1);
        }

        private void SetCellsAlongAxis(int axis)
        {
            // Normally a Layout Controller should only set horizontal values when invoked for the horizontal axis
            // and only vertical values when invoked for the vertical axis.
            // However, in this case we set both the horizontal and vertical position when invoked for the vertical axis.
            // Since we only set the horizontal position and not the size, it shouldn't affect children's layout,
            // and thus shouldn't break the rule that all horizontal layout must be calculated before all vertical layout.
            var rectChildrenCount = rectChildren.Count;
            if (axis == 0)
            {
                // Only set the sizes when invoked for horizontal axis, not the positions.

                for (int i = 0; i < rectChildrenCount; i++)
                {
                    RectTransform rect = rectChildren[i];

                    m_Tracker.Add(this, rect,
                        DrivenTransformProperties.Anchors |
                        DrivenTransformProperties.AnchoredPosition |
                        DrivenTransformProperties.SizeDelta);

                    rect.anchorMin = Vector2.up;
                    rect.anchorMax = Vector2.up;
                    rect.sizeDelta = cellSize;
                }
                return;
            }

            float width = rectTransform.rect.size.x;
            float height = rectTransform.rect.size.y;

            int cellCountX = 1;
            int cellCountY = 1;

            if (cellSize.x + spacing.x <= 0)
                cellCountX = int.MaxValue;
            else
                cellCountX = Mathf.Max(1, Mathf.FloorToInt((width - padding.horizontal + spacing.x + 0.001f) / (cellSize.x + spacing.x)));

            if (cellSize.y + spacing.y <= 0)
                cellCountY = int.MaxValue;
            else
                cellCountY = Mathf.Max(1, Mathf.FloorToInt((height - padding.vertical + spacing.y + 0.001f) / (cellSize.y + spacing.y)));


            int cornerX = (int)0 % 2;
            int cornerY = (int)0 / 2;

            int cellsPerMainAxis, actualCellCountX, actualCellCountY;

            cellsPerMainAxis = cellCountX;
            actualCellCountX = Mathf.Clamp(cellCountX, 1, rectChildrenCount);
            actualCellCountY = Mathf.Clamp(cellCountY, 1, Mathf.CeilToInt(rectChildrenCount / (float)cellsPerMainAxis));


            Vector2 requiredSpace = new Vector2(
                actualCellCountX * cellSize.x + (actualCellCountX - 1) * spacing.x,
                actualCellCountY * cellSize.y + (actualCellCountY - 1) * spacing.y
            );
            Vector2 startOffset = new Vector2(
                GetStartOffset(0, requiredSpace.x),
                GetStartOffset(1, requiredSpace.y)
            );

            for (int i = 0; i < rectChildrenCount; i++)
            {
                int positionX;
                int positionY;

                positionX = i % cellsPerMainAxis;
                positionY = i / cellsPerMainAxis;

                if (cornerX == 1)
                    positionX = actualCellCountX - 1 - positionX;
                if (cornerY == 1)
                    positionY = actualCellCountY - 1 - positionY;

                SetChildAlongAxis(rectChildren[i], 0, startOffset.x + (cellSize[0] + spacing[0]) * positionX, cellSize[0]);
                SetChildAlongAxis(rectChildren[i], 1, startOffset.y + (cellSize[1] + spacing[1]) * positionY, cellSize[1]);
            }
        }
    }
}