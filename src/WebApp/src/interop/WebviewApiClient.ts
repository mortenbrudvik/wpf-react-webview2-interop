interface WebViewMessage {
    EventName: string;
    Data: any;
}

export class WebViewApiClient {
    private listeners: { [eventName: string]: ((data: any) => void)[] } = {};

    constructor() {
        // Ensure WebView2 is available
        if (window?.chrome?.webview) {
            window.chrome.webview.addEventListener("message", (event: MessageEvent<WebViewMessage>) => {
                const { EventName, Data } = event.data;
                this.listeners[EventName]?.forEach((callback) => callback(Data));
            });
        } else {
            console.warn("WebView2 not available");
        }
    }

    async call<T>(service: string, method: string, params: any = {}): Promise<T> {
        const jsonParams = JSON.stringify(params);
        if (!window.chrome?.webview?.hostObjects?.apibridge) {
            throw new Error("WebView2 API bridge not available");
        }
        console.log("service: " + service);
        const result = await window.chrome?.webview?.hostObjects?.apibridge.InvokeMethod(service, method, jsonParams);
        console.log("result: " + result);
        return JSON.parse(result) as T;
    }

    on(eventName: string, callback: (data: any) => void): () => void {
        if (!this.listeners[eventName]) this.listeners[eventName] = [];
        this.listeners[eventName].push(callback);

        // Return an unsubscribe function
        return () => {
            this.listeners[eventName] = this.listeners[eventName].filter((cb) => cb !== callback);
        };
    }
}

export const apiClient = new WebViewApiClient();