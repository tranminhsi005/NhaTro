// frontend/src/api/authApi.js
import axiosClient from "./axiosClient";
import { ENDPOINTS } from "./endpoints";

export const authApi = {
  login: (data) => axiosClient.post(ENDPOINTS.AUTH.LOGIN, data),
  register: (data) => axiosClient.post(ENDPOINTS.AUTH.REGISTER, data),
};
