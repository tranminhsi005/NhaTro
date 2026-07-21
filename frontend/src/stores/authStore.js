import { defineStore } from "pinia";
import { ref, computed } from "vue";

export const useAuthStore = defineStore("auth", () => {
  const accessToken = ref(localStorage.getItem("accessToken") || null);
  const refreshToken = ref(localStorage.getItem("refreshToken") || null);
  const user = ref(null);

  const tokenData = localStorage.getItem("user");
  if (tokenData) {
    user.value = JSON.parse(tokenData);
  }

  const isAuthenticated = computed(() => !!accessToken.value);

  function setTokens(access, refresh, userData) {
    accessToken.value = access;
    refreshToken.value = refresh;
    user.value = userData;

    localStorage.setItem("accessToken", access);
    localStorage.setItem("refreshToken", refresh);
    localStorage.setItem("user", JSON.stringify(userData));
  }

  function logout() {
    accessToken.value = null;
    refreshToken.value = null;
    user.value = null;

    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("user");
  }

  return {
    accessToken,
    refreshToken,
    user,
    isAuthenticated,
    setTokens,
    logout,
  };
});
