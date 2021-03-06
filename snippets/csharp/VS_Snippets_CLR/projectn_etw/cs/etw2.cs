﻿using System.Diagnostics.Tracing;

// <Snippet2>
using System;
using Windows.ApplicationModel;
using Windows.UI.Xaml; 

public sealed partial class App
{
    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;
        AppEventSource.Log.AppInitialized();
    }
} 
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        AppEventSource.Log.MainPageInitialized();
    }
}
// </Snippet2>


public class Page 
{
   public void InitializeComponent() {}       
       
}

public sealed partial class App : Application 
{
   public void InitializeComponent() {}

   public void OnSuspending(object sender, SuspendingEventArgs e) { }
}

// Extra stuff

[EventSource(Name="MyCompany-MyApp")]
public sealed class AppEventSource : EventSource
{
   public static AppEventSource Log = new AppEventSource ();

  // The numbers passed to WriteEvent and EventAttribute
  // must increment with each logging method.  
  [Event(1)]
  public void AppInitialized() { WriteEvent(1); }
  
  [Event(2)]
  public void MainPageInitialized() { WriteEvent(2); }
}



