using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCR_Test
{
    public class Sort
    {
        public static void QuickSortFunction(int[] array, int low, int high)
        {
            try
            {
                int keyValuePosition;
                if (low < high)
                {
                    keyValuePosition = keyValuePositionFunction(array, low, high);

                    QuickSortFunction(array, low, keyValuePosition - 1);
                    QuickSortFunction(array, keyValuePosition + 1, high);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int keyValuePositionFunction(int[] array, int low, int high)
        {
            int leftIndex = low;
            int rightIndex = high;

            int keyValue = array[low];
            int temp;

            while (leftIndex < rightIndex)
            {
                while (leftIndex < rightIndex && array[leftIndex] <= keyValue)
                {
                    leftIndex++;
                }
                while (leftIndex < rightIndex && array[rightIndex] > keyValue)
                {
                    rightIndex--;
                }
                if (leftIndex < rightIndex)
                {
                    temp = array[leftIndex];
                    array[leftIndex] = array[rightIndex];
                    array[rightIndex] = temp;
                }
            }


            temp = keyValue;
            if (temp < array[rightIndex])
            {
                array[low] = array[rightIndex - 1];
                array[rightIndex - 1] = temp;
                return rightIndex - 1;
            }
            else
            {
                array[low] = array[rightIndex];
                array[rightIndex] = temp;
                return rightIndex;
            }
        }
    }
}
