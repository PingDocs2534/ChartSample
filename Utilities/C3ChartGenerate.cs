using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Chart.Utilities
{
    public class C3ChartGenerate
    {
        public readonly Dictionary<string, Dictionary<int, int>> _dataColumnList;
        public readonly Dictionary<int, string> _categoryNameList;
        public C3ChartGenerate()
        {
            _dataColumnList = new Dictionary<string, Dictionary<int, int>>();
            _categoryNameList = new Dictionary<int, string>();
        }

        public void AddData(string key, int index, int value)
        {
            if (!_dataColumnList.ContainsKey(key))
            {
                _dataColumnList.Add(key, new Dictionary<int, int>());
            }

            var keyData = _dataColumnList[key];
            if (!keyData.ContainsKey(index))
            {
                keyData.Add(index, 0);
            }

            keyData[index] = value;
        }

        public void AddCategory(int keyIndex, string keyName)
        {
            if (!_categoryNameList.ContainsKey(keyIndex))
            {
                _categoryNameList.Add(keyIndex, keyIndex.ToString());
            }

            _categoryNameList[keyIndex] = keyName;
        }

        public string BuildDataColumnsJsObj()
        {
            var resultArray = new List<string[]>();

            foreach (var columnSet in _dataColumnList)
            {
                var dataOfColumn = new List<string>();
                dataOfColumn.Add(columnSet.Key);

                var maxValue = columnSet.Value.Max(x => x.Key);
                for (int i = 0; i <= maxValue; i++)
                {
                    if (columnSet.Value.ContainsKey(i))
                    {
                        dataOfColumn.Add(columnSet.Value[i].ToString());
                    }
                    else
                    {
                        dataOfColumn.Add("0");
                    }
                }

                resultArray.Add(dataOfColumn.ToArray());
            }

            return JsonConvert.SerializeObject(resultArray.ToArray());
        }

        public string BuildAxisCategoriesJsObj()
        {
            var resultArray = new List<string>();

            foreach (var columnSet in _categoryNameList)
            {
                resultArray.Add(columnSet.Value);
            }

            return JsonConvert.SerializeObject(resultArray.ToArray());
        }
    }
}