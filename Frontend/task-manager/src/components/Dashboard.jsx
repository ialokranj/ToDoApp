import React, { useEffect, useState } from 'react';
import { getTasksByUser } from '../api/task';
import TaskList from './TaskList';
import TaskForm from './TaskForm';

const Dashboard = () => {
    const [tasks, setTasks] = useState([]);
    const userId = localStorage.getItem('userId');

    useEffect(() => {
        const fetchTasks = async () => {
            const tasks = await getTasksByUser(userId);
            setTasks(tasks);
        };
        fetchTasks();
    }, [userId]);

    return (
        <div>
            <h2>Dashboard</h2>
            <TaskForm setTasks={setTasks} />
            <TaskList tasks={tasks} setTasks={setTasks} />
        </div>
    );
};

export default Dashboard;