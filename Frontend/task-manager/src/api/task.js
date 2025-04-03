import axios from 'axios';

const API_URL = 'https://localhost:7145/api/Task';

export const getTasksByUser = async (userId) => {
    const response = await axios.get(`${API_URL}/ByUser/${userId}`);
    return response.data;
};

export const createTask = async (taskData) => {
    const response = await axios.post(API_URL, taskData);
    return response.data;
};

export const updateTask = async (id, taskData) => {
    const response = await axios.put(`${API_URL}/${id}`, taskData);
    return response.data;
};

export const deleteTask = async (id) => {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
};