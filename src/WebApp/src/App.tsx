// src/App.tsx
import './App.css';
import { useUsers } from 'users'; // Adjust path as needed
import { UserDetail } from './components/UserDetail'; // Adjust path as needed
import { useState } from 'react';
import {User} from "./types/User.ts";

function App() {
    const { users, loading, error } = useUsers();
    const [selectedUserId, setSelectedUserId] = useState<string | null>(null);

    const handleUserClick = (userId: string) => {
        setSelectedUserId(userId);
    };

    return (
        <>
            <h1>User List</h1>
            {loading && <p>Loading users...</p>}
            {error && <p>Error: {error}</p>}
            {!loading && !error && (
                <ul>
                    {users.map((user:User) => (
                        <li
                            key={user.id} // Use user.id instead of index for uniqueness
                            onClick={() => handleUserClick(user.id)}
                            style={{ cursor: 'pointer' }} // Make it look clickable
                        >
                            {user.name}
                        </li>
                    ))}
                </ul>
            )}
            {selectedUserId && <UserDetail userId={selectedUserId} />}
        </>
    );
}

export default App;