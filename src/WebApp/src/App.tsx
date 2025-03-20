import './App.css'
import {useUsers} from "./users/useUsers.ts";

function App() {

    const {users} = useUsers();

    console.log("Users");
    console.log(users);
    
    return (
        <>
            <ul>
                {users.map((user, index) => (
                    <li key={index}>{user.name}</li>
                ))}
            </ul>
        </>
    );
}

export default App
