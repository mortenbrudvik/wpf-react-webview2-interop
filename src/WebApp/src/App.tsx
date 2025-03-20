import './App.css'
import {useUsers} from "users";

function App() {

    const {users} = useUsers();
    
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
