﻿using System.Collections.ObjectModel;
using Prism.Windows.Mvvm;
using Param_ItemNamespace.Core.Models;
using Param_ItemNamespace.Core.Services;

namespace Param_ItemNamespace.ViewModels
{
    public class DataGridViewViewModel : ViewModelBase
    {
        private readonly ISampleDataService _sampleDataService;

        public DataGridViewViewModel(ISampleDataService sampleDataServiceInstance)
        {
            _sampleDataService = sampleDataServiceInstance;
        }

        public ObservableCollection<SampleOrder> Source => _sampleDataService.GetGridSampleData();
    }
}
