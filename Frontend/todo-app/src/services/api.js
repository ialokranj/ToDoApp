import axios from 'axios';

const API_BASE_URL = 'https://localhost:7145/api';

export const getTasksByUser = async (userId) => {
  const response = await axios.get(`${API_BASE_URL}/Task/ByUser/${userId}`);
  return response.data;
};

export const addTask = async (task) => {
  const response = await axios.post(`${API_BASE_URL}/Task`, task);
  return response.data;
};

export const updateTask = async (taskId, task) => {
  const response = await axios.put(`${API_BASE_URL}/Task/${taskId}`, task);
  return response.data;
};

export const deleteTask = async (taskId) => {
  const response = await axios.delete(`${API_BASE_URL}/Task/${taskId}`);
  return response.data;
};
