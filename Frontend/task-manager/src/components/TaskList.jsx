import React from 'react';
import { deleteTask } from '../api/task';

const TaskList = ({ tasks, setTasks }) => {
    const handleDelete = async (id) => {
        await deleteTask(id);
        setTasks(tasks.filter(task => task.id !== id));
    };

    return (
        <ul>
            {tasks.map(task => (
                <li key={task.id}>
                    {task.title} - {task.description}
                    <button onClick={() => handleDelete(task.id)}>Delete</button>
                </li>
            ))}
        </ul>
    );
};

export default TaskList;