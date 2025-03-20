// src/hooks/useUser.ts
import { useState, useEffect } from "react";
import { apiClient } from "../interop/WebviewApiClient";
import { User } from "../types/User.ts";

export function useUser(id: string) {
    const [user, setUser] = useState<User | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                setLoading(true);
                console.log(`Fetching user with id: ${id}`);
                const fetchedUser = await apiClient.call<User | null>("userService", "getUser", { id });
                console.log("Fetched user:", fetchedUser);
                setUser(fetchedUser);
            } catch (err) {
                setError("Failed to fetch user");
                console.error(err);
            } finally {
                setLoading(false);
            }
        };

        fetchUser();
    }, [id]); // Re-run if id changes

    return { user, loading, error };
}