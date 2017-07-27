using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCR_Test
{

    public class Duplicate
    {
        public static Dictionary<String, SetInfo> formalSetDic;
        public static Dictionary<String, SetInfo> invalidSetDic;
        public Duplicate()
        {
            formalSetDic = new Dictionary<string, SetInfo>();
            invalidSetDic = new Dictionary<string, SetInfo>();
        }

        // a)
        public bool CheckIfDuplicate1(string target)
        {
            bool bduplicate = false;

            //check contains non number

            if (target.Length != 0)
            {
                foreach (char c in target)
                {
                    if (!char.IsNumber(c) && c != ',')
                    {
                        return searchInDic(target, false);
                    }
                }
                if ((target[0] == ',') || (target[target.Length - 1] == ','))
                {
                    return searchInDic(target, false);
                }
            }
            else
            {
                return searchInDic(target, false);
            }

            //check if exist in dic
            if (!target.Contains(",") || target.Length == 0)
            {
                invalidSetDic.Add(target, new SetInfo() { counts = 1 });

            }
            else
            {

                string[] strArr = target.Split(',');
                int[] iArr = new int[strArr.Length];
                for (int i = 0; i < strArr.Length; i++)
                {
                    iArr[i] = int.Parse(strArr[i]);
                }
                //sort them order to find in dic

                Sort.QuickSortFunction(iArr, 0, iArr.Length - 1);
                StringBuilder sbuilder = new StringBuilder();
                for (int i = 0; i < iArr.Length; i++)
                {
                    sbuilder.Append(iArr[i]);
                    sbuilder.Append(',');
                }

                string strKey = sbuilder.ToString();
                strKey = strKey.TrimEnd(',');
                bduplicate = searchInDic(strKey, true);

            }
            return bduplicate;

        }

        public bool searchInDic(string target, bool bValidSet)
        {
            if (bValidSet)
            {
                if (formalSetDic.ContainsKey(target))
                {
                    ++formalSetDic[target].counts;
                    return true;
                }
                else
                {
                    formalSetDic[target] = new SetInfo { counts = 1 };
                    return false;
                }
            }
            else
            {
                if (invalidSetDic.ContainsKey(target))
                {
                    ++invalidSetDic[target].counts;
                }
                else
                {
                    invalidSetDic[target] = new SetInfo { counts = 1 };
                }
                return false;
            }

        }

        //b)
        public int GetDuplicatedorNotDuplicateCounts(bool bdup)
        {
            int rnum = 0;

            return rnum = (from dic in formalSetDic
                           where dic.Value.duplicatable == bdup
                           select dic).Count();

        }
        //c)
        public IEnumerable<string> GetMostFrequetofDuplicateSet()
        {
            IEnumerable<string> duplist = new List<string>();
            int maxCount = (from dic in formalSetDic
                            select dic.Value.counts).Max();
            if (maxCount > 0)
            {
                duplist = (from dic in formalSetDic
                           where dic.Value.counts == maxCount
                           select dic.Key).ToList<string>();
            }
            return duplist;
        }
        //d)
        public IEnumerable<string> GetInvalidInputs()
        {

            IEnumerable<string> invalidInputList = new List<string>();
            if (invalidSetDic.Count != 0)
            {
                invalidInputList = (from dic in invalidSetDic
                                    select dic.Key).ToList<string>();
            }
            return invalidInputList;

        }
    }
}
