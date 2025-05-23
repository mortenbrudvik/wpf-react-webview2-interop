﻿using System.Windows.Threading;
using Common;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace WebView;

public class WebviewHandler
{
    public WebviewHandler(WebView2 webview, string initialUrl, string? environmentFolderPath = null)
    {
        WebView = webview;
        InitialUrl = initialUrl;
        EnvironmentFolderPath = environmentFolderPath;

        WebView.Dispatcher.Invoke((Action)(() => InitializeAsync().FireAndForget()), DispatcherPriority.Loaded);
    }
    
    public Action InitializeComplete { get; set; } 

    public WebView2 WebView { get; private set; }
    public string InitialUrl { get; }
    public string? EnvironmentFolderPath { get; private set; }
    public bool IsInitialized { get; set; }
    
    public string HostObjectName { get; init; } = "webview";
    public object? HostObject { get; init; } = null;
    
    public bool EnableDevTools { get; init; }
    
    public string? HostWebRootFolder { get; init; }
    public string HostWebHostNameForFolder { get; set; } = "https://localweb.com";

    public virtual void Navigate(string url, bool forceRefresh = false)
    {
        if (string.IsNullOrEmpty(url)) return;
        WebView.Source = new Uri(url);
    }

    protected async Task InitializeAsync()
    {
        var environment = await CoreWebView2Environment.CreateAsync(userDataFolder: EnvironmentFolderPath,
            options: new CoreWebView2EnvironmentOptions
            {
                AllowSingleSignOnUsingOSPrimaryAccount = true
            });
        await WebView.EnsureCoreWebView2Async(environment);
        
        InitializeComplete?.Invoke();
        IsInitialized = true;
        
        if (HostObject != null)
        {
            await WebView.Dispatcher.InvokeAsync(() =>
            {
                WebView.CoreWebView2.AddHostObjectToScript(HostObjectName, HostObject);
            });
        }
        
        if(EnableDevTools)
            WebView.CoreWebView2.OpenDevToolsWindow();
        
        // Map local folder to a virtual domain name
        if (!string.IsNullOrEmpty(HostWebRootFolder))
        {
            WebView.CoreWebView2.SetVirtualHostNameToFolderMapping(HostWebHostNameForFolder, HostWebRootFolder, CoreWebView2HostResourceAccessKind.Allow);
        }
        
        if (!string.IsNullOrEmpty(InitialUrl))
        {
            Navigate(InitialUrl);
        }
    }

}