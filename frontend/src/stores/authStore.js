// frontend/src/stores/authStore.js
import { defineStore } from "pinia";
import { ref, computed } from "vue";

export const useAuthStore = defineStore("auth", () => {
  const accessToken = ref(localStorage.getItem("accessToken") || null);
  const user = ref(null);

  const isAuthenticated = computed(() => !!accessToken.value);

  function setToken(token) {
    accessToken.value = token;
    localStorage.setItem("accessToken", token);
  }

  function logout() {
    accessToken.value = null;
    user.value = null;
    localStorage.removeItem("accessToken");
  }

  return { accessToken, user, isAuthenticated, setToken, logout };
});
