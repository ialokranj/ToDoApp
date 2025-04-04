import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Home = () => {
  const [tasks, setTasks] = useState([]);
  const navigate = useNavigate();
  const userId = localStorage.getItem("userId");

  useEffect(() => {
    if (!userId) {
      navigate("/");
      return;
    }

    axios.get(`https://localhost:7145/api/Task/ByUser/${userId}`)
      .then(res => setTasks(res.data))
      .catch(err => console.error(err));
  }, [userId, navigate]);

  return (
    <div>
      <h1>Task List</h1>
      {tasks.length === 0 ? <p>No tasks found.</p> : (
        <ul>
          {tasks.map(task => (
            <li key={task.taskID}>
              <strong>{task.taskTitle}</strong>: {task.taskDescription}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default Home;
