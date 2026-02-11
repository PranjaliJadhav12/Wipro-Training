import React, { useState, useEffect } from "react";
import io from "socket.io-client";
import styled, { ThemeProvider } from "styled-components";

const socket = io("http://localhost:5000");

// Themes
const lightTheme = { background: "#ffffff", color: "#000000" };
const darkTheme = { background: "#1e1e1e", color: "#ffffff" };

const Container = styled.div`
  background: ${(props) => props.theme.background};
  color: ${(props) => props.theme.color};
  min-height: 100vh;
  padding: 20px;
`;

function TaskDashboard() {
  const [tasks, setTasks] = useState([]);
  const [newTask, setNewTask] = useState("");
  const [theme, setTheme] = useState(lightTheme);

  useEffect(() => {
    socket.on("loadTasks", (loadedTasks) => {
      setTasks(loadedTasks);
    });

    socket.on("taskUpdated", (updatedTasks) => {
      setTasks(updatedTasks);
    });

    return () => socket.disconnect();
  }, []);

  const addTask = () => {
    if (newTask.trim() !== "") {
      const task = {
        id: Date.now(),
        title: newTask,
      };

      socket.emit("addTask", task);
      setNewTask("");
    }
  };

  const deleteTask = (id) => {
    socket.emit("deleteTask", id);
  };

  return (
    <ThemeProvider theme={theme}>
      <Container>
        <h1>Real-Time Task Dashboard</h1>

        <button
          onClick={() =>
            setTheme(theme === lightTheme ? darkTheme : lightTheme)
          }
        >
          Toggle Theme
        </button>

        <div style={{ marginTop: "20px" }}>
          <input
            type="text"
            value={newTask}
            onChange={(e) => setNewTask(e.target.value)}
            placeholder="Enter task"
          />
          <button onClick={addTask}>Add Task</button>
        </div>

        <ul>
          {tasks.map((task) => (
            <li key={task.id}>
              {task.title}
              <button onClick={() => deleteTask(task.id)}>❌</button>
            </li>
          ))}
        </ul>
      </Container>
    </ThemeProvider>
  );
}

export default TaskDashboard;
