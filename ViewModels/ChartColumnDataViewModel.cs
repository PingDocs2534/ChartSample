using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Chart.ViewModels
{
    public class ChartColumnDataArray
    {
        public readonly List<ChartColumnData> DataList;

        public ChartColumnDataArray()
        {
            DataList = new List<ChartColumnData>();
        }

        public override string ToString()
        {
            var nameList = new List<string>();

            var columnDatas = new int[DataList.Count, 10];
            var jsonModel = new object[DataList.Count + 1];

            var list = new List<int[]>();
            for (int i = 0; i < DataList.Count; i++)
            {
                var data = DataList[i];

                nameList.Add(data.GetName());
                list.Add(data.GetValue());
            }

            jsonModel[0] = nameList.ToArray();
            for (int i = 1; i < jsonModel.Length; i++)
            {
                jsonModel[i] = list[i - 1];
            }
            
            var jsonArray = JsonConvert.SerializeObject(jsonModel);
            return string.Empty;
        }
    }

    [Serializable]
    public class ChartColumnJsonModel
    {
        public string[] Names;
        public int[,] Values;
    }

    public class ChartColumnData
    {
        private readonly string _name;
        private readonly List<int> _dataList;

        public ChartColumnData(string name, int size)
        {
            _name = name;
            _dataList = new List<int>(new int[size]);
        }

        public void SetData(int index, int value)
        {
            _dataList[index] = value;
        }

        public string GetName()
        {
            return _name;
        }

        public int[] GetValue()
        {
            return _dataList.ToArray();
        }
    }
}