// hooks/useUsers.ts
import { useState, useEffect } from "react";
import { apiClient } from "../interop/WebviewApiClient";

interface User {
    id: number;
    name: string;
}

export function useUsers() {
    const [users, setUsers] = useState<User[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        // Fetch initial users
        const fetchUsers = async () => {
            try {
                setLoading(true);
                const userList = await apiClient.call<User[]>("userService", "getUsers");
                setUsers(userList);
            } catch (err) {
                setError("Failed to fetch users");
                console.error(err);
            } finally {
                setLoading(false);
            }
        };

        fetchUsers();

        // Subscribe to events
        const unsubscribeAdded = apiClient.on("userService.userAdded", (newUser: User) => {
            setUsers((prev) => [...prev, newUser]);
        });

        const unsubscribeRemoved = apiClient.on("userService.userRemoved", (userId: number) => {
            setUsers((prev) => prev.filter((user) => user.id !== userId));
        });

        // Cleanup subscriptions on unmount
        return () => {
            unsubscribeAdded();
            unsubscribeRemoved();
        };
    }, []); // Empty dependency array: runs once on mount

    return { users, loading, error };
}