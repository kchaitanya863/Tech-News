using System;
using System.Windows;
using System.Windows.Input;

using AppStudio.Services;

namespace AppStudio.Data
{
    public class MicrosoftViewModel : ViewModelBase<RssSchema>
    {
        override protected string CacheKey
        {
            get { return "MicrosoftDataSource"; }
        }

        override protected IDataSource<RssSchema> CreateDataSource()
        {
            return new MicrosoftDataSource(); // RssDataSource
        }

        override public bool IsPinToStartVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }

        override public void PinToStart()
        {
            base.PinToStart("MicrosoftDetail", "{Title}", "{Summary}", "{ImageUrl}");
        }

        override public bool IsShareItemVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void ShareItem()
        {
            base.ShareItem("{Title}", "{Summary}", "{FeedUrl}", "{ImageUrl}");
        }

        override public bool IsSpeakTextVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void SpeakText()
        {
            base.SpeakText("Content");
        }

        override public bool IsGoToSourceVisible
        {
            get { return ViewType == ViewTypes.Detail; }
        }
        
        override public void GoToSource()
        {
            base.GoToSource("{FeedUrl}");
        }

        override public bool IsRefreshVisible
        {
            get { return ViewType == ViewTypes.List; }
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("MicrosoftDetail");
        }
    }
}
