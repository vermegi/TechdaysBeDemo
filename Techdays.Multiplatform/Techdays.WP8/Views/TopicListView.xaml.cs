using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Techdays.Core.ViewModels.Sessions;

namespace Techdays.WP8.Views
{
    public partial class TopicListView : BaseTopicListView
    {
        public TopicListView()
        {
            InitializeComponent();
        }
    }

    public class BaseTopicListView : MvxPhonePage<TopicListViewModel>
    {
        
    }
}