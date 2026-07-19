// frontend/src/api/axiosClient.js
import axios from "axios";

const axiosClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

// Tự động gắn JWT access token vào mọi request (nếu đã đăng nhập)
axiosClient.interceptors.request.use((config) => {
  const token = localStorage.getItem("accessToken");
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

// Bắt lỗi 401 token hết hạn để sau này xử lý refresh token tự động
axiosClient.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      console.warn("Access token hết hạn hoặc không hợp lệ");
      // Sẽ xử lý refresh token ở module Auth sau
    }
    return Promise.reject(error);
  },
);

export default axiosClient;
