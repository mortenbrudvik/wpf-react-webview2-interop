﻿export interface WebView {
    addEventListener(type: string, listener: (event: MessageEvent<any>) => void): void;
    removeEventListener(type: string, listener: (event: MessageEvent<any>) => void): void;
    postMessage(message: any): void;
    hostObjects: {
        apibridge: {
            Invoke(service: string, method: string, jsonParams: string): Promise<string>;
        };
    };
}