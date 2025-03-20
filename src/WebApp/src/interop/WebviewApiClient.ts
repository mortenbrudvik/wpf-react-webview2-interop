interface WebViewMessage {
    eventName: string;
    data: any;
}

export class WebViewApiClient {
    private listeners: { [eventName: string]: ((data: any) => void)[] } = {};

    constructor() {
        if (window?.chrome?.webview) {
            window.chrome.webview.addEventListener("message", (event: MessageEvent<WebViewMessage>) => {
                const { eventName, data } = event.data;
                console.debug("Raw event.data:", JSON.stringify(event.data));
                this.listeners[eventName]?.forEach((callback) => {
                    console.debug(`Calling callbacks for ${eventName} with data: ${JSON.stringify(data)}`);
                    callback(data);
                });
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
        const result = await window.chrome?.webview?.hostObjects?.apibridge.InvokeMethod(service, method, jsonParams);
        console.debug(`WebView2 API bridge returned: ${result}`)
        return JSON.parse(result) as T;
    }

    on(eventName: string, callback: (data: any) => void): () => void {
        console.debug(`Subscribing to event '${eventName}' with callback: ${callback.toString()}`)
        if (!this.listeners[eventName]) this.listeners[eventName] = [];
        this.listeners[eventName].push(callback);

        // Return an unsubscribe function
        return () => {
            this.listeners[eventName] = this.listeners[eventName].filter((cb) => cb !== callback);
        };
    }
}

export const apiClient = new WebViewApiClient();