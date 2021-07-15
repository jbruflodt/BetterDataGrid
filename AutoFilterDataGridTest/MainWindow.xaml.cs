﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.ComponentModel;
using Expression.Blend.SampleData.SampleDataSource;
using AutoFilterDataGrid.Interfaces;

namespace AutoFilterDataGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DataTable testTable;
        private int testInt;
        public DataTable TestTable
        {
            get
            {
                return testTable;
            }
        }
        public MainWindow()
        {
            Random random = new Random();
            testTable = new DataTable();
            TestDataGridColumn testColumn = new TestDataGridColumn();
            testColumn.Binding = new Binding("Property1");
            testTable.Columns.Add("Property1");
            testTable.Columns.Add("Property2");
            testTable.Columns.Add("Property3", typeof(int));
            SampleDataSource testData = new SampleDataSource();
            for(int x = 0; x < 10000; x++)
            {
                int recordNum = random.Next(0, testData.Collection.Count - 1);
                testTable.LoadDataRow(new object[] { testData.Collection[recordNum].Property1, testData.Collection[recordNum].Property2, x }, true);
            }
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AutoFilterDataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //autoFilterDataGrid.InvalidateVisual();
        }

        private void AutoFilterDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //if (testInt <= 0)
            //{
            //    testInt++;
            //    grid.Children.Remove(autoFilterDataGrid);
            //    grid.Children.Add(autoFilterDataGrid);
                
            //}
        }
    }
    public class TestDataGridColumn : DataGridTextColumn, IBindableColumn
    {
        Binding IBindableColumn.Binding { get => this.Binding as Binding; set =>  Binding = value; }
    }
}
