<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '../../stores/authStore'
import { authApi } from '../../api/authApi'

const router = useRouter()
const authStore = useAuthStore()

const email = ref('')
const password = ref('')
const loading = ref(false)
const error = ref('')
const rememberMe = ref(false)

async function handleLogin() {
  error.value = ''
  loading.value = true

  if (!email.value || !password.value) {
    error.value = 'Vui lòng điền đầy đủ thông tin'
    loading.value = false
    return
  }

  try {
    const response = await authApi.login({
      email: email.value,
      password: password.value,
    })

    const { accessToken, refreshToken, userId, hoTen } = response.data

    authStore.setTokens(accessToken, refreshToken, {
      userId,
      email: email.value,
      hoTen,
    })

    router.push('/dashboard')
  } catch (err) {
    error.value = err.response?.data?.message ?? 'Đăng nhập thất bại'
  } finally {
    loading.value = false
  }
}
</script>

<template>
  <div class="login-container">
    <div class="login-box">
      <div class="login-left">
        <div class="brand">
          <h2>QUẢN LÝ TRỌ</h2>
          <p>Hệ Thống Quản Lý Trọ</p>
        </div>
        <div class="illustration">🏢</div>
      </div>

      <div class="login-right">
        <div class="form-container">
          <h1>Đăng nhập</h1>
          <p class="subtitle">Chào mừng quay trở lại</p>

          <form @submit.prevent="handleLogin">
            <div class="form-group">
              <label for="email">TÊN ĐĂNG NHẬP</label>
              <input
                id="email"
                v-model="email"
                type="email"
                placeholder="Nhập tên đăng nhập"
                class="input-field"
              />
            </div>

            <div class="form-group">
              <label for="password">MẬT KHẨU</label>
              <input
                id="password"
                v-model="password"
                type="password"
                placeholder="Nhập mật khẩu"
                class="input-field"
              />
            </div>

            <div class="form-footer">
              <label class="checkbox">
                <input v-model="rememberMe" type="checkbox" />
                <span>Ghi nhớ đăng nhập</span>
              </label>
              <a href="#" class="forgot-link">Quên mật khẩu?</a>
            </div>

            <div v-if="error" class="error-message">{{ error }}</div>

            <button type="submit" class="btn-login" :disabled="loading">
              {{ loading ? 'Đang đăng nhập...' : 'Đăng nhập' }}
            </button>
          </form>

          <div class="form-links">
            <span>Điều khoản</span>
            <span>Bảo mật</span>
            <span>Hỗ trợ</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.login-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%);
  display: flex;
  justify-content: center;
  align-items: center;
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.login-box {
  background: white;
  border-radius: 12px;
  box-shadow: 0 10px 40px rgba(0, 0, 0, 0.15);
  display: flex;
  width: 90%;
  max-width: 1000px;
  overflow: hidden;
}

.login-left {
  flex: 1;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 60px 40px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.brand h2 {
  font-size: 28px;
  margin-bottom: 10px;
}

.brand p {
  font-size: 14px;
  opacity: 0.9;
  margin-bottom: 30px;
}

.illustration {
  margin: 40px 0;
  font-size: 80px;
}

.tagline {
  font-size: 14px;
  opacity: 0.85;
}

.login-right {
  flex: 1;
  padding: 60px 40px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.form-container {
  width: 100%;
  max-width: 400px;
}

h1 {
  font-size: 28px;
  color: #333;
  margin-bottom: 8px;
}

.subtitle {
  color: #999;
  font-size: 14px;
  margin-bottom: 30px;
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  font-size: 12px;
  font-weight: 600;
  color: #666;
  margin-bottom: 8px;
}

.input-field {
  width: 100%;
  padding: 12px 14px;
  border: 1px solid #ddd;
  border-radius: 6px;
  font-size: 14px;
  transition: all 0.3s;
}

.input-field:focus {
  outline: none;
  border-color: #667eea;
  box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.1);
}

.form-footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 24px;
  font-size: 14px;
}

.checkbox {
  display: flex;
  align-items: center;
  cursor: pointer;
}

.checkbox input {
  margin-right: 6px;
  cursor: pointer;
}

.forgot-link {
  color: #667eea;
  text-decoration: none;
  font-size: 13px;
  font-weight: 500;
}

.forgot-link:hover {
  text-decoration: underline;
}

.error-message {
  color: #e74c3c;
  background: #fadbd8;
  padding: 10px;
  border-radius: 4px;
  font-size: 13px;
  margin-bottom: 16px;
  border-left: 3px solid #e74c3c;
}

.btn-login {
  width: 100%;
  padding: 12px;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border: none;
  border-radius: 6px;
  font-size: 15px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s;
  margin-bottom: 20px;
}

.btn-login:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 6px 20px rgba(102, 126, 234, 0.4);
}

.btn-login:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

.form-links {
  display: flex;
  justify-content: center;
  gap: 16px;
  font-size: 12px;
  color: #999;
  padding-top: 20px;
  border-top: 1px solid #eee;
}

@media (max-width: 768px) {
  .login-box {
    flex-direction: column;
  }

  .login-left {
    padding: 40px 30px;
  }

  .login-right {
    padding: 40px 30px;
  }
}
</style>