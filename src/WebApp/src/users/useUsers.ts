// hooks/useUsers.ts
import { useState, useEffect } from "react";
import { apiClient } from "../interop/WebviewApiClient";
import { User } from "../types/User.ts";

export function useUsers() {
    const [users, setUsers] = useState<User[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                setLoading(true);
                console.log("Fetching users...");
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

        const unsubscribeAdded = apiClient.on("userService.userAdded", (newUser: User) => {
            console.log("User added:", newUser);
            setUsers((prev) => [...prev, newUser]);
        });

        const unsubscribeRemoved = apiClient.on("userService.userRemoved", (userId: string) => {
            console.log("User removed with id:", userId);
            setUsers((prev) => prev.filter((user) => user.id !== userId));
        });

        return () => {
            unsubscribeAdded();
            unsubscribeRemoved();
        };
    }, []);

    return { users, loading, error };
}