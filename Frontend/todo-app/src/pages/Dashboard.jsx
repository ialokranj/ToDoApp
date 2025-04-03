import React, { useState, useEffect } from 'react';
import { getTasksByUser, addTask, updateTask, deleteTask } from '../services/api';
import Navbar from '../components/Navbar';
import TaskList from '../components/TaskList';

const Dashboard = () => {
  const [tasks, setTasks] = useState([]);
  const [newTask, setNewTask] = useState({ taskTitle: '', taskDescription: '', taskDueDate: '' });
  const [editingTask, setEditingTask] = useState(null);
  const [showAddForm, setShowAddForm] = useState(false);

  const userId = localStorage.getItem('userId');
  const username = localStorage.getItem('username');

  useEffect(() => {
    if (userId) {
      getTasksByUser(userId)
        .then(data => setTasks(data))
        .catch(error => console.error('Error fetching tasks:', error));
    }
  }, [userId]);

  const handleAddTask = () => {
    addTask({ ...newTask, userId })
      .then(data => {
        setTasks([...tasks, data]);
        setNewTask({ taskTitle: '', taskDescription: '', taskDueDate: '' });
        setShowAddForm(false);
      })
      .catch(error => console.error('Error adding task:', error));
  };

  const handleUpdateTask = (task) => {
    updateTask(task.taskID, task)
      .then(() => {
        setTasks(tasks.map(t => (t.taskID === task.taskID ? task : t)));
        setEditingTask(null);
      })
      .catch(error => console.error('Error updating task:', error));
  };

  const handleDeleteTask = (taskID) => {
    deleteTask(taskID)
      .then(() => setTasks(tasks.filter(t => t.taskID !== taskID)))
      .catch(error => console.error('Error deleting task:', error));
  };

  const handleToggleStatus = (task) => {
    const updatedTask = { ...task, taskStatus: !task.taskStatus };
    handleUpdateTask(updatedTask);
  };

  const handleLogout = () => {
    localStorage.removeItem('userId');
    localStorage.removeItem('username');
    window.location.reload();
  };

  return (
    <div className="min-h-screen bg-gray-900 text-white">
      <Navbar username={username || 'User'} onLogout={handleLogout} />
      <div className="p-6">
        <h1 className="text-2xl font-bold">To-Do List</h1>
        <TaskList
          tasks={tasks}
          onEdit={setEditingTask}
          onDelete={handleDeleteTask}
          onToggleStatus={handleToggleStatus}
        />
        <button onClick={() => setShowAddForm(!showAddForm)} className="bg-green-500 px-4 py-2 rounded mt-4">
          {showAddForm ? 'Cancel' : 'Add Task'}
        </button>
        {showAddForm && (
          <div className="mt-4">
            <input
              type="text"
              placeholder="Title"
              value={newTask.taskTitle}
              onChange={(e) => setNewTask({ ...newTask, taskTitle: e.target.value })}
              className="p-2 mr-2 rounded"
            />
            <input
              type="text"
              placeholder="Description"
              value={newTask.taskDescription}
              onChange={(e) => setNewTask({ ...newTask, taskDescription: e.target.value })}
              className="p-2 mr-2 rounded"
            />
            <input
              type="date"
              value={newTask.taskDueDate}
              onChange={(e) => setNewTask({ ...newTask, taskDueDate: e.target.value })}
              className="p-2 mr-2 rounded"
            />
            <button onClick={handleAddTask} className="bg-blue-500 px-4 py-2 rounded">Save Task</button>
          </div>
        )}
      </div>
    </div>
  );
};

export default Dashboard;
