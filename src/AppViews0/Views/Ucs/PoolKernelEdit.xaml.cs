﻿using NTMiner.Vms;
using System.Windows.Controls;

namespace NTMiner.Views.Ucs {
    public partial class PoolKernelEdit : UserControl {
        public static void ShowWindow(FormType formType, PoolKernelViewModel source) {
            ContainerWindow.ShowWindow(new ContainerWindowViewModel {
                Title = "矿池级参数",
                FormType = formType,
                Width = 550,
                IsMaskTheParent = true,
                IconName = "Icon_Kernel",
                CloseVisible = System.Windows.Visibility.Visible
            }, ucFactory: (window) =>
            {
                PoolKernelViewModel vm = new PoolKernelViewModel(source);
                window.AddCloseWindowOnecePath(vm.Id);
                return new PoolKernelEdit(vm);
            }, fixedSize: true);
        }

        public PoolKernelEdit(PoolKernelViewModel vm) {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
