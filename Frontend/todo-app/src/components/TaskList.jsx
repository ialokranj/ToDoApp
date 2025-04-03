import React from 'react';

const TaskList = ({ tasks, onEdit, onDelete, onToggleStatus }) => {
  return (
    <ul>
      {tasks.map((task) => (
        <li key={task.taskID} className="p-4 bg-gray-800 rounded my-2 flex justify-between">
          <div>
            <h2 className="text-xl font-semibold">{task.taskTitle}</h2>
            <p>{task.taskDescription}</p>
            <p>Due: {task.taskDueDate}</p>
            <input
              type="checkbox"
              checked={task.taskStatus}
              onChange={() => onToggleStatus(task)}
            />
            <label className="ml-2">Completed</label>
          </div>
          <div>
            <button onClick={() => onEdit(task)} className="bg-blue-500 px-3 py-1 mr-2 rounded">Edit</button>
            <button onClick={() => onDelete(task.taskID)} className="bg-red-500 px-3 py-1 rounded">Delete</button>
          </div>
        </li>
      ))}
    </ul>
  );
};

export default TaskList;
