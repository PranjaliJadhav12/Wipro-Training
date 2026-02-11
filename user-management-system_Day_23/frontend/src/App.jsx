import React, { useState } from "react";
import UserList from "./UserList";
import UserForm from "./UserForm";

function App() {
  const [users, setUsers] = useState([]);

  const fetchUsers = async () => {
    const response = await fetch("http://localhost:5000/users");
    const data = await response.json();
    setUsers(data);
  };

  return (
    <div>
      <h1>User Management System</h1>

      <UserForm fetchUsers={fetchUsers} />

      <button onClick={fetchUsers}>Load Users</button>

      <UserList users={users} />
    </div>
  );
}

export default App;
