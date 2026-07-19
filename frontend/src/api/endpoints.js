// frontend/src/api/endpoints.js
export const ENDPOINTS = {
  AUTH: {
    LOGIN: "/api/v1/auth/login",
    REGISTER: "/api/v1/auth/register",
    REFRESH_TOKEN: "/api/v1/auth/refresh-token",
  },
  PHONG: {
    BASE: "/api/v1/phong",
    BY_ID: (id) => `/api/v1/phong/${id}`,
    UPLOAD_ANH: (id) => `/api/v1/phong/${id}/anh`,
  },
  HOP_DONG: {
    BASE: "/api/v1/hop-dong",
  },
};
