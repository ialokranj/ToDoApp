import React, { useState } from 'react';
import { createTask } from '../api/task';

const TaskForm = ({ setTasks }) => {
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const userId = localStorage.getItem('userId');

    const handleSubmit = async (e) => {
        e.preventDefault();
        const newTask = await createTask({ title, description, userId });
        setTasks(prevTasks => [...prevTasks, newTask]);
        setTitle('');
        setDescription('');
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Title"
                value={title}
                onChange={(e) => setTitle(e.target.value)}
                required
            />
            <input
                type="text"
                placeholder="Description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
                required
            />
            <button type="submit">Add Task</button>
        </form>
    );
};

export default TaskForm;