// frontend/src/api/phongApi.js
import axiosClient from "./axiosClient";
import { ENDPOINTS } from "./endpoints";

export const phongApi = {
  getAll: () => axiosClient.get(ENDPOINTS.PHONG.BASE),
  getById: (id) => axiosClient.get(ENDPOINTS.PHONG.BY_ID(id)),
  create: (formData) =>
    axiosClient.post(ENDPOINTS.PHONG.BASE, formData, {
      headers: { "Content-Type": "multipart/form-data" },
    }),
};
