// hooks/useUserEvent.ts
import { useEffect } from "react";
import { apiClient } from "../interop/WebviewApiClient";

export function useUserEvent<T>(eventName: string, callback: (data: T) => void) {
    useEffect(() => {
        const unsubscribe = apiClient.on(eventName, callback);
        return unsubscribe; // Cleanup on unmount or dependency change
    }, [eventName, callback]); // Re-run if eventName or callback changes
}