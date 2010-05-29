using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Windows.Forms;
using System.Collections;

namespace DataMining
{
    //один рядок таблиці, воно ж об*єкт
    class Point<T> where T : class
    {
        Dictionary<string, double?> propertyCollection;

        public Point(T item)
        {
            InitializePoint();
            Dictionary<string, double?> cloneDictionary = new Dictionary<string, double?>(propertyCollection);//шоб мона було змінювати propertyCollection
            foreach (string key in cloneDictionary.Keys)
            {
                propertyCollection[key] = (double)(typeof(T).GetProperty(key).GetValue(item, null));
            }
        }

        public Point()
        {
            InitializePoint();
        }

        void InitializePoint()
        {
            propertyCollection = new Dictionary<string, double?>();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
            {
                object[] attributes = propertyInfo.GetCustomAttributes(false);
                foreach (object attribute in attributes)
                {
                    if (attribute is ColumnAttribute)
                    {
                        if ((attribute as ColumnAttribute).IsPrimaryKey != true)
                        {
                            propertyCollection.Add(propertyInfo.Name, null);
                        }
                    }
                }
            }
        }

        public Dictionary<string, double?> PropertyCollection
        {
            get
            {
                return propertyCollection;
            }
        }

        public static Point<T> GetMassCenter(List<Point<T>> pointCollection)
        {
            Point<T> result = new Point<T>();
            Dictionary<string, double?> cloneDictionary = new Dictionary<string, double?>(result.propertyCollection);//шоб мона було змінювати propertyCollection
            foreach (string key in cloneDictionary.Keys)
            {
                result.propertyCollection[key] = 0;
                foreach (Point<T> point in pointCollection)
                {
                    result.propertyCollection[key] += point.propertyCollection[key];
                }
                result.propertyCollection[key] /= pointCollection.Count;
            }

            return result;
        }

        //Euclid distance
        public static double Distance(Point<T> point1, Point<T> point2)
        {
            double result = 0;
            foreach (string key in point1.propertyCollection.Keys)
            {
                result += Math.Pow((double)point1.propertyCollection[key] - (double)point2.propertyCollection[key], 2);
            }

            return Math.Sqrt(result);
        }
    }

    //cluster
    class Cluster<T> : IEnumerable where T : class
    {
        List<Point<T>> pointCollection;
        public Point<T> massCenter;

        public Cluster()
        {
            pointCollection = new List<Point<T>>();
        }

        public int Length
        {
            get
            {
                return pointCollection.Count;
            }
        }
        public Point<T> this[int index]
        {
            get
            {
                return pointCollection[index];
            }
        }

        public void AddPoint(Point<T> point)
        {
            pointCollection.Add(point);
        }

        public void RemovePoint(Point<T> point)
        {
            pointCollection.Remove(point);
        }

        public void RecalculateMassCenter()
        {
            massCenter = Point<T>.GetMassCenter(pointCollection);
        }

        public static double Distance(Point<T> point, Cluster<T> cluster)
        {
            return Point<T>.Distance(point, cluster.massCenter);
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return pointCollection.GetEnumerator();
        }

        #endregion
    }

    //главний клас, який мутить алгоритм
    public class KMeans<T> where T : class
    {
        List<Cluster<T>> clusterCollection;
        float precision;

        public KMeans(List<T> pointCollection, int clusterCount, float precision)
        {
            this.clusterCollection = new List<Cluster<T>>();
            this.precision = precision;
            for (int i = 0; i < clusterCount; i++)
            {
                clusterCollection.Add(new Cluster<T>());
                clusterCollection.Last().AddPoint(new Point<T>(pointCollection[i]));
            }
            for (int i = clusterCount; i < pointCollection.Count(); i++)
            {
                clusterCollection.Last().AddPoint(new Point<T>(pointCollection[i]));
            }
            RecalculateMassCenters();
        }

        void RecalculateMassCenters()
        {
            foreach (Cluster<T> cluster in clusterCollection)
            {
                cluster.RecalculateMassCenter();
            }
        }

        public void NextStep()
        {
            //relocate point in clusters
            for (int i = 0; i < clusterCollection.Count; i++)
            {
                for (int j = 0; j < clusterCollection[i].Length; )
                {
                    if (clusterCollection[i].Length > 1)
                    {
                        Cluster<T> minDistanceCluster = clusterCollection[i];
                        for (int k = 0; k < clusterCollection.Count; k++)
                        {
                            if (Cluster<T>.Distance(clusterCollection[i][j], clusterCollection[k]) < Cluster<T>.Distance(clusterCollection[i][j], minDistanceCluster))
                            {
                                minDistanceCluster = clusterCollection[k];
                            }
                        }
                        if (Cluster<T>.Distance(clusterCollection[i][j], minDistanceCluster) < Cluster<T>.Distance(clusterCollection[i][j], clusterCollection[i]))
                        {
                            minDistanceCluster.AddPoint(clusterCollection[i][j]);
                            clusterCollection[i].RemovePoint(clusterCollection[i][j]);
                            continue;
                        }
                    }
                    j++;
                }
            }

            //recalculate centre of mass
            RecalculateMassCenters();
        }

        public void WriteToDataGridView(DataGridView view)
        {
            view.Columns.Clear();
            foreach (string key in new Point<T>().PropertyCollection.Keys)
            {
                view.Columns.Add(key, key);
                view.Columns[view.Columns.Count - 1].Width = 70;
            }
            view.Columns.Add("Cluster", "Cluster");
            view.Columns[view.Columns.Count - 1].Width = 80;

            for (int i = 0; i < clusterCollection.Count; i++)
            {
                foreach (Point<T> point in clusterCollection[i])
                {
                    List<object> row = new List<object>();
                    foreach (string key in point.PropertyCollection.Keys)
                    {
                        row.Add(point.PropertyCollection[key]);
                    }
                    row.Add(i);
                    view.Rows.Add(row.ToArray());
                }
                List<object> row2 = new List<object>();
                foreach (string key in clusterCollection[i].massCenter.PropertyCollection.Keys)
                {
                    row2.Add(clusterCollection[i].massCenter.PropertyCollection[key]);
                }
                row2.Add("Centre Mass");
                view.Rows.Add(row2.ToArray());
            }
        }
    }
}