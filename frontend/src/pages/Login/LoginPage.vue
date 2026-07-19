<script setup>
import { ref, onMounted } from 'vue'
import axiosClient from '../../api/axiosClient'

const status = ref('Đang kiểm tra...')

onMounted(async () => {
  try {
    const res = await axiosClient.get('/api/health')
    status.value = `Kết nối: ${res.data.status}`
  } catch (err) {
    status.value = 'Lỗi kết nối API: ' + err.message
  }
})
</script>

<template>
  <div>
    <h1>Hello Vue</h1>
    <p>{{ status }}</p>
  </div>
</template>