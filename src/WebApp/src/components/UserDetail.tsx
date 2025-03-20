// src/components/UserDetail.tsx
import React from "react";
import { useUser } from "../users/useUser.ts";

export const UserDetail: React.FC<{ userId: string }> = ({ userId }) => {
    const { user, loading, error } = useUser(userId);

    if (loading) return <div>Loading user...</div>;
    if (error) return <div>Error: {error}</div>;
    if (!user) return <div>User not found</div>;

    return (
        <div>
            <h2>User Details</h2>
            <p>Name: {user.name}</p>
            <p>ID: {user.id}</p>
        </div>
    );
};