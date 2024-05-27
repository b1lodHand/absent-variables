using System.Linq;
using UnityEngine;

namespace com.absence.variablesystem.Editor
{
    public static class Helpers
    {
        /// <summary>
        /// Use to slice a rect with specified parameters.
        /// </summary>
        /// <param name="rect">The original rect.</param>
        /// <param name="pieceCount">Count of the pieces.</param>
        /// <param name="overrideSpacing"></param>
        /// <param name="overridePadding"></param>
        /// <param name="pieceSizeCoefficients">Size coefficients for each piece (automatically assings 1f to every piece when null).</param>
        /// <returns></returns>
        public static Rect[] SliceRectHorizontally(Rect rect, int pieceCount, float overrideSpacing = Constants.K_SPACING, float overridePadding = Constants.K_PADDING, params float[] pieceSizeCoefficients)
        {
            if (pieceCount <= 0) return null;

            if (pieceSizeCoefficients == null)
            {
                pieceSizeCoefficients = new float[pieceCount];
                for (int i = 0; i < pieceCount; i++)
                {
                    pieceSizeCoefficients[i] = 1f;
                }
            }

            Rect[] result = new Rect[pieceCount];

            float totalWidth = rect.width - ((2 * overridePadding) + ((pieceCount - 1) * overrideSpacing));
            float generalCoefficient = totalWidth / pieceSizeCoefficients.Sum();

            float horizontalPointer = rect.x + overridePadding;
            for (int i = 0; i < pieceCount; i++)
            {
                float currentSize = generalCoefficient * pieceSizeCoefficients[i];

                Rect current = new Rect(horizontalPointer, rect.y, currentSize, rect.height);
                result[i] = current;

                horizontalPointer += currentSize;
                horizontalPointer += overrideSpacing;
            }

            return result;
        }
    }
}
