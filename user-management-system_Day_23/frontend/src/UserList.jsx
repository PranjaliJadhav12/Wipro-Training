import React from "react";

class UserList extends React.Component {
  render() {
    return (
      <div>
        <h2>User List</h2>
        <ul>
          {this.props.users.map((user) => (
            <li key={user.id}>{user.name}</li>
          ))}
        </ul>
      </div>
    );
  }
}

export default UserList;
