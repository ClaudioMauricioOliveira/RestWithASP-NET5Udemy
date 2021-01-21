import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:44386',
})

export default api;